<?php
include './include/functions.php';
$data=[];  
if (isset($_POST['author_name'])) {
    $author_name = trim($_POST['author_name']);
    $data['notifications']['error'] = array();
    
    if (mb_strlen($author_name) < 2) {
         $data['notifications']['error'][]  = 'Невалидно име';
    } 
    else {
        $author_esc = mysqli_real_escape_string($DBconnection, $author_name);
        $query = mysqli_query($DBconnection, 'SELECT * FROM authors WHERE
        author_name="' . $author_esc . '"');
        if (mysqli_error($DBconnection)) {
            $data['title'] = '500 - Internal server error!';
            $data['content'] = 'templates/error.php';
            render($data, 'templates/layouts/error_layout.php');
            exit;
        }
        if (mysqli_num_rows($query) > 0) {
            $data['notifications']['error'][] = 'Има такъв автор';
        } else {
            mysqli_query($DBconnection, 'INSERT INTO authors (author_name)
            VALUES("' . $author_esc . '")');
            if (mysqli_error($DBconnection)) {
                $data['title'] = '500 - Internal server error!';
                $data['content'] = 'templates/error.php';
                render($data, 'templates/layouts/error_layout.php');
                exit;
            } else {
               $data['notifications']['success'][] = 'Успешен запис';
            }
        }
    }
}
$authors = getAuthors($DBconnection);
if ($authors===false) {
    $data['title'] = '500 - Internal server error!';
    $data['content'] = 'templates/error.php';
    render($data, 'templates/layouts/error_layout.php');
}
else{
    foreach ($authors as $row) {
        $data['authors'][$row['author_id']]=$row['author_name'];
    }

    $data['title'] = 'Автори';
    $data['content'] = 'templates/authors_public.php';
    $data['header'] = 'templates/header.php';
    $data['footer'] = 'templates/footer.php';
    render($data, 'templates/layouts/normal_layout.php');
}