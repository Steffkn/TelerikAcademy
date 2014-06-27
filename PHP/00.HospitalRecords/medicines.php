<?php
$pageTitle = 'Hospital Records - Medicines';

include 'includes/connectDB.php';
include 'includes/header.php';
include 'includes/functions.php';

if(isset($_POST['medicine_name']) && isset($_POST['medicine_company']) ){
    $error = false;
    $medicine_name = trim($_POST['medicine_name']);
    $medicine_company = trim($_POST['medicine_company']);
    
    // validation
    $medicine_name = htmlspecialchars($medicine_name, ENT_QUOTES);
    $medicine_company = htmlspecialchars($medicine_company, ENT_QUOTES);

    if(mb_strlen($medicine_name) < 5 || mb_strlen($medicine_name) > 40){
            echo '<p class="error">The medicine name should be between 5 and 40 characters long!</p>';
            $error = true; //error found
    }
    if(mb_strlen($medicine_company) < 5 || mb_strlen($medicine_company) > 40){
            echo '<p class="error">The company name should be between 5 and 40 characters long!</p>';
            $error = true; //error found
    }
    
    if(!$error){
        // Database check if the username is free
        $sql = 'SELECT medicine FROM medicine WHERE medicine_name="'.$medicine_name.'" AND medicine_company="'.$medicine_company.'"';
        $result = mysqli_query($DBconnection, $sql);
        var_dump($result);
        if ($result->num_rows > 0) {
            echo '<p class="error">Medicine "'.$medicine_name.'" from "'.$medicine_company.'" already exists!</p>';
            $error = true;
        }
        else{
            $sql = 'INSERT INTO medicine (medicine_id, medicine_name, medicine_company) VALUES (NULL, "'.$medicine_name.'", "'.$medicine_company.'");';
            if (mysqli_query($DBconnection, $sql)) {
                    header('Location: medicines.php');
                    exit;
            }
            else{
                echo '<p class="error">SQL error while trying to write the medicine in the database! Try again!</p>';
            }
        }
    }
}
?>

<form method="post" action="../medicines.php">
    Name: <input type="text" name="medicine_name" />  </ br>
    Company: <input type="text" name="medicine_company" />
    <input type="submit" value="Add" />    
</form>

<table class="table-med">
    <tr>
        <th>Name</th>
        <th>Phone</th>
    </tr>
<?php
    $medicines = getMedicine($DBconnection);
    if (!($medicines === false)) {
        foreach ($medicines as $row) {
            echo '<tr><td>' . $row['name'] . '</td>'.
                     '<td>' . $row['company'] . '</td></tr>';
        }
    }
?>
</table>

<?php
include 'includes/footer.php';
