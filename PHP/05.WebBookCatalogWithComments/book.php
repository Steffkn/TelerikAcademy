<?php
$pageTitle = $_GET['book_title'];

include 'includes/connectDB.php';
include 'includes/header.php';

$bookTitle = $_GET['book_title'];
$bookID = $_GET['book_id'];

$error = false;
if (isset($_POST['postmsg'])) {
    $content = htmlspecialchars(mysqli_real_escape_string($DBconnection, trim($_POST['content'])));

    if (mb_strlen($content, 'UTF-8') < 3) {
        $error = true;
        echo '<p name="correct">Коментарът е прекалено къс</p>';
    }
    if (mb_strlen($content, 'UTF-8') > 250) {
        $error = true;
        echo '<p name="correct">Коментарът е прекалено дълъг (макс 250)</p>';
    }
	
    if (!$error) {
        // zapis na komentara
        $sql = "INSERT INTO comments(comment_id, comment, date, user_id, book_id)
                        VALUES (NULL, '" .$content. "' , NOW() , " .$_SESSION['user_id'].", " . $bookID. ")";
        if (!mysqli_query($DBconnection, $sql)) {
            $error = true;
        }
        header("Location: book.php?book_id=$bookID&book_title=$bookTitle");
        exit;
    }
}



$sql = "SELECT authors.author_id, authors.author_name FROM authors
        LEFT JOIN books_authors ON authors.author_id = books_authors.author_id
        LEFT JOIN books ON books_authors.book_id = books.book_id
        WHERE books.book_id = $bookID";
        
$query = mysqli_query($DBconnection, $sql);
    $authorsOfBook = [];
if ($query->num_rows > 0) {
    while ($row = mysqli_fetch_assoc($query)) {
        $authorsOfBook[$row['author_id']] = 
                '<a href="index.php?author_id=' . $row['author_id'] . '">' 
                . $row['author_name'] . '</a>';
    }
}// книгата неможе да няма автори
?>

<table id="comments">
    <tr>
        <td>Име: </td><td><?= $bookTitle?></td>
    </tr>
    <tr>
        <td>Автори: </td>
        <td>
        <?php
            echo implode(', ', $authorsOfBook);
        ?>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center;">Коментари</td>
    </tr>
    <tr>
        <td colspan="2"> </td>
    </tr>
    <?php
    $sql = "SELECT comment_id, comment, date, users.username, books.book_title FROM comments
            LEFT JOIN users USING (user_id)
            LEFT JOIN books USING (book_id)
            WHERE books.book_id = $bookID";
    $query = mysqli_query($DBconnection, $sql);
    if ($query->num_rows > 0)
    {
            while( $row = mysqli_fetch_assoc($query)){
                    echo '<tr>';
                    echo 	'<td style="width: 100px; padding: 0 10px">'.$row['username'].'</td><td style="border-bottom: 1px dotted black"> Книга: '.$row['book_title'].'</td>';
                    echo '</tr>';	
                    echo '<tr>';
                    echo 	'<td colspan="2">'.$row['comment'].'</td>';
                    echo '</tr>';
                    echo '<tr>';
                    echo 	'<td colspan="2" style="font-size:10px;"> Posted on: '.$row['date'].'</td>';
                    echo '</tr>';
            }
    }
    else
    {
            echo '<tr>';
            echo 	'<td colspan="2" class="error"> Книгата още няма коментари!</td>';
            echo '</tr>';
    }
    ?>
</table>

 <?php 
 if(isset($_SESSION['isLogged']) == true){
echo '
<form method="POST">
	<table>
		<tr>
			<td><label for="content">Коментар</label></td>
			<td><textarea name="content" id="content"></textarea></td>
		</tr>
		<tr>
			<td colspan="2" style="text-align: right">
				<input type="submit" name="postmsg" value="Публикувай"/>
			</td>
		</tr>
	</table>
</form>';
 }    
 else {
     echo '<p class="correct">Зада оставите своят коментар, моля влезте в акаунта си :)</p>';
 }
include 'includes/footer.php';
?>