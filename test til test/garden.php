<!doctype html>
<html lang="en">
  <head>
    <title>Opskrifter</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
  </head>
  <body>
      
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="script.js"> 

</script>
</body>
<div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
    <h1 class="display-4">Recipe Cards</h1>
    <p id="small-display">Never forget another recipe!</p>
    <p id="total-num-recipes"></p>
  </div>

  <div class="container">
    <div class="card-deck text-center">
      <div class="col-sm-6 col-md-3 col-lg-3">
        <div class="card mb-4 box-shadow">
          <div class="card-header">


    <h4 class="my-0 font-weight-normal">Chocolate Cake</h4>
          </div>
          <div class="card-body">
            <img src="https://justamumnz.com/wp-content/uploads/2017/06/Best-Ever-Chocolate-Cake-1.jpg" alt="image" width="100" class="img-thumbnail">
            <ul class="list-unstyled mt-3 mb-4">
              <li>sugar</li>
              <li>Cocoa</li>
              <li>flour</li>
              <li>salt</li>
              <li>Baking powder</li>
            </ul>
            <span id="number-of-ingredients"> </span>
          </div>
        </div>
      </div>
      <div class="col-sm-6 col-md-3 col-lg-3">
        <div class="card mb-4 box-shadow">
          <div class="card-header">





          </body>
    <?php
$host    = "192.168.16.146";
$user    = "test";
$pass    = "test";
$db_name = "Opskrift";

//create connection
$connection = mysqli_connect($host, $user, $pass, $db_name);

//test if connection failed
if(mysqli_connect_errno()){
    die("connection failed: "
        . mysqli_connect_error()
        . " (" . mysqli_connect_errno()
        . ")");
}




    //get results from database
$result = mysqli_query1($connection,"SELECT * FROM bunda");
$all_property = array();  //declare an array for saving property

//showing property
echo '<table class="data-table">
        <tr class="data-heading">';  //initialize table tag
while ($property = mysqli_fetch_field($result)) {
    echo '<td>' . $property->name . '</td>';  //get field name for header
    array_push($all_property, $property->name);  //save those to array
}
echo '</tr>'; //end tr tag

//showing all data
while ($row = mysqli_fetch_array($result)) {
    echo "<tr>";
    foreach ($all_property as $item) {
        echo '<td>' . $row[$item] . '</td>'; //get items using property value
    }
    echo '</tr>';
}
echo "</table>";

?>



</html> 
