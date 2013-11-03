<!DOCTYPE html>
<html>
    <head>
        <title><?= $data['title']; ?></title>
        <meta charset="UTF-8">       
    </head>
    <body>
        <div style="border: 1px solid red">
            <?php
            include $data['content'];
            ?>
        </div>
    </body>
</html>