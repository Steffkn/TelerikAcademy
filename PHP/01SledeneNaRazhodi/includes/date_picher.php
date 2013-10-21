<?php
	function date_picker($name, $startyear = NULL, $endyear = NULL)
	{
		if($startyear == NULL) { $startyear = date("Y")-50; }
		if($endyear == NULL) { $endyear = date("Y")+50; }
		
		// Month dropdown
		$html="<select name=\"".$name."Month\">";
		for($i = 1; $i <= 12; $i++)
		{
			$month = date("m", mktime(0, 0, 0, $i, 1, 0));
			if($i == date("m"))
			{
				$html.='<option value='.$month.' selected="selected">'.$month.'</option>';
			}
			else
			{
				$html.='<option value='.$month.'>'.$month.'</option>';
			}
		}
		$html.="</select> ";
	   
		// Day dropdown
		$html.="<select name=\"".$name."Day\">";
		for($i = 1; $i <= 31; $i++)
		{
			$day = date("d", mktime(0, 0, 0, 1, $i, 0));
			if($i == date("d"))
			{
				$html.='<option value='.$day.' selected="selected">'.$day.'</option>';
			}
			else
			{
				$html.='<option value='.$day.'>'.$day.'</option>';
			}
		}
		$html.="</select> ";

		// Year dropdown
		$html.="<select name=\"".$name."Year\">";
		for($i = $startyear; $i <= $endyear; $i++)
		{      
			$year = date("Y", mktime(0, 0, 0, 1, 1, $i));
			if($i == date("Y"))
			{
				$html.='<option value='.$year.' selected="selected">'.$year.'</option>';
			}
			else
			{
				$html.='<option value='.$year.'>'.$year.'</option>';
			}
		}
		$html.="</select> ";

		return $html;
	}

?>