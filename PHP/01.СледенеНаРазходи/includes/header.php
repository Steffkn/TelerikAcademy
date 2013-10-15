<?php
require 'constants.php';
?>
<!DOCTYPE html>
<html >
    <head>
        <title><?= $pageTitle;?></title>
		<!-- give the encoding -->
        <meta charset="UTF-8"> 
		
		<!-- script for the selectAll checkbox-->
		<script language='JavaScript'>
		checked = false;
		function checkedAll () {
			if (checked == false){checked = true}
			else{checked = false}
			// loop trough the elements in the form with id "razhodi"
			for (var i = 0; i < document.getElementById('razhodi').elements.length; i++) {
				// if the name of the element is checkbox[]
				if(document.getElementById('razhodi').elements[i].name == 'checkbox[]'){
					// set the checked option of the checkbox to 'çhecked'
					document.getElementById('razhodi').elements[i].checked = checked;
				}
			}
		}
		</script>		
    </head>
    <body>