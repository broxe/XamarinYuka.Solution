<?php

	$vlogText = $_POST["logText"];
	if(!empty($vlogText)) 
	{
		$host_name = 'db5001835863.hosting-data.io';
  		$database = 'dbs1510202';
  		$user_name = 'dbu1364718';
  		$password = 'Humidity@456';

		$connexion = mysqli_connect($host_name, $user_name, $password, $database);
		if (!$connexion) 
		{
			echo "Erreur de connexion " . mysql_error();
			die ("Erreur de connexion: " . mysql_error());
		}
		else {
			$stringFormat = "INSERT INTO tb_Log (log) VALUES ('" . $vlogText. "')";
			echo $stringFormat;
			$result = mysqli_query($connexion, $stringFormat);

			if($result)
			{
				$db_msg = "Vos informations de contact sont enregistrées avec succés.";
				$type_db_msg = "success";
			}
			else
			{
				$db_msg = "Erreur lors de la tentative d'enregistrement de contact.";
				$type_db_msg = "error";
			}
		}
	}
	else
	{
		http_response_code(400);
	}
	
?>