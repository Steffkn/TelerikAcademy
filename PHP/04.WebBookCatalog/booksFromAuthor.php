<?php
$pageTitle = "Книги от автор";

require 'includes/header.php';
require 'includes/connectDB.php';
require 'includes/functions.php';

?>

<?php
if ( isset ( $_GET['authorID'] ) ) {
	$authorID = CheckTrimString( $_GET['authorID'] );
} 
else {        
	header ( 'Location: index.php' );
	exit;
}

$sql = "
        SELECT * FROM books_authors AS b1, books_authors AS b2
        LEFT JOIN authors ON authors.author_id = b2.author_id
        LEFT JOIN books ON b2.book_id = books.book_id
        WHERE b1.author_id = $authorID
          AND b2.book_id = b1.book_id
";

$result = mysqli_query( $connection, $sql );

if ( $result ) {
	if ( mysqli_num_rows( $result ) > 0 ) {
	
		$bookFound = GetBooks($result);
		?>
						
		<table border="1px">
			<tr>
					<th>Книги</th>
					<th>Автор</th>
			</tr>
			<?php
			foreach ( $bookFound as $value ) {
				echo '<tr><td>' . $value['book'] . '</td><td>';
					$authors = array();
					foreach ( $value['authors'] as $key => $book ) {
						$authors[] = '<a href="booksFromAuthor.php?authorID=' . $key . '">' . $book . '</a>';
					}
					echo implode( ',&nbsp;&nbsp;', $authors );
				echo '</td></tr>';
				}
				?>
		</table>
	<?php
	} 
	else {
		// check if there is author with that ID and if there is tell the user that he doesnt have books yet
		// if there is no author with that ID tell the user that there is no suck author
		$sql = '
			SELECT *
			FROM authors
			WHERE author_id = "' . CheckTrimString( $_GET['authorID'] ) . '"
		';
		$result = mysqli_query( $connection, $sql );
		
		if( mysqli_num_rows( $result ) > 0  ){
			echo '<p>Авторът <a href="booksFromAuthor.php?authorID='. CheckTrimString( $_GET['authorID'] ) . '">' . mysqli_fetch_assoc( $result)['author_name'] . '</a> няма въведени книги!</p>';
		}
		else{
			echo '<p>Авторът не е намерен!';
		}
	}
} 
else {
	echo "<p>Няма резултати.</p>";
}

include 'includes/footer.php';