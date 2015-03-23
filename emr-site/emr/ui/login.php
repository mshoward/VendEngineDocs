<?php
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
				<h1>This... <small>is the login page!</small></h1>
				<p>Ideally, this is where you'd log in...</p>
			</div>
		</div>
		<div class="container"></div>
			<div class="row">
			
				<div class="col-md-6">
					<div class="well">
						<h1>Hello, world!</h1>
						<p class="lead">Pretend this is a decently sized paragraph summarizing.</p>
						<p>And this is a much larger paragraph giving details and such. <small>With some fine print.</small></p>
						<p><s>This is an erroneous paragraph.</s></p>
						
					</div>
				</div>
				<div class="col-md-6">
					<div class="well well-lg">
						<form>
							<div class="form-group">
								<div class="input-group input-group-lg">
									<span class="input-group-addon" id="sizing-addon1">Username</span>
									<input type="text" class="form-control" placeholder="Username" aria-describedby="sizing-addon1">
								</div>
								<br>
								<div class="input-group input-group-lg">
									<span class="input-group-addon" id="sizing-addon1">Password</span>
									<input type="password" class="form-control" placeholder="Username" aria-describedby="sizing-addon1">
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
