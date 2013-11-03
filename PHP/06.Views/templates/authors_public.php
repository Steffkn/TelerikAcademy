<a href="index.php">Списък</a>
<a href="add_book.php">Нова книга</a>
<form method="post" action="../authors.php">
    Име: <input type="text" name="author_name" />
    <input type="submit" value="Добави" />    
</form>

<?php
// знам че тук има логика.. вупросът е как да се направи отделно грешката от успешните опити
// ако се махне проверката ще се трушка за това, че не знае какво е $data['notifications']
// общо взето се казва.. печатай ако има
    if (isset($data['notifications']['error']) && count($data['notifications']['error']) > 0) {
         echo '<div class="error"> ';
        foreach ($data['notifications']['error'] as $error) {
            echo '<p>- '.$error.'</p>';
        }
        echo '</ul></div>';
    }
    if (isset($data['notifications']['success'])) {
         echo '<div class="success"> ';
        foreach ($data['notifications']['success'] as $success) {
            echo '<p>- '.$success.'</p>';
        }
        echo '</ul></div>';
    }
?>

<table border='1'>
    <tr><th>Автор</th></tr>

    <?php
    foreach ($data['authors'] as $row) {
        echo '<tr><td>' . $row . '</td></tr>';
    }
    ?>
</table>