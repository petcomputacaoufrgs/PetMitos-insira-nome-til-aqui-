<?php
        // Configuration
        /*WEB Configuration
		$hostname = 'mysql.hostinger.com.br';
        $username = 'u751254083_adm';
        $password = 'Glds357!';
        $database = 'u751254083_devel';*/
		
		/*$hostname = 'mysql.hostinger.com.br';
        $username = 'u751254083_adm';
        $password = 'Glds357!';
        $database = 'u751254083_devel';
 
        $secretKey = "I8vjPJ9ke2"; // Change this value to match the value stored in the client javascript below 
 
        try {
            $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
        } catch(PDOException $e) {
            echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
        }
 
        $realHash = md5($_GET['name'] . $_GET['score'] . $secretKey); 
        if($realHash == $hash) { 
            $sth = $dbh->prepare('INSERT INTO scores VALUES (null, :name, :score)');
            try {
                $sth->execute($_GET);
            } catch(Exception $e) {
                echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
            }
        } */
		
		$hostname = 'localhost';
        $username = 'u751254083_adm';
        $password = 'Glds357!';
        $database = 'u751254083_devel';
		
		//mysql_host
        $db = mysql_connect($hostname, $username, $password) or die('Could not connect: ' . mysql_error()); 
        mysql_select_db($database) or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack. 
        $name = mysql_real_escape_string($_GET['name'], $db); 
        $score = mysql_real_escape_string($_GET['score'], $db); 
        $hash = $_GET['hash']; 
 
        $secretKey="mySecretKey"; # Change this value to match the value stored in the client javascript below 

        $real_hash = md5($name . $score . $secretKey); 
        if($real_hash == $hash) { 
            // Send variables for the MySQL database class. 
            $query = "insert into scores values (NULL, '$name', '$score');"; 
            $result = mysql_query($query) or die('Query failed: ' . mysql_error()); 
        } 
?>