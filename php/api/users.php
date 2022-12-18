<?php

include("./db.php");

$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
	case "GET":
		if (!empty($_GET["username"]) && !empty($_GET["password"]) && checkAdminLoggedIn($_GET["username"], $_GET["password"])) {
			
			$users = getUsers();
			echo json_encode(array(
				"error" => 0,
				"users" => $users
			));
			
		}
		else 
		{	
			http_response_code(401);
			echo json_encode(array(
				"error" => 2,
				"message" => "You must log in as an admin to use this feature!")
			);
		}
		break;
	default:
		header('HTTP/1.1 405 Method Not Allowed');
		header('Allow: GET');
		break;
}

function getUsers() {
	global $con;
	
	$result = $con -> query("SELECT * FROM users");
	
	return $result->fetch_all(MYSQLI_ASSOC);
}


function checkAdminLoggedIn($u, $p) {
	global $con;
	
	$result = count($con -> query("SELECT * FROM users WHERE username = '$u' AND password = md5('$p') AND isAdmin = 1") -> fetch_all(MYSQLI_ASSOC));
	
	return $result != 0;
}

?>