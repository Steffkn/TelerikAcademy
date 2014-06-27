<?php
	mb_internal_encoding('UTF-8');
?>
<!DOCTYPE html>
<html>
    <head>
        <title><?= $pageTitle;?></title>
        <meta charset="UTF-8">  
        
    <style>
    #comments
    {
    border-collapse:collapse;
    }
    #comments td
    {
    border:1px solid black;
    padding: 5px;
    
    }
    .table-dr, .table-med{
        border-spacing: 0;
        border-collapse: collapse;
    }
    .table-dr td, .table-dr th, .table-med td, .table-med th{
        padding: 0 10px;
        border: 1px solid black;
    }
    .error 
    {
        text-align: center;
        color: crimson;
        background-color: lightpink;
        border: solid red thin;
    }
    .correct 
    {
        text-align: center;
        color: green;
        // ако не бързах можеше и по добре да е :)
        background-color: lightgreen;
        border: solid green thin;
    }
    </style>        
    
    </head>
    <body>
	<!-- Simple menu -->
	<nav style="margin: 10px 10px 10px 0">
        <a href="index.php" style="margin: 10px 10px 10px 0">Overview</a>
        <a href="doctors.php" style="margin: 10px 10px 10px 0">Doctors</a>
        <a href="medicines.php" style="margin: 10px 10px 10px 0">Medicines</a>
        <?php
            if(isset($_SESSION['isLogged']) == true){
            $logged = "Hello, " . $_SESSION['username'] . "!";
            // gavra .. ne se seshtam za drug metod
            echo '<a href="index.php" style="margin: 10px 10px 10px 0">'.$logged.'</a>';
            echo '</a><a href="logOut.php" style="margin: 10px 10px 10px 0">Exit</a>';
            }
            else{
                echo '<a href="logIn.php" style="margin: 10px 10px 10px 0">Log in</a>';
            }
        ?>
	</nav>