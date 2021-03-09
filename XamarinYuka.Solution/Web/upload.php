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

//  Partie pour traitement image
$target_dir = "img/";
$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
$uploadOk = 1;
$imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));
$target_file = $target_dir . rand(1,20).".".$imageFileType;

// Check if image file is a actual image or fake image
if(isset($_POST["submit"])) {
  $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]);
  if($check !== false) {
    echo "File is an image - " . $check["mime"] . ".";
    $uploadOk = 1;
  } else {
    echo "File is not an image.";
    $uploadOk = 0;
  }
}

// Check if file already exists
if (file_exists($target_file)) {
  echo "Sorry, file already exists.";
  $uploadOk = 0;
}

// Check file size
if ($_FILES["fileToUpload"]["size"] > 500000) {
  echo "Sorry, your file is too large.";
  $uploadOk = 0;
}

// Allow certain file formats
if($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg"
&& $imageFileType != "gif" ) {
  echo "Sorry, only JPG, JPEG, PNG & GIF files are allowed.";
  $uploadOk = 0;
}

// Check if $uploadOk is set to 0 by an error
if ($uploadOk == 0) {
  echo "Sorry, your file was not uploaded.";
// if everything is ok, try to upload file
} else {
  if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)) {
    echo "The file ". htmlspecialchars( basename( $_FILES["fileToUpload"]["name"])). " has been uploaded.";
  } else {
    echo "Sorry, there was an error uploading your file.";
  }
}
?>
