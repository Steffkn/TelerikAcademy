<?php
$pageTitle='Register';
include 'includes/connectDB.php';
include 'includes/functions.php';
include 'includes/header.php';

if (isset($_SESSION['isLogged'])) {
    // if u are loged in it will redirect u to index.php
    header('Location: index.php');
    exit;
}


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
	
        if(mb_strlen($username) < 5 || mb_strlen($username) > 40){
                  echo '<p class="error">The name should be between 5 and 40 characters long!</p>';
                  $error = true; //error found
        }	
        if(mb_strlen($pass) < 5 || mb_strlen($pass) > 20){
                echo '<p class="error">The password should be between 5 and 20 characters long!</p>';
                $error = true; //error found
        }
            
	if($pass != $rePass){
		echo '<p>The passwords does not match!</p>';
        $error = true; //error found
	}

	if(!$error){
            // Database check if the username is free
            $sql = 'SELECT user_name FROM users WHERE user_name="'.$username.'"';
            $result = mysqli_query($DBconnection, $sql);
            if ($result->num_rows > 0) {
                echo '<p class="error">The username is already taken!</p>';
            }
            else{
                // There are no more errors
                // Record the new user to the database
                
                // tweek the password
                $tweekedPass = TweekPassword($pass, $username);
                $sql = 'INSERT INTO users (user_id, user_name, user_pass) VALUES (NULL, "'.$username.'", "'.$tweekedPass.'");';
                if (mysqli_query($DBconnection, $sql)) {
                        $_SESSION['isLogged'] = true;
                        $_SESSION['username'] = $username;
                        $_SESSION['user_id'] = mysqli_insert_id($DBconnection);

                        header('Location: index.php');
                        exit;
                }
            }
	}
	else{
            echo '<p class="error">Invalid registry information!</p>';
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
        </table>
</form>

<?php
include 'includes/footer.php';