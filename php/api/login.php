<?php

include("./db.php");
$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
	case "GET":
		if (!empty($_GET["username"]) && !empty($_GET["password"] && login($_GET["username"], $_GET["password"]))) {
			$response = array(
				"error" => 0,
				"message" => "Succesfully logged in!"
			);
			echo json_encode($response);
		}
		else {
			$response = array(
				'error'=> 1,
				'message'=> 'Enter a valid username and password!'
			);
			
			echo json_encode($response);
		}
		break;
	default:
		header('HTTP/1.1 405 Method Not Allowed');
		header('Allow: GET');
		break;
}

function login($u, $p) {
	global $con;
	
	$result = count($con -> query("SELECT * FROM users WHERE username = '$u' AND password = MD5('$p')") -> fetch_all());
	return $result > 0;
}


?>