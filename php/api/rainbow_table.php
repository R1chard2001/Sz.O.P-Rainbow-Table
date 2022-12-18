<?php

include("./db.php");
include("./common.php");


$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
	case "GET":
		if (empty($_GET["filter"])) {
			$hashes = getAllEntry();
			echo json_encode($hashes);
		}
		else {
			$hashes = getEntries($_GET["filter"]);
			echo json_encode($hashes);
		}
		break;
	default:
		header('HTTP/1.1 405 Method Not Allowed');
		header('Allow: GET');
		break;
}



function getAllEntry() {
	global $con;
	$result = $con -> query("SELECT * FROM rainbow_table")->fetch_all(MYSQLI_ASSOC);
	if (count($result) == 0) {

		return array(
			"error" => 0,
			"message" => 'Success',
			"entries" => []
		);
	}
	else {
		return array(
			"error" => 0,
			"message" => 'Success',
			"entries" => $result
		);
	}
}

function getEntries($filter) {
	global $con;
	$result = $con -> query("SELECT * FROM rainbow_table WHERE passwd = '$filter' OR md5 = '$filter' OR sha1 = '$filter' OR sha256 = '$filter'")->fetch_all(MYSQLI_ASSOC);
	if (count($result) == 0) {

		return array(
			"error" => 0,
			"message" => 'Success',
			"entries" => []
		);
	}
	else {
		return array(
			"error" => 0,
			"message" => 'Success',
			"entries" => $result
		);
	}
}

?>