<?php
$pageTitle='Списък';

include 'includes/header.php';
include 'includes/date_picher.php';
include 'includes/deleteRow.php';

$selected = 0;
$date = "no";
if($_POST){

	if(isset($_POST['filter'])){
		// take the selected 
		$selected = (int)$_POST['group'];
	}
	else if(isset($_POST['delete'])){
	
		if(isset($_POST['checkbox'])){
			// delete the items that are checked
			DeleteChecked();
		}
	}

	// take the month, day and year from the drop downs
	$selMonth = $_POST['filterMonth'];
	$selDay = $_POST['filterDay'];
	$selYear = $_POST['filterYear'];
	
	// check if there is a date with these parameters
	if (checkdate($selMonth, $selDay, $selYear))
	{
		// if the checkbox for the date is checked
		if(isset($_POST['sort_by_date']))
		{
			// give the $date parameter the selected date
			$date = date("m.d.Y" , mktime(0, 0, 0, $selMonth,  $selDay, $selYear));
		}
		// if its not checked
		else
		{
		// a sign "no" to the $date
			$date = "no";
		}
	}
	// if the date is not a valid date (30.02)
	else
	{
		// tell this to the user
		echo 'Невалидна дата!<br>';
	}
}
?>
<!-- Link for the add form -->
<a href="form.php">Добавяне на разход</a><br>

<!-- main form -->
<form method="POST" id="razhodi">

	<label>Филтриране по дата?</label>
	<!-- checkbox for the sorting by date -->
	<input type="checkbox" value="yes" name="sort_by_date" id="sort" checked="checked"/>
	<?php 
		// print the date drop downs (nameOfForm , starting year, end year)
		echo date_picker("filter",2000,2038);
	?>
	<div>
	
	<!-- drop down for the type of expense -->
		<select name="group">
            <?php
			// adding the all option for the drop down
			$groups[0] = 'Всички';
			// loop trough the elements
            foreach ($groups as $key=>$value) {
				if($key == $selected)
				{
					echo '<option value="'.$key.'" selected="selected">' . $value .
							'</option>';
				}
				else
				{
					echo '<option value="'.$key.'">' . $value .
							'</option>';
				}
			}
            ?>
		</select>
		<input type="submit" name="filter" value="Филтрирай" />
		<input type="submit" name="delete" value="Изтрий" />
	</div>

	<!-- main table-->
	<table border="1" id="content">
		<thead>
			<tr>
				<!-- checkbox for 'checkAll/uncheckAll'-->
				<th><input type='checkbox' name='checkall' onclick='checkedAll();'></th>
				<th>Дата(mm.dd.yyyy)</th>
				<th>Име</th>
				<th>Сума</th>
				<th>Вид</th>
			</tr>
		</thead>
		<tbody>
		<?php
			// check if the file exists
			if(file_exists('data.txt'))
			{
				// add everything from the file to $result
				$result = file('data.txt');
				$sum = 0;
				// if date equals "no", then sorting by date is disabled
				if($date == "no")
				{
					// loop trough the lines in the result
					foreach ($result as $value) {
						// separate the colums by '!'
						$columns =  explode('!', $value);
						// if a matching type is found (as selected)
						if(trim($columns[3]) == $selected || $selected == 0)
						{
							// add a the row
							echo '<tr>
							<td><input type="checkbox" value="'. $value .'" name="checkbox[]"/></td>
									<td>'.$columns[0].'</td>
									<td>'.$columns[1].'</td>
									<td>'.$columns[2].'</td>
									<td>'.$groups[trim($columns[3])].'</td>
								</tr>';
								// add the price to the sum
								$sum += $columns[2];
						}
					}
				}
				// if date contains other than "no" then a date is set and we will filter by date too
				else{
					// loop trough the elements in the line
					foreach ($result as $value) {
						// take the elements of the line
						$columns =  explode('!', $value);
						// if the first column is equal to the given date
						if($date == $columns[0] && (trim($columns[3]) == $selected || $selected == 0))
						{
							// add this row 
							echo '<tr>
							<td><input type="checkbox" value="'. $value .'" name="checkbox[]"/></td>
									<td>'.$columns[0].'</td>
									<td>'.$columns[1].'</td>
									<td>'.$columns[2].'</td>
									<td>'.$groups[trim($columns[3])].'</td>
								</tr>';
								// add the price to the sum
								$sum += $columns[2];
						}
					}
				}
				
			}
		?>

		</tbody>
		<tfoot>
		<?php
		// add the last row with the sum of the selected elements
			echo '<tr>
						<td> ---- </td>
						<td> ---- </td>
						<td> ---- </td>
						<td>'.$sum.'</td>
						<td> ---- </td>
					</tr>';
		?>
		
		</tfoot>
	</table>

</form>
<?php
include 'includes/footer.php';
?>