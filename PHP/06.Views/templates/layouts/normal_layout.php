<!DOCTYPE html>
<html>
    <head>
        <title><?= $data['title']; ?></title>
        <meta charset="UTF-8">       
        <link href="./templates/CSS/default_style.css" rel="stylesheet" type="text/css">
    </head>
    <body>
        <div id="wrap">
            <header>
                <?php
                include $data['header'];
                ?>
            </header>

            <div id="content">
                <?php
                include $data['content'];
                ?>
            </div>

            <footer>
                <?php
                include $data['footer'];
                ?>
            </footer>
        </div>
    </body>
</html>