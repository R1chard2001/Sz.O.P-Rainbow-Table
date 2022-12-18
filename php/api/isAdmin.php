<?php

include("./db.php");
$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
	case "GET":
		if (!empty($_GET["username"]) && !empty($_GET["password"])) {
			$result = 0;
			if (isAdmin($_GET["username"], $_GET["password"])) {
				$result = 1;
			}
			$response = array(
				"error" => 0,
				"isAdmin" => $result
			);
			echo json_encode($response);
		}
		else {
			$response = array(
				'error'=> 1,
				'message'=> 'Username and/or password not specified!'
			);
			
			echo json_encode($response);
		}
		break;
	default:
		header('HTTP/1.1 405 Method Not Allowed');
		header('Allow: GET');
		break;
}

function isAdmin($u, $p) {
	global $con;
	
	$result = count($con -> query("SELECT * FROM users WHERE username = '$u' and password = md5('$p') and isAdmin = 1") -> fetch_all());
	return $result > 0;
}


?>