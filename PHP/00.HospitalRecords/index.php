<?php
$pageTitle = 'Hospital Records Main';

include 'includes/connectDB.php';
include 'includes/header.php';
include 'includes/functions.php';

if(isset($_SESSION['isLogged']) == false){
    header('Location: logIn.php');
    exit;
}
else
{
    $doctors =  getDoctors($DBconnection);
}
?>

<div>Doctors:<br/> 
<form method="post" action="../index.php">
        <select name="doctors[]" multiple style="width: 200px">
            <?php
            foreach ($doctors as $key => $row) {
                echo '<option value="' . $key . '">
                    ' . $row['name'] . '</option>';
            }
            ?>
        </select>
    <input type="submit" value="Add DR" />    
</form>
</div>
<?php

include 'includes/footer.php';