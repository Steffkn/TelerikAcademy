<a href="index.php">Списък</a>
<form method="post" action="../add_book.php">
    Име: <input type="text" name="book_name" />
    <div>Автори:<br/> 
        <select name="authors[]" multiple style="width: 200px">
            <?php
            foreach ($data['authors'] as $key => $row) {
                echo '<option value="' . $key . '">
                    ' . $row . '</option>';
            }
            ?>
        </select></div>
    <input type="submit" value="Добави" />    
</form>

<?php
// знам че тук има логика.. вупросът е как да се направи отделно грешката от успешните опити
// ако се махне проверката ще се трушка за това, че не знае какво е $data['notifications']
// общо взето се казва.. печатай ако има
//echo '<pre>'.print_r($data['notifications']['error'], true).'</pre>';
//echo '<pre>'.print_r(count($data['notifications']['error']), true).'</pre>';

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