# API Source Code

```php
<?php
include "DatabaseConnectionDetails.php";

$query = $_GET['query'];
$result_arr = array();

if($_GET['apiKey'] == $apiKey) {
        // Create connection
        $conn = new mysqli($servername, $username, $password, $database);

        // Check connection
        if ($conn->connect_error) {
                die("Connection failed: " . $conn->connect_error);
        }
        if(!empty($query)) {
                $result = $conn->query($query);
                if(mysqli_error($conn) != null) {
                        die('[{"error" : "' . mysqli_error($conn) . '"}]');
                }
                if($result->num_rows > 0) {
                        while($row = $result->fetch_assoc()) {
                                $result_arr[] = $row;
                        }
                        echo json_encode($result_arr, JSON_UNESCAPED_UNICODE);
                }
                else {
                        echo '[{"error": "0 results from query"}]';
                }
        }else {
                echo '[{"error": "Query was empty"}]';
        }
        $conn->close();
}else {
        echo '[{"error": "Incorrect API - key"}]';
}
?>
```