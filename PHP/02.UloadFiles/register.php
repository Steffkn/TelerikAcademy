<?php
$pageTitle='Register';
include 'includes/header.php';

if($_POST){
	$error = false;
	$newUsername = trim($_POST['newUsername']);
	$newPass = trim($_POST['newPass']);
	$rePass = trim($_POST['rePass']);
	$userID = 0;
	// validaciq
	$newUsername = htmlspecialchars($newUsername, ENT_QUOTES);
	$newPass = htmlspecialchars($newPass, ENT_QUOTES);
	$rePass = htmlspecialchars($rePass, ENT_QUOTES);
	
	if(mb_strlen($newUsername) < 3 || mb_strlen($newUsername) > 20){
		echo '<p>Името трябва да е между 3 и 20 символа дълга.</p>';
        $error = true; //error found
	}	
	if(mb_strlen($newPass) < 6 || mb_strlen($newPass) > 20){
		echo '<p>Паролата трябва да е между 6 и 20 символа дълга.</p>';
        $error = true; //error found
	}
	if($newPass != $rePass){
		echo '<p>Паролите не съвпадат.</p>';
        $error = true; //error found
	}
	if(file_exists('userDB.txt'))
	{	
		// add everything from the file to $result
		$users = file('userDB.txt');
		// loop trough the lines in the result
		foreach ($users as $user){
			// separate the colums by '!'
			$columns =  explode('!', $user);
			$userID = $columns[0];
			if($newUsername === $columns[1]){
				echo '<p>Потребителя вече съществува!</p>';
				$error = true; //error found
			}
		}
		if(!$error){

			//make a row of data
			$result = ($userID + 1).'!'.$newUsername.'!'.$newPass."\n";
			// and add it to the file userDB.txt
			if(file_put_contents('userDB.txt', $result, FILE_APPEND))
			{
				if (!mkdir('userdb'.DIRECTORY_SEPARATOR.$newUsername, 0, true)) {
					die("'Пътят userdb'.DIRECTORY_SEPARATOR.$newUsername.' не бе направен!'");
				}
				// tell the user that the data is writen
				echo 'Регистрацията е успешен!<br />';
			}
			else{
				// tell the user that the data is writen
				echo 'Регистрацията не бе успешен! :(<br />';
			}
		}
		else{
			echo 'Невалидни входни данни!<br/>';
		}
	}
	else{
		echo 'Базата с данни за потребителите липсва!<br />';
	}
}
?>

<form method="POST">
	<div><a href="index.php">Вход</a></div>
	<div>Име:<input type="text" name="newUsername" /></div>
	<div>Парола:<input type="password" name="newPass" /></div>
	<div>Потвърди парола:<input type="password" name="rePass" /></div>
	<div><input type="submit" value="Регистрирай" /></div>
</form>
<?php
include 'includes/footer.php';
?>