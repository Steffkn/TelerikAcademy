<?php

session_start();
$pageTitle='Нова книга';

require 'includes/header.php';
require 'includes/connectDB.php';
require 'includes/functions.php';


$sql = "SELECT * FROM authors ";
$result = mysqli_query( $connection, $sql );

if (isset ( $_POST['submit'] )) {
	$error = false;

	$title = CheckTrimString( $_POST['title'] );
	$title = mysqli_real_escape_string ( $connection, $title );
	
	// Check length of the book title
	if ( mb_strlen( $title ) < 3 ) {
			echo "<p>Името на книгата трябва да е поне три символа дълго!</p>";
			$error = true;
	}
	
	// Check if is selected author
	if ( !isset ( $_POST['authors'] ) ) {
			echo "<p>Книгата трябва да има поне един автор!</p>";
			$error = true;
	} 
	else {
			$authors = $_POST['authors'];
	}
	
	
	if ( !$error ) {                
			
		$query = '
				SELECT *
				FROM books
				WHERE book_title = "' . $title . '"
		';
		
		// Check if there is a author with the same name
		$result = mysqli_query( $connection, $query );
		
		if ( $result ) {
			if ( mysqli_num_rows( $result ) > 0 ) {
					echo "<p>Книгата вече съществува.</p>";
					$error = true;
					exit;
			 } 
			 else {
				 $sql = "
						 INSERT INTO books (book_title)
						 VALUES ('$title')
				 ";
				
				 $result = mysqli_query( $connection, $sql );
				
				if ( !$result ) {
					echo "<p>Книгата не бе записана!</p>";
					exit ();
				}
				 
				$insertID = mysqli_insert_id ( $connection );
				foreach ( $authors as $value ) {
					$values[] = "($insertID, $value)";
				}
				
				$sql = "
						INSERT INTO books_authors
						VALUES " . implode( ', ', $values )
				;
				
				$result = mysqli_query( $connection, $sql );
				
				if ( $result ) {
						echo "<p>Книгата бе записана</p>";
				} 
				else {
						echo "<p>Книгата не беше записана! Проблем с базата данни!</p>";
						$error = true;
				}                 
			 }
		}
	}
}
?>

<form method="POST">
	<label for="title">Заглавие на книгата:</label>
	<input type="text" id="title" name="title" value="" />
		<br />
	<label for="authors">Автори: </label>
		<br />
	<select id="authors" name="authors[]" multiple="multiple">
		<?php
			$sql = "SELECT * FROM authors ";
			$result = mysqli_query( $connection, $sql );
			while ( $row = mysqli_fetch_assoc ( $result ) ) {
				$authorID = $row['author_id'];
				echo '<option value=' . $authorID . '> ' . $row['author_name'] . '</option>';
			}
		?>
	</select>
	<br />
	<input type="submit" name="submit" value="Save" />
</form>

<?php
include 'includes/footer.php';
?>