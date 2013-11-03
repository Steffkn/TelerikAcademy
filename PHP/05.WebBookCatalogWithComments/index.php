<?php
$pageTitle = 'Всички книги';

include 'includes/connectDB.php';
include 'includes/header.php';

if (isset($_GET['author_id'])) {
    $author_id = (int) $_GET['author_id'];
$sql = "SELECT * FROM books_authors AS b1, books_authors AS b2
    LEFT JOIN authors ON authors.author_id = b2.author_id
    LEFT JOIN books ON b2.book_id = books.book_id
    WHERE b1.author_id = $author_id
        AND b2.book_id = b1.book_id
";
} else {
    $sql = "SELECT * FROM books AS b
        INNER JOIN books_authors AS ba ON b.book_id = ba.book_id 
        INNER JOIN authors as a ON a.author_id = ba.author_id
        ";
}
$query = mysqli_query($DBconnection, $sql);
if ($query->num_rows > 0) {
  
    $dataRows = [];
    while ($row = mysqli_fetch_assoc($query)) {
        $dataRows[$row['book_id']]['book_title'] = $row['book_title'];
        $dataRows[$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
    }

    echo '<table border="1"><tr><td>Книга</td><td>Автори</td></tr>';
    foreach ($dataRows as $key => $row) {
        echo '<tr><td><a href="book.php?book_id='. $key. '&book_title=' . $row["book_title"] . '">' .$row['book_title'] . '</td>
            <td>';
            $authorsArr = array();
            foreach ($row['authors'] as $key => $author) {
                $authorsArr[] = '<a href="index.php?author_id=' . $key . '">' . $author . '</a>';
            }
        echo implode(', ', $authorsArr) . '</td></tr>';
    }
    echo '</table>';  
}
else
{
    $sql = "SELECT * FROM authors WHERE author_id = $author_id";
    $query = mysqli_query($DBconnection, $sql);
    $row = $query->fetch_assoc();
    echo "<p class='error'>Книги с автор '". $row['author_name']."' не са намерени</p>";
}

include 'includes/footer.php';
?>