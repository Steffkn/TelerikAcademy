<?php
$pageTitle='Log in';
include 'includes/header.php';

session_start();
$username = 'user';
$pass = 'qwerty';


if(isset($_SESSION['isLogged']) == true){
	echo 'Already logged in.. <a href="logOut.php">Изход</a><br />';
	echo '<a href="upload.php">Качи нов файл!</a><br/>';
	echo '<a href="files.php">Списък с вашите файловете!</a><br/>';
}
else
{
	if($_POST){
		$error = false;
		$username = trim($_POST['username']);
		$pass = trim($_POST['pass']);
		// validaciq
		$username = htmlspecialchars($username, ENT_QUOTES);
		$pass = htmlspecialchars($pass, ENT_QUOTES);
		
		if(mb_strlen($username) < 3 || mb_strlen($username) > 20){
			echo '<p>Името трябва да е между 3 и 20 символа дълга.</p>';
			$error = true; //error found
		}	
		if(mb_strlen($pass) < 6 || mb_strlen($pass) > 20){
			echo '<p>Паролата трябва да е между 6 и 20 символа дълга.</p>';
			$error = true; //error found
		}
		if(file_exists('userDB.txt'))
		{
			if(!$error){
				// add everything from the file to $result
				$users = file('userDB.txt');
				// loop trough the lines in the result
				foreach ($users as $user){
					// separate the colums by '!'
					
					$columns = explode('!', trim($user));
					echo '<pre>'.print_r($columns,true).'</pre>';
					var_dump($pass);
					var_dump($columns[2]);
					echo '<br>';
					if($username === $columns[1] && strval($pass) === strval($columns[2]))
					{
						if(!mkdir('temp', 0, true)){
							echo 'Не мога да направя временната папка!';
						}
						if(file_put_contents('temp'.DIRECTORY_SEPARATOR.'current.tmp', $username))
						{
							$_SESSION['isLogged'] = true;
							header('Location: files.php');
							exit;
						}
					}
				}
				echo 'Потребителят не е намерен!';
			}
			else{
				echo 'Невалидни входни данни!';
			}
		}
		else{
			echo 'Базата с данни за потребителите липсва!<br />';
		}
		
	}
?>

<form method="POST">
	<div>Име:<input type="text" name="username" /></div>
	<div>Парола:<input type="password" name="pass" /></div>
	<div><input type="submit" value="Вход" /></div>
	<div><a href="register.php">Регистрация на нов потребител</a></div>
</form>
<?php
}
include 'includes/footer.php';
?>
