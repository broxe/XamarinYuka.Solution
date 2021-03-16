<?php

//  Partie pour chargement des données
if(!empty($_POST["send"])) 
{
	$code = $_POST["code"];
	$name = $_POST["name"];
	$score = $_POST["score"];
	$state = $_POST["state"];
	$image = rand(1, 9999999);//$_POST["imagenom"];
	$champ1 = $_POST["champ10"].";".$_POST["champ11"];
	$champ2 = $_POST["champ20"].";".$_POST["champ21"];
	$champ3 = $_POST["champ30"].";".$_POST["champ31"];
	$champ4 = $_POST["champ40"].";".$_POST["champ41"];
	$champ5 = $_POST["champ50"].";".$_POST["champ51"];
	$champ6 = $_POST["champ60"].";".$_POST["champ61"];

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
		$stringFormat = "INSERT INTO tb_ProductInformation (pr_code, pr_name, pr_score, pr_state, pr_image, pr_champ1, pr_champ2, pr_champ3, pr_champ4, pr_champ5, pr_champ6) VALUES ('" . $code. "', '" . $name. "'," . $score. ",'" . $state. "', '" . $image. "','" . $champ1. "', '" . $champ2. "','" . $champ3. "','" . $champ4. "','" . $champ5. "','" . $champ6. "')";
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
?>