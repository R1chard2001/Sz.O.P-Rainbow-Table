<?php


function checkLoggedIn($u, $p) {
	global $con;
	
	$result = count($con -> query("SELECT * FROM users WHERE username = '$u' AND password = md5('$p')") -> fetch_all(MYSQLI_ASSOC));
	
	return $result != 0;
}


?>