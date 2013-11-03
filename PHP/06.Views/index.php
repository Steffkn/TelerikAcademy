<?php

include './include/functions.php';

if (isset($_GET['author_id'])) {
    $author_id = (int) $_GET['author_id'];
    $query = mysqli_query($DBconnection, 'SELECT * FROM books_authors AS b1, books_authors AS b2
    LEFT JOIN authors ON authors.author_id = b2.author_id
    LEFT JOIN books ON b2.book_id = books.book_id
    WHERE b1.author_id = '.$author_id.'
        AND b2.book_id = b1.book_id');
} else {
    $query = mysqli_query($DBconnection, 'SELECT * FROM books as b 
        INNER JOIN books_authors as ba ON b.book_id = ba.book_id 
        INNER JOIN authors as a ON a.author_id=ba.author_id');
}

$data = [];
while ($row = mysqli_fetch_assoc($query)) {
    //echo '<pre>'.print_r($row, true).'</pre>';
    $data['books'][$row['book_id']]['book_title'] = $row['book_title'];
    $data['books'][$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
}

$data['title'] = 'Книги';
$data['content'] = 'templates/index_public.php';
$data['header'] = 'templates/header.php';
$data['footer'] = 'templates/footer.php';
render($data, 'templates/layouts/normal_layout.php');

