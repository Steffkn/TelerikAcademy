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