<?php

mb_internal_encoding('UTF-8');
define('SQL_HOST', 'localhost');
define('SQL_USER', 'root');
define('SQL_PASS', '');
define('SQL_DB', 'books');

session_start();
$DBconnection = mysqli_connect(SQL_HOST, SQL_USER, SQL_PASS, SQL_DB);
if (!$DBconnection) {
    echo 'Няма връзка с базата данни';
    exit;
}
mysqli_set_charset($DBconnection, 'utf8');

function render($data,$name){           
    include $name;       
}

function getAuthors($DBconnection) {
    
    $q = mysqli_query($DBconnection, 'SELECT * FROM authors');
    if (mysqli_error($DBconnection)) {
        return false;
    }
    $ret = [];
    while ($row = mysqli_fetch_assoc($q)) {
        $ret[$row['author_id']] = $row;
    }
    return $ret;
}

function isAuthorIdExists($DBconnection, $ids) {
    if (!is_array($ids)) {
        return false;
    }
    $q = mysqli_query($DBconnection, 'SELECT * FROM authors WHERE 
        author_id IN(' . implode(',', $ids) . ')');
    if (mysqli_error($DBconnection)) {
        return false;
    }
    
    if (mysqli_num_rows($q) == count($ids)) {
        return true;
    }
    return false;
}