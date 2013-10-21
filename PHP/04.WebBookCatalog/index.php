<?php

session_start();
$pageTitle='Всички книги';

require 'includes/header.php';
require 'includes/connectDB.php';
require 'includes/functions.php';


$order = 'ASC';
$sql = "
        SELECT * FROM `books_authors`
        LEFT JOIN authors ON authors.author_id = books_authors.author_id
        LEFT JOIN books ON books_authors.book_id = books.book_id
        ORDER BY books.book_title $order
";

$result = mysqli_query( $connection, $sql );
$bookFound = GetBooks($result);

?>

<table border="1px">

	<tr>
		<th>Книга</th>
		<th>Автор</th>
	</tr>
	<?php
	foreach ( $bookFound as $value ) {
			echo '<tr><td>';
			echo $value['book'];
			echo '</td>';
			echo '<td>';
			
			$authors = array();
			
			foreach ( $value['authors'] as $key => $author ) {
					$authors[]= '<a href="booksFromAuthor.php?authorID=' . $key . '">' . $author . '</a>';
			}
			echo implode( ',&nbsp;&nbsp;', $authors );
			echo "</td></tr>";
	}
	?>
</table>
<?php
include 'includes/footer.php';
?>
