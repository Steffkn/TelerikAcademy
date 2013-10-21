<?php
session_start();
$pageTitle='Нова автор';
require 'includes/header.php';
require 'includes/connectDB.php';
require 'includes/functions.php';

$order = 'ASC';
$sql = "
        SELECT *
        FROM authors
        ORDER BY author_name $order
";

$result = mysqli_query( $connection, $sql );

// If submitAuthor button is pressed
if ( isset( $_POST['submitAuthor'] ) ) {
	$error = false;
	
	$author = CheckTrimString( $_POST['author'] );
	$author = mysqli_real_escape_string( $connection, $author );

	// Check if the length of the author's name is less than 3
	if ( mb_strlen( $author ) < 3 ) {
		echo "<p>Името на автора трябва да е поне 3 символа дълго!</p>";
		$error = true;
	}

	if ( !$error ) {
		$sql = '
				SELECT *
				FROM authors
				WHERE author_name = "' . $author . '"
		';

		// Check if there is a author with the same name
		$result = mysqli_query( $connection, $sql );

		if ( $result ) {
			if ( mysqli_num_rows( $result ) > 0 ) {
				echo "<p>Авторът вече съществува!</p>";
				$error = true;
				exit;
			}
			else {
				$sql = "
						INSERT INTO authors (author_name)
						VALUES ('$author')
				";

				$result = mysqli_query( $connection, $sql );
				if ( $result ) {
					echo "<p>Авторът е записан!</p>";
				}
				else {
					echo "<p>Авторът не беше записан успешно! Проблем с базата данни!</p>";
					$error = true;
				}
			}
		}
	}
}
?>

<form method="POST">
        <label for="author">Име на автора: </label>
        <input type="text" id="author" value="" name="author" >
        <input type="submit" name="submitAuthor" value="Добави автор" />
</form>

<table border="1px">
        <tr>
                <th>Автори</th>
        </tr>
                <?php
				
				$sql = "
						SELECT *
						FROM authors
						ORDER BY author_name $order
				";

				$result = mysqli_query( $connection, $sql );
                $authors = array();
                while ( $row = mysqli_fetch_assoc( $result ) ) {
                        $authors [] = $row;
                }
                
                foreach ( $authors as $value ) {
                        echo '<tr><td>';
                        $authorID = $value['author_id'];
                        echo "<a href='booksFromAuthor.php?authorID=$authorID'>" . $value["author_name"] . "</a>";
                        echo '</td></tr>';
                }
        ?>
</table>

<?php
include 'includes/footer.php';
?>