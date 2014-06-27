<?php

function TweekPassword($pass, $username){
    // password logic here
    return md5(md5(strtolower($username)).$pass);
}
function getDoctors($DBconnection) {
    $query = mysqli_query($DBconnection, 'SELECT * FROM doctors');
    if (mysqli_error($DBconnection)) {
        return false;
    }
    $ret = [];
    while ($row = mysqli_fetch_assoc($query)) {
        $ret[$row['dr_id']]['name'] = $row['dr_name'];
        $ret[$row['dr_id']]['phone'] = $row['dr_phone'];
    }
    return $ret;
}

function getMedicine($DBconnection) {
    $query = mysqli_query($DBconnection, 'SELECT * FROM medicine');
    if (mysqli_error($DBconnection)) {
        return false;
    }
    $ret = [];
    while ($row = mysqli_fetch_assoc($query)) {
        $ret[$row['medicine_id']]['name'] = $row['medicine_name'];
        $ret[$row['medicine_id']]['company'] = $row['medicine_company'];
    }
    return $ret;
}

function CheckTrimString($input)
{
	$string = trim( $input );
	$string = stripslashes( $string );
	$string = htmlspecialchars( $string );
	return $string;
}