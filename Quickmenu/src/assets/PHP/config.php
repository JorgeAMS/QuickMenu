<?php

$host= "localhost";
$user= "root";
$password= "";
$dbname= "bd";

$con= mysqli_connect($host, $user, $password, $dbname);
//check connection
if(!$con){
    die("Connection failed: ".mysqlu_connect_error());
}
?>