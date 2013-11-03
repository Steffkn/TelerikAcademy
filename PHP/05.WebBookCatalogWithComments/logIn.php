<?php
$pageTitle='Log in';

include 'includes/connectDB.php';
include 'includes/header.php';
    
// reminder
$username = '';
$pass = '';
if(isset($_SESSION['isLogged']) == true){
    header('Location: index.php');
    exit;
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

            if(mb_strlen($username) < 5 || mb_strlen($username) > 20){
                    echo '<p class="error">Името трябва да е между 5 и 20 символа дълга.</p>';
                    $error = true; //error found
            }	
            if(mb_strlen($pass) < 5 || mb_strlen($pass) > 20){
                    echo '<p class="error">Паролата трябва да е между 5 и 20 символа дълга.</p>';
                    $error = true; //error found
            }
            
            if(!$error){
                    $sql = 'SELECT * FROM users WHERE username="'.$username.'" AND password="'.$pass.'"';
                    $result = mysqli_query($DBconnection, $sql);
                    if ($result->num_rows > 0) {
                            $row = $result->fetch_assoc();
                            $_SESSION['username'] = $username;
                            $_SESSION['user_id'] = $row['user_id'];
                            $_SESSION['isLogged'] = true;

                            header('Location: index.php');
                            exit;
                    }
                    else
                    {
                            $error = true;
                            echo '<p class="error">Потребител с това име и парола не е намерен!</p>';
                    }
            }
            else{
                    $error = true;
                    echo '<p class="error">Невалидни входни данни!</p>';
            }
    }
}
?>

<form method="POST">
	<table>
	<tr>
            <td><label for="username">Име:</label></td> 
            <td><input type="text" id="username" name="username" /></td></tr>
	<tr>
            <td><label for="password">Парола:</label></td> 
            <td><input type="password" id="password" name="pass" /></td></tr>
	<tr>
            <td colspan="2" style="text-align: right"><input type="submit" value="Вход" /></td></tr>
	<tr>
            <td colspan="2"><a href="register.php">Регистрация на нов потребител!!!!!!!!!!!!!</a></td></tr>
        </table>
</form>


<?php
include 'includes/footer.php';
?>