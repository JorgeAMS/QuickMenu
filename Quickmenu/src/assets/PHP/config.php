<?php

$host= "localhost";
$user= "root";
$password= "";
$dbname= "databaseName";

$con= mysqli_connect($host, $user, $password, $dbname);
//check connectrion
if(!$con){
    die("Connection failed: ".mysqlu_connect_error());
}
?>