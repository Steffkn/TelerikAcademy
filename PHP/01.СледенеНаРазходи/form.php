<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Форма';
include 'includes/header.php';

if($_POST){
	// trim and take the name
    $expense = trim($_POST['expense']);
    $expense = str_replace('!', '', $expense);
	
	// take the cost
    $cost = (float)$_POST['cost'];
	
	// take the index of the selected type
    $selectedGroup = (int)$_POST['group'];
	
	// error index
    $error=false;
	
	// check if the name is less than 3 symbols
    if(mb_strlen($expense)<3){
	// боб..
        echo '<p>Името е прекалено късо</p>';
        $error = true; //error found
    }
    
	// if the cost is a negative number
    if($cost < 0){
        echo '<p>Цената не може да е отрицателна</p>';
        $error = true; //error found
    }    
	// if the selected index of the drop down exists
    if(!array_key_exists($selectedGroup, $groups)){
        echo '<p>невалидна група</p>';
        $error = true; //error found
    }
    // if no error us found
    if(!$error){
		//make a row of data
        $result = date("m.d.Y").'!'.$expense.'!'.$cost.'!'.$selectedGroup."\n";
        // and add it to the file data.txt
		if(file_put_contents('data.txt', $result, FILE_APPEND))
        {
			// tell the user that the data is writen
            echo 'Записа е успешен!<br>';
        }
    }
    
    
}
?>

<!-- Link for the main page -->
<a href="index.php">Списък</a>

<!-- Link for the add form -->
<form method="POST">
    <div>Име:<input type="text" name="expense" /></div>
    <div>Сума:<input type="text" name="cost" /></div>
    <div>Разход: 
        <select name="group">
            <?php
            foreach ($groups as $key=>$value) {
                echo '<option value="'.$key.'">' . $value .
                        '</option>';
            }
            ?>
        </select>           
    </div>        
    <div><input type="submit" value="Добави" /></div>
</form>
<?php
include 'includes/footer.php';
?>