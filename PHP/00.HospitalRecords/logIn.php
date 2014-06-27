<?php
$pageTitle='Log in';

include 'includes/connectDB.php';
include 'includes/functions.php';
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
            
            // validation
            $username = htmlspecialchars($username, ENT_QUOTES);
            $pass = htmlspecialchars($pass, ENT_QUOTES);

            if(mb_strlen($username) < 5 || mb_strlen($username) > 40){
                    echo '<p class="error">The name should be between 5 and 40 characters long!</p>';
                    $error = true; //error found
            }	
            if(mb_strlen($pass) < 5 || mb_strlen($pass) > 20){
                    echo '<p class="error">The password should be between 5 and 20 characters long!</p>';
                    $error = true; //error found
            }
            
            if(!$error){
                // Database check if the username is free
                $sql = 'SELECT user_name FROM users WHERE user_name="'.$username.'"';
                $result = mysqli_query($DBconnection, $sql);
                if ($result->num_rows == 0) {
                    $error = true;
                    echo '<p class="error">User "'.$username.'" not found! :(</p>';	
                }
                else{
                    $tweekedPass = TweekPassword($pass, $username);
                    $sql = 'SELECT * FROM users WHERE user_name="'.$username.'" AND user_pass="'.$tweekedPass.'"';
                    $result = mysqli_query($DBconnection, $sql);
                    if ($result->num_rows > 0) {
                            $row = $result->fetch_assoc();
                            $_SESSION['username'] = $row['user_name'];
                            $_SESSION['user_id'] = $row['user_id'];
                            $_SESSION['isLogged'] = true;

                            header('Location: index.php');
                            exit;
                    }
                    else
                    {
                        $error = true;
                        echo '<p class="error">Password incorrect!</p>';
                    }
                }
            }
            else{
                    $error = true;
                    echo '<p class="error">Invalid log in information!</p>';
            }
    }
}
?>

<form method="POST">
	<table>
	<tr>
            <td><label for="username">Name:</label></td> 
            <td><input type="text" id="username" name="username" /></td></tr>
	<tr>
            <td><label for="password">Password:</label></td> 
            <td><input type="password" id="password" name="pass" /></td></tr>
	<tr>
            <td colspan="2" style="text-align: right"><input type="submit" value="Вход" /></td></tr>
	<tr>
            <td colspan="2"><a href="register.php">Register new user!</a></td></tr>
        </table>
</form>


<?php
include 'includes/footer.php';