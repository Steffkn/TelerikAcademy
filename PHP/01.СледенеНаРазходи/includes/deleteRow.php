<?php
function DeleteChecked(){
	$filePath = "./data.txt";
	$toDelete = $_POST['checkbox'];
	$data = file($filePath);
	$out = array();
	foreach($data as $line) 
	{
		$write = true;
		for ($i=0; $i<sizeof($toDelete); $i++) {

			if(trim($line) == trim($toDelete[$i]) ) 
			{
				$write = false;
				unset($toDelete[$i]);
				$toDelete = array_values($toDelete);
				break;
			}
		}
		if($write)
		{
			$out[] = $line;
		}
	}
	if(file_exists($filePath))
	{
		$fp = fopen($filePath, "w+");
		flock($fp, LOCK_EX);
		foreach($out as $line) 
		{
			fwrite($fp, $line);
		}
		flock($fp, LOCK_UN);
		fclose($fp); 
	}
}
?>