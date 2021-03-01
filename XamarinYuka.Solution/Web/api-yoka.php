<?php
    $productFunction = htmlspecialchars($_GET["productFunction"]);
	$productCode = htmlspecialchars($_GET["codeId"]);

    if(strcmp($productFunction, "get_info_product_by_id") == 0)
    {
        $result = get_info_product_by_id($productCode);
    }
    else 
    {
	    $result = get_info_all_product();
    }

    if(!$result)
	{
	    http_response_code(404);
	}
	else
	{
	    echo json_encode($result,JSON_PRETTY_PRINT);
	}
	

    function get_info_product_by_id($productCode)
    {
        $myProduct = new ProductElement();

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
        else 
        {
	        $requestSql = "SELECT * FROM tb_ProductInformation WHERE pr_code = '".$productCode."'";
            $resultSql = mysqli_query($connexion, $requestSql);

            if (mysqli_num_rows($resultSql) > 0) 
            {
                // output data of each row
                while($row = mysqli_fetch_assoc($resultSql)) 
                {
                    $myProduct->ProductCode = $row["pr_code"];
    	            $myProduct->ProductName = $row["pr_name"];
                    $myProduct->ProductScore = $row["pr_score"];
    	            $myProduct->ProductState = $row["pr_state"];
                    $myProduct->ProductImage = "http://droid.buzzely.fr/yoka/img/".$row["pr_image"];
                    $myProduct->ProductChamp1 = $row["pr_champ1"];
    	            $myProduct->ProductChamp2 = $row["pr_champ2"];
    	            $myProduct->ProductChamp3 = $row["pr_champ3"];
    	            $myProduct->ProductChamp4 = $row["pr_champ4"];
    	            $myProduct->ProductChamp5 = $row["pr_champ5"];
    	            $myProduct->ProductChamp6 = $row["pr_champ6"];
                }
                
                
            } 
            
            mysqli_close($connexion);
        }

        return $myProduct;
    }

    function get_info_all_product()
    {
        $myProductArray = array();
        
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
        else 
        {
	        $requestSql = "SELECT * FROM tb_ProductInformation";
            $resultSql = mysqli_query($connexion, $requestSql);

            if (mysqli_num_rows($resultSql) > 0) 
            {
                // output data of each row
                while($row = mysqli_fetch_assoc($resultSql)) 
                {
                    $myProduct->ProductCode = $row["pr_code"];
    	            $myProduct->ProductName = $row["pr_name"];
                    $myProduct->ProductScore = $row["pr_score"];
    	            $myProduct->ProductState = $row["pr_state"];
                    $myProduct->ProductImage = "http://droid.buzzely.fr/yoka/img/".$row["pr_image"];
                    $myProduct->ProductChamp1 = $row["pr_champ1"];
    	            $myProduct->ProductChamp2 = $row["pr_champ2"];
    	            $myProduct->ProductChamp3 = $row["pr_champ3"];
    	            $myProduct->ProductChamp4 = $row["pr_champ4"];
    	            $myProduct->ProductChamp5 = $row["pr_champ5"];
    	            $myProduct->ProductChamp6 = $row["pr_champ6"];
                    array_push($myProductArray,$myProduct);
                }
            } 
            
            mysqli_close($connexion);
        }

        return $myProductArray;

    }

    Class ProductElement
    {
        public $ProductCode;
        public $ProductName;
        public $ProductScore;
        public $ProductState;
        public $ProductImage;
        public $ProductChamp1;
        public $ProductChamp2;
        public $ProductChamp3;
        public $ProductChamp4;
        public $ProductChamp5;
        public $ProductChamp6;
    }
?>