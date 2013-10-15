<?php
$pageTitle = 'Качи файл!';
include 'includes/header.php';

$username = trim(file_get_contents('temp'.DIRECTORY_SEPARATOR.'current.tmp'));

	if($_FILES){
		if(move_uploaded_file($_FILES['uploadFile']['tmp_name'], 
		'userdb'.DIRECTORY_SEPARATOR.$username.DIRECTORY_SEPARATOR.$_FILES['uploadFile']['name']))
		{
			echo 'Файлът е качен успешно!';
		}
		else
		{
			echo 'Грешка при качванетп на файла!';
		}
	}

?>

<a href="logOut.php">Изход</a> <br />
<a href="files.php">Списък с вашите файловете!</a>

<form method="POST" enctype="multipart/form-data">
	<div><input type="file" name="uploadFile" /></div>
	<div><input type="submit" value="Качи!" /></div>
</form>

<?php
include 'includes/footer.php';
?>
