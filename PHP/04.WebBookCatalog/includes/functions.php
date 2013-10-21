<?php

function GetBooks($SQL_result) {	
	$bookFound = array();
	while ( $row = mysqli_fetch_assoc( $SQL_result ) ) {
		$bookFound[$row['book_id']]['book'] = $row['book_title'];
		$bookFound[$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
	}
	return $bookFound;
}

function CheckTrimString($input)
{
	$string = trim( $input );
	$string = stripslashes( $string );
	$string = htmlspecialchars( $string );
	return $string;
}