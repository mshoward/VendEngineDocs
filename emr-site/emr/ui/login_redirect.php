<?php
	require_once "auth/auth_includes.php";
	
	$usr = new user_auth();
	$usr->password($_POST["login_password"]);
	$usr->usrname($_POST["login_username"]);
	$valid = $usr->check();
	if($valid)
		$valid="Authenticated!";
	else
		$valid="NOT Authenticated!";
	$login_page = <<<LOGIN_PAGE
<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
		<title>Login</title>

		<!-- Bootstrap -->
		<link href="css/bootstrap.min.css" rel="stylesheet">

		<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
		<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
		<!--[if lt IE 9]>
			<script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
			<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
		<![endif]-->
		<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
		<!-- Include all compiled plugins (below), or include individual files as needed -->
		<script src="js/bootstrap.min.js"></script>
	</head>
	<body>
		<div class="jumbotron">
			<div class="container">
				<div class="row">
					<div class="col-md-3">
						<img src="res/red_cross.png" alt="HealthEngine Red Cross" style="width:150px; height:150px;">
					</div>
					<div class="col-md-8">
						<h1>HealthEngine</h1>
						<p>Easymode EMR</p>
					</div>
				</div>
			</div>
		</div>
		<div class="container"></div>
			<div class="row">
			
				<div class="col-md-6">
					<div class="well">
						<h1>Welcome to HealthEngine</h1>
						<p class="lead">$username</p>
					</div>
				</div>
				<div class="col-md-6">
					<div class="well well-lg">
						<form action="login_redirect.php" method="post">
							<div class="form-group">
								<div class="input-group input-group-lg">
									<label class="input-group-addon"  id="sizing-addon1" for="login_username">Username</label>
									<span id="login_username" class="form-control" placeholder="Username" aria-describedby="sizing-addon1">
									$_POST["login_username"];
									</span>
								</div>
								<br>
								<div class="input-group input-group-lg">
									<label id="sizing-addon2" class="input-group-addon" for="login_password">Password</label>
									<span id="login_password" type="password" class="form-control" placeholder="Username" aria-describedby="sizing-addon2">
									$valid
									</span>
								</div>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
	</body>
</html>
LOGIN_PAGE;

echo $login_page;
?>
