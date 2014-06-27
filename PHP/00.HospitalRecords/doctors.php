<?php
$pageTitle = 'Hospital Records - Doctors';

include 'includes/connectDB.php';
include 'includes/header.php';
include 'includes/functions.php';

if(isset($_POST['dr_name']) && isset($_POST['dr_phone']) ){
    $error = false;
    $dr_name = trim($_POST['dr_name']);
    $dr_phone = trim($_POST['dr_phone']);
    
    // validation
    $dr_name = htmlspecialchars($dr_name, ENT_QUOTES);
    $dr_phone = htmlspecialchars($dr_phone, ENT_QUOTES);

    if(mb_strlen($dr_name) < 5 || mb_strlen($dr_name) > 40){
            echo '<p class="error">The name should be between 5 and 40 characters long!</p>';
            $error = true; //error found
    }
    $phone = '000 0000 0000';
    $regex = '/^[0-9]{3}\W[0-9]{4}\W[0-9]{4}$/'; // simple :)
    if(!preg_match($regex, $dr_phone)) {
            echo '<p class="error">The phone should be in the format "'.$phone.'", only numbers!</p>';
            $error = true; //error found
    }
    
    if(!$error){
        // Database check if the username is free
        $sql = 'SELECT dr_name FROM doctors WHERE dr_name="'.$dr_name.'" AND dr_phone="'.$dr_phone.'"';
        $result = mysqli_query($DBconnection, $sql);
        var_dump($result);
        if ($result->num_rows > 0) {
            echo '<p class="error">Doctor "'.$dr_name.'" with phone "'.$dr_phone.'" already exists!</p>';
            $error = true;
        }
        else{
            $sql = 'INSERT INTO doctors (dr_id, dr_name, dr_phone) VALUES (NULL, "'.$dr_name.'", "'.$dr_phone.'");';
            if (mysqli_query($DBconnection, $sql)) {
                    header('Location: doctors.php');
                    exit;
            }
            else{
                echo '<p class="error">SQL error while trying to write the doctor in the database! Try again!</p>';
            }
        }
    }
}
?>

<form method="post" action="../doctors.php">
    Name: <input type="text" name="dr_name" />  </ br>
    Phone: <input type="text" name="dr_phone" />
    <input type="submit" value="Add" />    
</form>

<table class="table-dr">
    <tr>
        <th>Name</th>
        <th>Phone</th>
    </tr>
<?php
    $doctors = getDoctors($DBconnection);
    if (!($doctors === false)) {
        foreach ($doctors as $row) {
            echo '<tr><td>' . $row['name'] . '</td>'.
                     '<td>' . $row['phone'] . '</td></tr>';
        }
    }
?>
</table>

<?php
include 'includes/footer.php';
