<?php

define('SQL_HOST', 'localhost');
define('SQL_USER', 'root');
define('SQL_PASS', '');
define('SQL_DB', 'books');

$connection = mysqli_connect(SQL_HOST, SQL_USER, SQL_PASS, SQL_DB);

if (!$connection) {
    echo 'Няма връзка с базата данни';
    exit;
}

mysqli_set_charset($connection, 'utf8');