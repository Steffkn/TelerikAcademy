<a href="../authors.php">Автори</a>
<a href="../add_book.php">Нова книга</a>
<table border="1">
    <thead>
        <th>Книга</th>
        <th>Автори</th>
    </thead>
    <tbody>
        <?php
            foreach ($data['books'] as $row) {
                echo '<tr><td>' . $row['book_title'] . '</td>
                    <td>';
                $ar = array();
                foreach ($row['authors'] as $k => $va) {
                    $ar[] = '<a href="index.php?author_id=' . $k . '">' . $va . '</a>';
                }
                echo implode(' , ', $ar) . '</td></tr>';
            }
        ?>
    </tbody>
</table>