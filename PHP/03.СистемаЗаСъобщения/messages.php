<?php
$pageTitle='Messages';
include 'includes/header.php';

session_start();

if (!isset($_SESSION['isLogged'])) {
    header('Location: index.php');
    exit;
}
$link = mysqli_connect('localhost', 'root', '' , 'telerik');
mysqli_set_charset($link, 'utf8');
			
$error = false;

if (isset($_POST['postmsg'])) {
    $title = htmlspecialchars(mysqli_real_escape_string($link, trim($_POST['title'])));
    $content = htmlspecialchars(mysqli_real_escape_string($link, trim($_POST['content'])));

    if (mb_strlen($title, 'UTF-8') < 3) {
        $error = true;
		echo 'The title is too short';
    }
    if (mb_strlen($title, 'UTF-8') > 50) {
        $error = true;
        echo 'The title is too long';
    }
    if (mb_strlen($content, 'UTF-8') < 3) {
        $error = true;
        echo 'The content is too short';
    }
    if (mb_strlen($content, 'UTF-8') > 250) {
        $error = true;
        echo 'The content is too long';
    }
	
    if (!$error) {
        // record the message
		$sql = 'INSERT INTO messages (message_id, user_id, date, title, message) 
				VALUES (NULL, '.$_SESSION['user_id'].' , NOW() , "'.$title .'", "'.$content.'");';
		if (mysqli_query($link, $sql)) {
            header('Location: messages.php');
            exit;
		} 
		else {
			$error = true;
			header('Location: messages.php');
			exit;
        }
    } 
	else {
        // send back the error
		echo 'Проблем с базата данни!';
		header('Location: messages.php');
		exit;
	}
}

?>


<div style="text-align: right"><span ><a href="messages.php">Hello, <?= $_SESSION['username'] ?>!</a></span> 
<a href="logOut.php">Изход</a></div>

<div>Write a message :)</div>
<form method="POST">
	<table>
		<tr>
			<td><label for="title">Title</label></td>
			<td><input type="text" name="title" id="title" value="" style="width: 400px;" /></td>
		</tr>
		<tr>
			<td><label for="content">Content</label></td>
			<td><textarea name="content" id="content"></textarea></td>
		</tr>
		<tr>
			<td colspan="2" style="text-align: right">
				<input type="submit" name="postmsg" value="POST"/>
			</td>
		</tr>
	</table>
</form>

<table style="width: 80%; background-color: #DFF; border:1px solid black; margin: 20px;">
	<?php

		// много дълго, да!
		$sql = 'SELECT messages.message_id, messages.user_id, messages.date, messages.title, messages.message, 
		users.user_id, users.username, users.password 
		FROM messages, users 
		WHERE messages.user_id = users.user_id 
		ORDER BY messages.date DESC';
		
		$query = mysqli_query($link, $sql);
		if(mysqli_num_rows($query))
		{
			while( $row = mysqli_fetch_assoc($query)){
				// echo '<pre>'.print_r($row, true).'</pre>';
				echo '<tr>';
				echo 	'<td rowspan="3" style="width: 150px; vertical-align: top; padding: 0 10px 0 10px; border:1px solid black;">'.$row['username'].'</td><td style="border-bottom: 1px dotted black">'.$row['title'].'</td>';
				echo '</tr>';	
				echo '<tr>';
				echo 	'<td >'.$row['message'].'</td>';
				echo '</tr>';
				echo '<tr>';
				echo 	'<td style="font-size:10px;"> Posted on: '.$row['date'].'</td>';
				echo '</tr>';
			}
		}
		else
		{
			echo '<tr>';
			echo 	'<td style="border: 1px solid black; bakcground-color: #D00"> There are no messages yet</td>';
			echo '</tr>';
		}
		
	?>
</table>

<?php
include 'includes/footer.php';
?>