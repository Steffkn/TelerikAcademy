<?php
$pageTitle = 'Нов автор';

include 'includes/connectDB.php';
include 'includes/header.php';
include 'includes/functions.php';

if(isset($_POST['author_name']))
{
    $author = CheckTrimString($_POST['author_name']);
    if (mb_strlen($author) < 2) {
        echo '<p class="error">Невалидно име!</p>';
    } 
    else {
        $sql = 'SELECT * FROM authors 
            WHERE author_name="' . mysqli_real_escape_string($DBconnection, $author) . '"';
        
        $query = mysqli_query($DBconnection, $sql);
        if (mysqli_error($DBconnection)) {
            echo '<p class="error">Грешка</p>';
        }
        if (mysqli_num_rows($query) > 0) {
            echo '<p class="error">Този автор съществува</p>';
        } 
        else {
            $sql ='INSERT INTO authors (author_name)
                VALUES("' . mysqli_real_escape_string($DBconnection, $author) . '")';
            mysqli_query($DBconnection, $sql);
            if (mysqli_error($DBconnection)) {
                echo '<p class="error">Грешка</p>';
            } 
            else {
                echo '<p class="correct">Записът е направен успешно!</p>';
            }
        }
    }
}
?>

<form method="POST" action="newAuthor.php">
    <label>Автор: </label>
    <input type="text" name="author_name"/>
    <input type="submit" name="submitAuthor" value="Добави!"/>  
</form>



<?php
    $allAuthors = GetAuthors($DBconnection);
    if ($allAuthors === false) {
        echo '<p class="error">Грешка</p>';
    }         
    echo '<table><tr><th> Автори </th></tr>';
    foreach ($allAuthors as $row) {
        echo '<tr><td><a href="index.php?author_id=' . $row['author_id'] . '">' . $row['author_name'] . '</a></td></tr>';
    }
    echo "</table>";
?>


<?php
include 'includes/footer.php';
?>