var xmlHttp;
var _name;
var _nameEnemy;
var t = new Array(9);
var intervalRefresh;
var intervalCheck;
var crossOrCircle;
var lastStep;
var intervalCheckStep;
var intervalCheckContinue;

window.onload= function ()
{
	document.getElementById("myTable").style.visibility="hidden";
	document.getElementById("myField").style.visibility="hidden";
	var button1 = document.getElementById("connectButton");
	button1.addEventListener("click", Connect);
};


var Connect = function ()
{
	var params = document.getElementById("inputName").value
	_name=params;
	xmlHttp = new XMLHttpRequest();
	xmlHttp.open( "GET", "http://127.0.0.1:2000/"+ "?Command=New"+"&name="+params, true );
	xmlHttp.onreadystatechange=function()
	{
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
				if (xmlHttp.responseText=="FALSE")
				{
					alert("Player with the same nickname already exists, you should change your nickname.");
					location.reload();
				}
				else{
					document.getElementById("tableBody").innerHTML += xmlHttp.responseText;
				}
			}
		}	
	}
	xmlHttp.send();
	document.getElementById("myTable").style.visibility="visible";
	document.getElementById("myForm").style.visibility="hidden";
	 //
	 intervalRefresh = setInterval("RefreshPlayers()", 6000);
	 intervalCheck = setInterval("checkChallenge()",5000);
};

var RefreshPlayers = function()
{
	xmlHttp.open( "GET", "http://127.0.0.1:2000/" + "?Command=Update"+"&name="+_name, true );
	xmlHttp.onreadystatechange=function()
	{
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
			document.getElementById("tableBody").innerHTML = xmlHttp.responseText;
			}
		}	
	}
	xmlHttp.send();
};


var challengePlayer = function (element)
{
	    var tr = element.parentNode;
		$('#myModal').modal('show');
		document.getElementById("namePlayer").innerHTML = "Do you want to challenge " + tr.getElementsByTagName("td")[0].innerHTML + "?";
		_nameEnemy=tr.getElementsByTagName("td")[0].innerHTML;
};

var challenge = function ()
{
	var funct = "Command=Challenge";
	var params = funct+"&"+"Name="+_name+"&"+"NameEnemy="+_nameEnemy;
	xmlHttp.open("GET","http://127.0.0.1:2000/"+"?"+params, true);
	xmlHttp.send();
};


var checkChallenge = function()
{
	var funct = "Command=CheckChallenge";
	var params = funct+"&"+"Name="+_name;
    xmlHttp.open( "GET", "http://127.0.0.1:2000/" + "?"+params, true );
	xmlHttp.onreadystatechange=function()
	{
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
				if (xmlHttp.responseText=="1")
					{
						$('#modalOfChallenge').modal('show');
						document.getElementById("pIDModalOfChallenge").innerHTML = "Do you want to connect ?";
					}
				else if (xmlHttp.responseText=="2")
					{
						// GAME
						document.getElementById("myTable").style.visibility="hidden";
						document.getElementById("myForm").style.visibility="hidden";
						document.getElementById("myField").style.visibility="visible";
						//
						clearInterval(intervalRefresh);
						clearInterval(intervalCheck);
						crossOrCircle="cross";
						lastStep="you";
						intervalCheckStep = setInterval("checkStep()",5000);
					}
				else if (xmlHttp.responseText=="3")
					{
						alert("Rejected");
					}
			}
		}	
	}
	xmlHttp.send();
}

var responseToChallenge = function(answer)
{
	var funct = "Command=ResponseToChallenge";
	var params = funct+"&"+"Name="+_name+"&"+"Response="+answer;
    xmlHttp.open( "GET", "http://127.0.0.1:2000/"+"?"+params, true );
	xmlHttp.onreadystatechange=function()
	{
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
				if (xmlHttp.responseText=="TRUE")
					{
						// GAME
						document.getElementById("myTable").style.visibility="hidden";
						document.getElementById("myForm").style.visibility="hidden";
						document.getElementById("myField").style.visibility="visible";
						// 
						clearInterval(intervalRefresh);
						clearInterval(intervalCheck);
						crossOrCircle="circle";
						lastStep="enemy";
						intervalCheckStep = setInterval("checkStep()",5000);
					}
			}
		}	
	}
	xmlHttp.send();
};

function checkEnd() {
  if (t[0]=='enemy' && t[1]=='enemy' && t[2]=='enemy' || t[0]=='player' && t[1]=='player' && t[2]=='player')  return true;
  if (t[3]=='enemy' && t[4]=='enemy' && t[5]=='enemy' || t[3]=='player' && t[4]=='player' && t[5]=='player')  return true;
  if (t[6]=='enemy' && t[7]=='enemy' && t[8]=='enemy' || t[6]=='player' && t[7]=='player' && t[8]=='player')  return true;
  if (t[0]=='enemy' && t[3]=='enemy' && t[6]=='enemy' || t[0]=='player' && t[3]=='player' && t[6]=='player')  return true;
  if (t[1]=='enemy' && t[4]=='enemy' && t[7]=='enemy' || t[1]=='player' && t[4]=='player' && t[7]=='player')  return true;
  if (t[2]=='enemy' && t[5]=='enemy' && t[8]=='enemy' || t[2]=='player' && t[5]=='player' && t[8]=='player')  return true;
  if (t[0]=='enemy' && t[4]=='enemy' && t[8]=='enemy' || t[0]=='player' && t[4]=='player' && t[8]=='player')  return true;
  if (t[2]=='enemy' && t[4]=='enemy' && t[6]=='enemy' || t[2]=='player' && t[4]=='player' && t[6]=='player')  return true;
  if(t[0] && t[1] && t[2] && t[3] && t[4] && t[5] && t[6] && t[7] && t[8]) return true;
}
function move(id, role) {
	if (lastStep=="you")
	{
		  if(t[id]) return false;
		  t[id] = role;
		  document.getElementById(id).className = 'myCell ' + crossOrCircle;
		  if (!checkEnd())
		  {
			var funct = "Command=Step";
			var params = funct+"&"+"Name="+_name+"&"+"Step="+id+"&"+"First="+(crossOrCircle=="cross"?"TRUE":"FALSE");
			xmlHttp.open("GET","http://127.0.0.1:2000/"+"?"+params, true);
			xmlHttp.send(); 
			lastStep="enemy";
		  }
		  else
		  {
			var funct = "Command=Step";
			var params = funct+"&"+"Name="+_name+"&"+"Step="+id+"&"+"First="+(crossOrCircle=="cross"?"TRUE":"FALSE");
			xmlHttp.open("GET","http://127.0.0.1:2000/"+"?"+params, true);
			xmlHttp.send(); 
			clearInterval(intervalCheckStep);
			reset()
		  }
	}
}

function checkStep ()
{
	var funct = "Command=checkStep";
	var params = funct+"&"+"Name="+_name+"&"+"First="+(crossOrCircle=="cross"?"TRUE":"FALSE");
    xmlHttp.open( "GET", "http://127.0.0.1:2000/" + "?"+params, true );
	xmlHttp.onreadystatechange=function()
	{
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
				var id = xmlHttp.responseText;
				if (id!="EMPTY")
				{
					if (t[id]==null)
					{
						document.getElementById(id).className = 'myCell ' + ((crossOrCircle=="cross")?"circle":"cross");
						t[id]="enemy";
						lastStep="you";
						checkEnd()?reset():null;
					}
				}
			}
		}	
	}
	xmlHttp.send();
}

function reset() {
  $('#modalOfRestarting').modal('show');
  document.getElementById("pIDModalOfRestarting").innerHTML = "Do you want to continue a game ?";
}

function continueGame (answer)
{
	var response;
	clearInterval(intervalCheckStep);
	if (answer=="YES")
	{
		var funct = "Command=Continue";
		var params = funct+"&"+"Name="+_name+"&"+"Response=YES";
		xmlHttp.open("GET","http://127.0.0.1:2000/"+"?"+params, true);
		xmlHttp.send();
		intervalCheckContinue = setInterval("checkContinue()",5000);
	}
	else if (answer =="NO")
	{
		var funct = "Command=Continue";
		var params = funct+"&"+"Name="+_name+"&"+"Response=NO";
		xmlHttp.open("GET","http://127.0.0.1:2000/"+"?"+params, true);
		xmlHttp.send();
		goToLobby();
	}
}


function checkContinue ()
{
	var funct = "Command=checkContinue";
	var params = funct+"&"+"Name="+_name;
    xmlHttp.open( "GET", "http://127.0.0.1:2000/" + "?"+params, true );
	xmlHttp.onreadystatechange=function()
	{
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
				var answer = xmlHttp.responseText;
				if (answer=="YES")
				{			
					clearInterval(intervalCheckContinue);
					cleanField();
					intervalCheckStep = setInterval("checkStep()",5000);
				}
				else if (answer=="NO")
				{
					clearInterval(intervalCheckContinue);
					goToLobby();
				}
			}
		}	
	}
	xmlHttp.send();
}

function goToLobby ()
{
		document.getElementById("myField").style.visibility="hidden";
		document.getElementById("myTable").style.visibility="visible";
		intervalRefresh = setInterval("RefreshPlayers()", 6000);
		intervalCheck = setInterval("checkChallenge()",5000);
		cleanField();
}

function cleanField()
{
	t = new Array(9);	
	for (i = 0; i < t.length; i++) 
	{ 
		var elem = 	document.getElementById(i);
		if (elem.classList.contains("circle") || elem.classList.contains("cross"))
		{
			elem.classList.contains("circle")?elem.classList.remove('circle'):elem.classList.remove('cross');
		}
	}
}

