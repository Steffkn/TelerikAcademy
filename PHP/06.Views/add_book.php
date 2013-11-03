<?php
include './include/functions.php';
$data=[];
if (isset($_POST['book_name'])) {

    $book_name = trim($_POST['book_name']);
    if (!isset($_POST['authors'])) {
        $_POST['authors'] = '';
    }
    $authors = $_POST['authors'];
    
    $data['notifications']['error'] = array();
   
    if (mb_strlen($book_name) < 2) {
        $data['notifications']['error'][] = 'Невалидно име на книга!';
    }
    if (!is_array($authors) || count($authors) == 0) {
        $data['notifications']['error'][] = 'Не са посочени автори!';
    }
    if (!isAuthorIdExists($DBconnection, $authors)) {
        $data['notifications']['error'][] = 'Невалиден автор!';
    }
    if (count($data['notifications']['error']) == 0){
        mysqli_query($DBconnection, 'INSERT INTO books (book_title) VALUES("' .
                mysqli_real_escape_string($DBconnection, $book_name) . '")');
        if (mysqli_error($DBconnection)) {
            $data['title'] = '500 - Internal server error!';
            $data['content'] = 'templates/error.php';
            render($data, 'templates/layouts/error_layout.php');
            exit;
        }
        $id = mysqli_insert_id($DBconnection);
        foreach ($authors as $authorId) {
            mysqli_query($DBconnection, 'INSERT INTO books_authors (book_id,author_id)
                VALUES (' . $id . ',' . $authorId . ')');
            if (mysqli_error($DBconnection)) {
                $data['title'] = '500 - Internal server error!';
                $data['content'] = 'templates/error.php';
                render($data, 'templates/layouts/error_layout.php');
                exit;
            }
        }
        $data['notifications']['success'][] = 'Книгата е добавена';
    }
}

$authors = getAuthors($DBconnection);
if ($authors === false) {
    $data['title'] = '500 - Internal server error!';
    $data['content'] = 'templates/error.php';
    render($data, 'templates/layouts/error_layout.php');  
}
else{
    
    foreach ($authors as $row) {
        $data['authors'][$row['author_id']]=$row['author_name'];
    }

    $data['title'] = 'Нова книга';
    $data['content'] = 'templates/add_book_public.php';
    $data['header'] = 'templates/header.php';
    $data['footer'] = 'templates/footer.php';
    render($data, 'templates/layouts/normal_layout.php');
}