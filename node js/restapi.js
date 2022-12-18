const http = require("http");
const express = require('express');
const app = express();
const mysql = require('mysql');
const bodyParser = require('body-parser');
const url = require('url');
const crypto = require('crypto');
const swaggerUI = require("swagger-ui-express");
const swaggerDocument = require('./openapi.json');
const swaggerJsDoc = require("swagger-jsdoc");

const options = {
  definition: {
    openapi: "3.0.0",
    info: {
      title: "Rainbow table API",
      version: "1.0.0",
      description: "A simple rainbow table API",
    },
    servers: [
      {
        url: `http://127.0.0.1:3000`,
      },
    ],
  },
  apis: ["./*.js"],
};
const specs = swaggerJsDoc(options);
app.get("/openapi.json", (req, res) => res.json(swaggerDocument))
app.use("/docs", swaggerUI.serve, swaggerUI.setup(swaggerDocument));


var connection = mysql.createConnection({
  host     : 'localhost',
  user     : 'root',
  password : '',
  database : 'i652b8_sop'
});
 
 
connection.connect(function(err) {
  if (err) throw err
  console.log('Connected successfully!')
})
 

app.use( bodyParser.json() );
app.use(bodyParser.urlencoded({
  extended: true
}));

 

var server = app.listen(3000,  "0.0.0.0", function () {
 
  var host = server.address().address
  var port = server.address().port
 
  console.log("Server started at URI: http://%s:%s", host, port)
 
});
/*-----------------------------------------------------------------------------------------------------------------*/
/*------------------------------------------- Login ---------------------------------------------------------------*/
/*-----------------------------------------------------------------------------------------------------------------*/

app.get('/login', function (req, res) {
	var q = url.parse(req.url, true).query;
	if (!q.username || !q.password) {
		return res.status(406).send({'error': 1, 'message': 'Username and/or password not specified!'});
	}
	if (q.username.length < 3) {
		return res.status(406).send({'error': 1, 'message': 'Username must contain at least 3 letters!'});
	}
	if (q.password.length < 3) {
		return res.status(406).send({'error': 1, 'message': 'Password must contain at least 3 letters!'});
	}
	if (q.username.indexOf(' ') > -1)
	{
	  return res.status(406).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (q.password.indexOf(' ') > -1)
	{
	  return res.status(406).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var api_req = http.request({
			hostname: '127.0.0.1',
			path: '/api/login.php?username='+q.username+'&password='+q.password,
			method: 'GET'
		},
		api_res => {
			api_res.on('data', d => {
			var data = JSON.parse(d);
			res.json(data);
		  })
		})
		
		api_req.on('error', error => {
			console.log(error);
			res.status(504).send({'error': 1, 'message': 'Internal server error. API could not get a response in time.'});
		})
		api_req.end()
});
 
/*-----------------------------------------------------------------------------------------------------------------*/
/*--------------------------------------- Rainbow table -----------------------------------------------------------*/
/*-----------------------------------------------------------------------------------------------------------------*/
app.get('/rainbowtable', function (req, res) {
	var path;
	var q = url.parse(req.url, true).query;
	
	if (!q.filter) {
		path = '/api/rainbow_table.php';
	}
	else {
		if (q.filter.indexOf(' ') > -1)
		{
		  return res.status(406).send({'error': 1, 'message': 'Filter contains unwanetd charachters!'});
		}
		path = '/api/rainbow_table.php?filter=' + q.filter;
	}
	var api_req = http.request({
		hostname: '127.0.0.1',
		path: path,
		method: 'GET'
	},
	function (api_res) {
		api_res.on('data', d => {
		var data = JSON.parse(d);
		data.id = changeId;
		res.json(data);
		})
	})

	api_req.on('error', error => {
		console.log(error);
		res.status(504).send({'error': 1, 'message': 'Internal server error. API could not get a response in time.'});
	})
	api_req.end()
});

app.post('/rainbowtable', function (req, res) {
	var username = req.body.username;
	var password = req.body.password;
	if (!username || !password) {
		return res.status(401).send({'error': 1, 'message': 'Username and/or password not specified!'});
	}
	if (username.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Username must contain at lest 3 letters!'});
	}
	if (password.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Password must contain at lest 3 letters!'});
	}
	if (username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var params = req.body
	var sql = "select * from users where username = '" + username + "' and password = md5('" + password + "');";
	var query = connection.query(sql, function (err, results) {
		if(err) throw err;
		if (results.length == 0) {
			return res.status(401).send({'error': 1, 'message': 'You must log in to use this feature!'});
		}
		else {
			if (params.hashedPassword) {
				if (params.hashedPassword.indexOf(' ') > -1)
				{
				  return res.status(406).send({'error': 1, 'message': 'The hashed password contains unwanetd charachters!'});
				}
				if (params.md5.length != 32) {
					return res.status(406).send({'error': 1, 'message': 'Invalid hash length for MD5!'});
				}
				else if (params.sha1.length != 40) {
					return res.status(406).send({'error': 1, 'message': 'Invalid hash length for SHA1!'});
				}
				else if (params.sha256.length != 64) {
					return res.status(406).send({'error': 1, 'message': 'Invalid hash length for SHA256!'});
				}
				else if (crypto.createHash('md5').update(params.hashedPassword).digest('hex') != params.md5) {
					return res.status(406).send({'error': 1, 'message': 'Invalid hash for MD5!'});
				}
				else if (crypto.createHash('sha1').update(params.hashedPassword).digest('hex') != params.sha1) {
					return res.status(406).send({'error': 1, 'message': 'Invalid hash for SHA1!'});
				}
				else if (crypto.createHash('sha256').update(params.hashedPassword).digest('hex') != params.sha256) {
					return res.status(406).send({'error': 1, 'message': 'Invalid hash for SHA256!'});
				}
			}
			if (!params.hashedPassword && !params.md5 && !params.sha1 && !params.sha256) {
				return res.status(406).send({'error': 1, 'message': 'Nothing is specified for the new entry!'});
			}
			var sql = "select count(*) as count from rainbow_table where passwd = '" + params.hashedPassword + "' or md5 = '" + params.md5 + "' or sha1 = '" + params.sha1 + "' or sha256 = '" + params.sha256 + "';";
			var query = connection.query(sql, (err, results) => {
				if(err) throw err;
				if (results[0].count != 0 && params.hashedPassword) {
					var sql = "select id from rainbow_table where passwd = '" + params.hashedPassword + "' or md5 = '" + params.md5 + "' or sha1 = '" + params.sha1 + "' or sha256 = '" + params.sha256 + "';";
					var query = connection.query(sql, (err, results) => {
						if(err) throw err;
						var id = results[0].id;
						var sql = "update rainbow_table set passwd = '"+params.hashedPassword+"', md5 = '"+params.md5+"', sha1 = '"+params.sha1+"', sha256 = '"+params.sha256+"' where id = "+ id + ";";
						var query = connection.query(sql, (err, results) => {
							if(err) throw err;
							changeOccured();
							return res.json({'error': 0, 'message': 'Entry updated successfully!'});
						})
					})
				}
				else if (results[0].count != 0) {
					return res.json({'error': 0, 'message': 'Entry already exists! Nothing changed.'});
				}
				else {
					var sql = "insert into rainbow_table (passwd, md5, sha1, sha256) values ('"+params.hashedPassword+"','"+params.md5+"','"+params.sha1+"','"+params.sha256+"');";
					var query = connection.query(sql, (err, results) => {
						if(err) throw err;
						changeOccured();
						return res.json({'error': 0, 'message': 'New entry successfully added!'});
					})
				}
			}
		)}
	});
});

app.put('/rainbowtable', function (req, res) {
	var username = req.body.username;
	var password = req.body.password;
	if (!username || !password) {
		return res.status(401).send({'error': 1, 'message': 'Username and/or password not specified!'});
	}
	if (username.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Username must contain at lest 3 letters!'});
	}
	if (password.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Password must contain at lest 3 letters!'});
	}
	if (username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var params = req.body
	var sql = "select count(*) as count from users where username = '" + username + "' and password = md5('" + password + "');";
	var query = connection.query(sql, (err, results) => {
		if(err) throw err;
		if (results[0].count == 0) {
			return res.json({'error': 1, 'message': 'You must log in to use this feature!'});
		}
		else {
			if (!params.id && params.id != 0) {
				return res.status(406).send({'error': 1, 'message': 'Missing id!'});
			}
			if (params.hashedPassword.indexOf(' ') > -1)
			{
			  return res.status(406).send({'error': 1, 'message': 'The hashed password contains unwanetd charachters!'});
			}
			if (params.md5.length != 32) {
				return res.status(406).send({'error': 1, 'message': 'Invalid hash length for MD5!'});
			}
			else if (params.sha1.length != 40) {
				return res.status(406).send({'error': 1, 'message': 'Invalid hash length for SHA1!'});
			}
			else if (params.sha256.length != 64) {
				return res.status(406).send({'error': 1, 'message': 'Invalid hash length for SHA256!'});
			}
			else if (crypto.createHash('md5').update(params.hashedPassword).digest('hex') != params.md5) {
				return res.status(406).send({'error': 1, 'message': 'Invalid hash for MD5!'});
			}
			else if (crypto.createHash('sha1').update(params.hashedPassword).digest('hex') != params.sha1) {
				return res.status(406).send({'error': 1, 'message': 'Invalid hash for SHA1!'});
			}
			else if (crypto.createHash('sha256').update(params.hashedPassword).digest('hex') != params.sha256) {
				return res.status(406).send({'error': 1, 'message': 'Invalid hash for SHA256!'});
			}
			
			var innerSql = "update rainbow_table set passwd = '"+params.hashedPassword+"', md5 = '"+params.md5+"', sha1 = '"+params.sha256+"' where id = "+params.id + ";";
			
			var query = connection.query(innerSql, (err, results) => {
			if(err) throw err;
			changeOccured();
			return res.json({'error': 0, 'message': 'Entry updated successfully!'});
		}
		)}
	});
});

app.delete('/rainbowtable', function (req, res) {
	var params = url.parse(req.url, true).query;
	var username = params.username;
	var password = params.password;
	if (!username || !password) {
		return res.status(401).send({'error': 1, 'message': 'Username and/or password not specified!'});
	}
	if (username.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Username must contain at lest 3 letters!'});
	}
	if (password.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Password must contain at lest 3 letters!'});
	}
	if (username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var sql = "select count(*) as count from users where username = '" + username + "' and password = md5('" + password + "');";
	var query = connection.query(sql, (err, results) => {
		if(err) throw err;
		if (results[0].count == 0) {
			return res.json({'error': 1, 'message': 'You must log in to use this feature!'});
		}
		else {
			if (!params.id && params.id != 0) {
				return res.json({'error': 1, 'message': 'Missing id!'});
			}
			
			
			var sql = "delete from rainbow_table where id = "+params.id + ";";
			
			var query = connection.query(sql, (err, results) => {
				if(err) throw err;
				changeOccured();
				return res.json({'error': 0, 'message': 'Entry deleted successfully!'});
			}
		)}
	});
});

/*-----------------------------------------------------------------------------------------------------------------*/
/*-------------------------------------- Admin user check ---------------------------------------------------------*/
/*-----------------------------------------------------------------------------------------------------------------*/
app.get('/isAdmin', function (req, res) {
	var q = url.parse(req.url, true).query;
	if (!q.username) {
		return res.status(401).send({'error': 1, 'message': 'Username not specified!'});
	}
	if (q.username.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Username must contain at least 3 letters!'});
	}
	if (!q.password) {
		return res.status(401).send({'error': 1, 'message': 'Password not specified!'});
	}
	if (q.password.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Password must contain at least 3 letters!'});
	}
	if (q.username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (q.password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var api_req = http.request({
			hostname: '127.0.0.1',
			path: '/api/isAdmin.php?username='+q.username+'&password='+q.password,
			method: 'GET'
		},
		api_res => {
			api_res.on('data', d => {
			var data = JSON.parse(d);
			res.json(data);
		  })
		})
		
		api_req.on('error', error => {
			console.log(error);
			res.status(504).send({'error': 1, 'message': 'Internal server error. API could not get a response in time.'});
		})
		api_req.end()
});

/*-----------------------------------------------------------------------------------------------------------------*/
/*------------------------------------------ Users (user management) ----------------------------------------------*/
/*-----------------------------------------------------------------------------------------------------------------*/

app.get('/users', function (req, res) {
	var q = url.parse(req.url, true).query;
	if (!q.username) {
		return res.status(401).send({'error': 1, 'message': 'Username not specified!'});
	}
	if (!q.password) {
		return res.status(401).send({'error': 1, 'message': 'Password not specified!'});
	}
	if (q.username.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Username must contain at least 3 letters!'});
	}
	if (q.password.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Password must contain at least 3 letters!'});
	}
	if (q.username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (q.password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var path = path = '/api/users.php?username='+q.username+'&password='+q.password;
	var api_req = http.request({
		hostname: '127.0.0.1',
		path: path,
		method: 'GET'
	},
	function (api_res) {
		api_res.on('data', d => {
			var data = JSON.parse(d);
			if (data.error == 2) {
				return res.status(401).send({'error': 1, 'message': 'You must log in as an admin to use this feature!'});
			}
			res.json(data);
		})
	})
	api_req.on('error', error => {
		console.log(error);
		res.status(504).send({'error': 1, 'message': 'Internal server error. API could not get a response in time.'});
	})
	api_req.end();
});

app.post('/users', function (req, res) {
	var username = req.body.username;
	var password = req.body.password;
	if (!username || !password) {
		return res.status(401).send({'error': 1, 'message': 'Username and/or password not specified!'});
	}
	if (username.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Username must contain at lest 3 letters!'});
	}
	if (password.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Password must contain at lest 3 letters!'});
	}
	if (username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var params = req.body
	var sql = "select * from users where username = '" + username + "' and password = md5('" + password + "') and isAdmin = 1;";
	var query = connection.query(sql, function (err, results) {
		if(err) throw err;
		if (results.length == 0) {
			return res.status(401).send({'error': 1, 'message': 'You must log in as an admin to use this feature!'});
		}
		else {
			if (!params.newUsername || params.newUsername.length < 3) {
				return res.status(406).send({'error': 1, 'message': 'Missing or invalid new username!'});
			}
			if (!params.newPassword || params.newPassword.length < 3) {
				return res.status(406).send({'error': 1, 'message': 'Missing or invalid new password!'});
			}
			if (!params.isAdmin) {
				params.isAdmin = 0;
			}
			if (params.newUsername.indexOf(' ') > -1)
			{
				return res.status(406).send({'error': 1, 'message': 'The new username contains unwanetd charachters!'});
			}
			if (params.newPassword.indexOf(' ') > -1)
			{
				return res.status(406).send({'error': 1, 'message': 'The new password contains unwanetd charachters!'});
			}
			
			var sql = "select count(*) as count from users where username = '" + params.newUsername + "';";
			var query = connection.query(sql, (err, results) => {
				if(err) throw err;
				if (results[0].count == 0) {
					var sql = "insert into users (username, password, isAdmin) values ('"+params.newUsername+"', md5('"+params.newPassword+"'),"+params.isAdmin+");";
					var query = connection.query(sql, (err, results) => {
						if(err) throw err;
						userChangeOccured()
						return res.json({'error': 0, 'message': 'User added successfully!'});
					})
				}
				else {
					return res.json({'error': 1, 'message': 'User already exists!'});
				}
			}
		)}
	});
});

app.put('/users', function (req, res) {
	var username = req.body.username;
	var password = req.body.password;
	if (!username || !password) {
		return res.status(406).send({'error': 1, 'message': 'Username and/or password not specified!'});
	}
	if (username.length < 3) {
		return res.status(406).send({'error': 1, 'message': 'Username must contain at lest 3 letters!'});
	}
	if (password.length < 3) {
		return res.status(406).send({'error': 1, 'message': 'Password must contain at lest 3 letters!'});
	}
	if (username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	var params = req.body
	var sql = "select count(*) as count from users where username = '" + username + "' and password = md5('" + password + "') and isAdmin = 1;";
	var query = connection.query(sql, (err, results) => {
		if(err) throw err;
		if (results[0].count == 0) {
			return res.status(401).send({'error': 1, 'message': 'You must log in as an admin to use this feature!'});
		}
		else {
			var sql = "select count(*) as count from users where username = '" + params.newUsername + "' and id != " + params.id + ";";
			var query = connection.query(sql, (err, results) => {
				if (results[0].count > 0) {
					return res.json({'error': 1, 'message': 'User already exists with the given new username!'});
				}
				if (!params.id && params.id != 0) {
					return res.status(406).send({'error': 1, 'message': 'Missing id!'});
				}
				if (!params.newUsername || params.newUsername.length < 3) {
					return res.status(406).send({'error': 1, 'message': 'Missing or invalid new username!'});
				}
				if (params.newPassword && params.newPassword.length < 3) {
					return res.status(406).send({'error': 1, 'message': 'Invalid new password!'});
				}
				if (params.newUsername.indexOf(' ') > -1)
				{
					return res.status(406).send({'error': 1, 'message': 'The new username contains unwanetd charachters!'});
				}
				if (params.newPassword && params.newPassword.indexOf(' ') > -1)
				{
					return res.status(406).send({'error': 1, 'message': 'The new password contains unwanetd charachters!'});
				}
				
				var sql = "select count(*) as count from users where id = " + params.id + " and username = '" + username+ "';";
				var query = connection.query(sql, (err, results) => {
					if (results[0].count > 0) {
						params.isAdmin = 1;
					}
					var sql;
					if (params.newPassword) {
						sql = "update users set username = '" + params.newUsername + "', password = md5('" + params.newPassword+"'), isAdmin = '" + params.isAdmin + "' where id = " + params.id + ";";
					}
					else {
						sql = "update users set username = '" + params.newUsername + "', isAdmin = '" + params.isAdmin + "' where id = " + params.id + ";";
					}
					var query = connection.query(sql, (err, results) => {
						if(err) throw err;
						userChangeOccured();
						return res.json({'error': 0, 'message': 'User updated successfully!'});
					});
				});
			});
		}
	});
});

app.delete('/users', function (req, res) {
	var params = url.parse(req.url, true).query;
	var username = params.username;
	var password = params.password;
	if (!username || !password) {
		return res.status(401).send({'error': 1, 'message': 'Username and/or password not specified!'});
	}
	if (username.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Username must contain at lest 3 letters!'});
	}
	if (password.length < 3) {
		return res.status(401).send({'error': 1, 'message': 'Password must contain at lest 3 letters!'});
	}
	if (username.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Username contains unwanetd charachters!'});
	}
	if (password.indexOf(' ') > -1)
	{
	  return res.status(401).send({'error': 1, 'message': 'Password contains unwanetd charachters!'});
	}
	
	var sql = "select count(*) as count from users where username = '" + username + "' and password = md5('" + password + "') and isAdmin = 1;";
	var query = connection.query(sql, (err, results) => {
		if(err) throw err;
		if (results[0].count == 0) {
			return res.status(401).send({'error': 1, 'message': 'You must log in as an admin to use this feature!'});
		}
		else {
			if (!params.id && params.id != 0) {
				return res.json({'error': 1, 'message': 'Missing id!'});
			}
			var sql = "select count(*) as count from users where username = '" + username + "' and id = "+params.id + ";";
			var query = connection.query(sql, (err, results) => {
				if(err) throw err;
				if (results[0].count > 0) {
					return res.json({'error': 1, 'message': 'You cannot delete yourself!'});
				}
				var sql = "delete from users where id = "+params.id + ";";
			
				var query = connection.query(sql, (err, results) => {
					if(err) throw err;
					userChangeOccured();
					return res.json({'error': 0, 'message': 'User deleted successfully!'});
				});
			});
		}
	});
});

/*-----------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------- Client update helper --------------------------------------------------*/
/*-----------------------------------------------------------------------------------------------------------------*/

var changeId = 0;
var userChangeId = 0;

function changeOccured() {
	changeId = changeId + 1;
	if (changeId > 100) {
		changeId = 0;
	}
}

function userChangeOccured() {
	userChangeId = userChangeId + 1;
	if (userChangeId > 100) {
		userChangeId = 0;
	}
}

app.get('/changeId', function (req, res) {
	res.json({'error': 0, 'id': changeId});
});

app.get('/userChangeId', function (req, res) {
	res.json({'error': 0, 'id': userChangeId});
});
