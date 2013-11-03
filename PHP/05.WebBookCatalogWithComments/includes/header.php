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
	<!-- Много просто меню -->
	<nav style="margin: 10px 10px 10px 0">
        <a href="index.php" style="margin: 10px 10px 10px 0">Всички книги</a>
        <a href="newBook.php" style="margin: 10px 10px 10px 0">Добави нова книга</a>
        <a href="newAuthor.php" style="margin: 10px 10px 10px 0">Добави нов автор</a>
        <?php
            if(isset($_SESSION['isLogged']) == true){
            $logged = "Здравей, " . $_SESSION['username'] . "!";
            // gavra .. ne se seshtam za drug metod
            echo '<a href="logIn.php" style="margin: 10px 10px 10px 0">'.$logged.'</a>';
            echo '</a><a href="logOut.php" style="margin: 10px 10px 10px 0">Изход</a>';
            }
            else{
                echo '<a href="logIn.php" style="margin: 10px 10px 10px 0">Вход</a>';
            }
        ?>
	</nav>