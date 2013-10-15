<?php
	$pageTitle = 'Форма';
	include 'includes/header.php';
	
	$username = trim(file_get_contents('temp'.DIRECTORY_SEPARATOR.'current.tmp'));
	$dir = 'userdb'.DIRECTORY_SEPARATOR.$username.DIRECTORY_SEPARATOR;
	$files = scandir($dir);
	
	function filesize_formatted($size)
	{
	$units = array( 'B', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB');
	$power = $size > 0 ? floor(log($size, 1024)) : 0;
	//($size * .0009765625) * .0009765625
	return number_format($size / pow(1024, $power), 2, '.', ',') . ' ' . $units[$power];
	}
?>
<a href="logOut.php">Изход</a> <br />
<a href="upload.php">Качи нов файл!</a>
<table border="1">
	<tr>
		<th>File name</th>
		<th>File size</th>
	</tr>
	<?php
 
		foreach($files as $key=>$file)
		{
			if($file != '.' && $file != '..')
			{
				echo 	'<tr> 
							<td><a href="userdb/'.$username.'/'.$file.'" download>'.$file.' </a></td>
							<td>'.filesize_formatted(filesize(dirname(__FILE__).DIRECTORY_SEPARATOR.$dir.$file)).'</td>
						</tr>';
			}
		}
	?>
</table>
<?php
include 'includes/footer.php';
?>