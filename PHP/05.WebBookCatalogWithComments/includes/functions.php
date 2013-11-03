<?php

function GetAuthors($SQL_DB){
    $query = mysqli_query($SQL_DB, 'SELECT * FROM authors');
    if (mysqli_error($SQL_DB)) {
        return false;
    }
    $allAuthors = [];
    while ($row = mysqli_fetch_assoc($query)) {
        $allAuthors[] = $row;
    }
    return $allAuthors;
}

function GetBooks($SQL_result) {	
	$bookFound = array();
	while ( $row = mysqli_fetch_assoc( $SQL_result ) ) {
            $dataRows[$row['book_id']]['book_title'] = $row['book_title'];
            $dataRows[$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
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