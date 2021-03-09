<?php

//l'envoie du mail
/*
if(!empty($_POST["send"])) {
	$name = $_POST["name"];
	$email = $_POST["email"];
	$subject = $_POST["subject"];
	$message = $_POST["message"];

	$toEmail = "VotreAdresse@gmail.com";
	$mailHeaders = "From: " . $name . "<". $email .">\r\n";
	if(mail($toEmail, $subject, $message, $mailHeaders)) {
	    $mail_msg = "Vos informations de contact ont été reçues avec succés.";
		$type_mail_msg = "success";
	}else{
		$mail_msg = "Erreur lors de l'envoi de l'e-mail.";
		$type_mail_msg = "error";
	}
}*/
?>


<html>
	<head>
		<title>Product informations</title>
		<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
		<link rel="stylesheet" href="styleGlobal.css" />
		<script type="text/javascript" src="contact.js"></script>
	</head>
	<body>
		<div id="box">
		  <form id="form" enctype="multipart/form-data" action="upload.php" method="post">
		    <h3>Formulaire de contact</h3>
		    <div>
		    	<label>Code : <span>*</span></label>
		    	<input type="text" id="code" name="code" placeholder="Entrez le code"/>	
		    </div>
		    <div>
		    	<label>Name : <span>*</span></label><span id="info" class="info"></span>
		    	<input type="text" id="name" name="name" placeholder="Entrez le nom"/>	
		    </div>
		    <div>
		    	<label>Score : <span>*</span></label>
		    	<input type="text" id="score" name="score" placeholder="Entrez le score"/>
		    </div>
		    <div>
		    	<label>State :</label>
		    	<input type="text" id="state" name="state" placeholder="Entrz statut"/>
		    </div>
		    <div>
		    	<label>Image :</label>
				<input type="file" name="fileToUpload" id="fileToUpload">
		    </div>
		    <div>
		    	<label>champ 1 :</label>
		    	<input type="text" id="champ10" name="champ10" placeholder="Entrez le nom du champ1"/>
		    	<input type="text" id="champ11" name="champ11" placeholder="Entrez la valeur champ1"/>
		    </div>
		    <div>
		    	<label>champ 2:</label>
		    	<input type="text" id="champ20" name="champ20" placeholder="Entrez le nom du champ2"/>
		    	<input type="text" id="champ21" name="champ21" placeholder="Entrez la valeur champ2"/>
		    </div>
		    <div>
		    	<label>champ 3:</label>
		    	<input type="text" id="champ30" name="champ30" placeholder="Entrez le nom du champ3"/>
		    	<input type="text" id="champ31" name="champ31" placeholder="Entrez la valeur champ3"/>
		    </div>
		    <div>
		    	<label>champ 4:</label>
		    	<input type="text" id="champ40" name="champ40" placeholder="Entrez le nom du champ4"/>
		    	<input type="text" id="champ41" name="champ41" placeholder="Entrez la valeur champ4"/>
		    </div>
		    <div>
		    	<label>champ 5:</label>
		    	<input type="text" id="champ50" name="champ50" placeholder="Entrez le nom du champ5"/>
		    	<input type="text" id="champ51" name="champ51" placeholder="Entrez la valeur champ5"/>
		    </div>
		    <div>
		    	<label>champ 6:</label>
		    	<input type="text" id="champ60" name="champ60" placeholder="Entrez le nom du champ6"/>
		    	<input type="text" id="champ61" name="champ61" placeholder="Entrez la valeur champ6"/>
		    </div>
		    <div>
		    	<input type="submit" name="send" value="Envoyer les données"/>
		    </div>
		    
			<div id="statusMessage"> 
	            <?php if (! empty($db_msg)) { ?>
	              <p class='<?php echo $type_db_msg; ?>Message'><?php echo $db_msg; ?></p>
	            <?php } ?>
	            <?php if (! empty($mail_msg)) { ?>
	              <p class='<?php echo $type_mail_msg; ?>Message'><?php echo $mail_msg; ?></p>
	            <?php } ?>
            </div>

		  </form>
	    </div>
	</body>
</html>