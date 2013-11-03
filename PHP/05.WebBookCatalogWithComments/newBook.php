<?php
$pageTitle = 'Нов автор';

include 'includes/connectDB.php';
include 'includes/header.php';
include 'includes/functions.php';

if ($_POST) {

    $bookName = trim($_POST['book_name']);
    if (!isset($_POST['authors'])) {
        $_POST['authors'] = '';
    }
    $authors = $_POST['authors'];
    $errorArray = [];
    if (mb_strlen($bookName) < 2) {
        $errorArray[] = 'Името е прекалено късо!';
    }
    if (!is_array($authors) || count($authors) == 0) {
        $errorArray[] = 'Невалидни автори!';
    }

    if (count($errorArray) > 0) {
        foreach ($errorArray as $explanation) {
            echo '<p class="error">' . $explanation . '</p>';
        }
    } 
    else {
        $sql = 'INSERT INTO books (book_title) VALUES("' .
                mysqli_real_escape_string($DBconnection, $bookName) . '")';
        mysqli_query($DBconnection, $sql);
        if (mysqli_error($DBconnection)) {
            echo '<p class="error">Грешка</p>';
        }
        else{
            // take the last inserted ID
            $lastID = mysqli_insert_id($DBconnection);
            foreach ($authors as $authorId) {
                mysqli_query($DBconnection, 'INSERT INTO books_authors (book_id,author_id)
                    VALUES (' . $lastID . ',' . $authorId . ')');
                if (mysqli_error($DBconnection)) {
                    echo 'Error';
                    echo mysqli_error($DBconnection);
                    exit;
                }
            }
            echo '<p class="correct">Книгата е добавена</p>';
        }
        
    }
}
?>

<form method="POST" action="newBook.php">
    <label>Книга:</label> <input type="text" name="book_name" />

    <?php
    $authors = GetAuthors($DBconnection);
    if ($authors === false) {
        echo '<p class="error">Грешка с авторите</p>';
        ///TODO        
    }
    ?>
    <div>
        <label>Автори:</label>
    <br/>
        <select name="authors[]" multiple style="width: 200px">
            <?php
            foreach ($authors as $row) {
                echo '<option value="' . $row['author_id'] . '">
                    ' . $row['author_name'] . '</option>';
                }
            ?>
        </select>
    </div>
    <input type="submit" value="Добави книгата" />    
</form>

<?php
    include 'includes/footer.php';
?>