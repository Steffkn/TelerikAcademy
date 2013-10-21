<?php
$pageTitle='Register';
include 'includes/header.php';

if (isset($_SESSION['isLogged'])) {
    header('Location: index.php');
    exit;
}

session_start();
$link = mysqli_connect('localhost', 'root', '' , 'telerik');
mysqli_query($link, 'SET NAMES utf8');


if (isset($_POST['register'])) {

	$error = false;
	$username = trim($_POST['username']);
	$pass = trim($_POST['pass']);
	$rePass = trim($_POST['rePass']);
	$userID = 0;
	
	// validaciq
	$username = htmlspecialchars($username, ENT_QUOTES);
	$pass = htmlspecialchars($pass, ENT_QUOTES);
	$rePass = htmlspecialchars($rePass, ENT_QUOTES);
	
	if(mb_strlen($username) < 5 || mb_strlen($username) > 20){
		echo '<p>Името трябва да е между 5 и 20 символа дълга.</p>';
        $error = true; //error found
	}	
	if(mb_strlen($pass) < 5 || mb_strlen($pass) > 20){
		echo '<p>Паролата трябва да е между 5 и 20 символа дълга.</p>';
        $error = true; //error found
	}
	if($pass != $rePass){
		echo '<p>Паролите не съвпадат.</p>';
        $error = true; //error found
	}

	if(!$error){
		// Database check if the username and email are free
        $sql = 'SELECT username FROM users WHERE username="'.$username.'"';
        $result = mysqli_query($link, $sql);
        if ($result->num_rows > 0) {
            echo 'The username/email is already taken!';	
        }
		else{
			// There are no more errors
			// Record the new user to the database
			$sql = 'INSERT INTO users (user_id, username, password) VALUES (NULL, "'.$username.'", "'.$pass.'");';
			if (mysqli_query($link, $sql)) {
				$_SESSION['isLogged'] = true;
				$_SESSION['username'] = $username;
				$_SESSION['user_id'] = mysqli_insert_id($link);
				
				header('Location: messages.php');
				exit;
			}
		}
	}
	else{
		echo 'Невалидни входни данни!<br/>';
	}
}
?>

<form method="POST">
	<table>
	<tr>
		<td colspan="2"><a href="index.php">Вход</a></td>
	</tr>
	<tr>
		<td><label for="newUsername">Име:</label></td> 
		<td><input type="text" id="newUsername" name="username" /></td>
	</tr>
	<tr>
		<td><label for="newPass">Парола:</label></td> 
		<td><input type="password" id="newPass" name="pass" /></td>
	</tr>
	<tr>
		<td><label for="rePass">Потвърди парола:</label></td> 
		<td><input type="password" id="rePass" name="rePass" /></td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: right"><input type="submit" name="register" value="Регистрирай" /></td>
	</tr>
</form>

<?php
include 'includes/footer.php';
?>