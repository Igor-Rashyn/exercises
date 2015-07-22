window.onload= function ()
{
    var xmlHttp = new XMLHttpRequest();
	xmlHttp.open( "GET", "http://127.0.0.1:2000/", true );
	   	xmlHttp.onreadystatechange=function()
	{
		if(xmlHttp.readyState==4){
			if(xmlHttp.status==200){
			document.getElementById("tableBody").innerHTML += xmlHttp.responseText;
			}
		}	
	}
	xmlHttp.send();
};

var createPersonInDatabase = function()
{
	var id = "ID= "+document.getElementById("personId").value;
	var name ="Name= "+ document.getElementById("name").value;
	var strength ="Strength= "+ document.getElementById("strength").value;
	var age = "Age= "+document.getElementById("age").value;
	var stamina ="Stamina= "+ document.getElementById("stamina").value;
	var beauty ="Beauty= "+ document.getElementById("beauty").value;
	var eyeColor ="EyeColor= "+ document.getElementById("eyeColor").value;
	var smile ="Smile= "+ document.getElementById("smile").value;
	var gender ="Gender= "+ document.getElementById("select").value;
	var funct = "Funct= <Add>";
	var params = funct+"&"+id+"&"+name+"&"+strength+"&"+age+"&"+stamina+"&"+beauty+"&"+eyeColor+"&"+smile+"&"+gender;
	var xmlHttp = new XMLHttpRequest();
	xmlHttp.open("POST","http://127.0.0.1:2000/", true);
	xmlHttp.send(params);
    $('#myModal').modal('hide');
	//document.location.reload(true);
};

var editPerson = function(element)
{
	$('#modalEdit').modal('show');
	var id = element.alt;
    var tr = element.parentNode.parentNode;
	document.getElementById("personIdEdit").value=tr.getElementsByTagName("td")[1].innerHTML;
	document.getElementById("nameEdit").value=tr.getElementsByTagName("td")[2].innerHTML;
	document.getElementById("strengthEdit").value=tr.getElementsByTagName("td")[3].innerHTML;
	document.getElementById("ageEdit").value=tr.getElementsByTagName("td")[4].innerHTML;
	document.getElementById("staminaEdit").value=tr.getElementsByTagName("td")[5].innerHTML;
	document.getElementById("beautyEdit").value=tr.getElementsByTagName("td")[6].innerHTML;
	document.getElementById("eyeColorEdit").value=tr.getElementsByTagName("td")[7].innerHTML;
	document.getElementById("smileEdit").value=tr.getElementsByTagName("td")[8].innerHTML;
	if (tr.getElementsByTagName("td")[9].innerHTML=="M")
	{
	document.getElementById('manBlockEdit').style.display = 'block';
	document.getElementById('womanBlockEdit').style.display='none';	
		document.getElementById('selectEdit').options[0].selected=true;
	}
	else{
	document.getElementById('manBlockEdit').style.display = 'none';
	document.getElementById('womanBlockEdit').style.display='block';
	document.getElementById('selectEdit').options[1].selected=true;	
	}
};

var updatePersonInDatabase = function()
{
   var funct = "Funct=<Update>";
	var params = funct+"&"+"ID="+document.getElementById("personIdEdit").value+"&"+"Name="+document.getElementById("nameEdit").value+"&"+"Strength="+document.getElementById("strengthEdit").value+"&"+"Age="+document.getElementById("ageEdit").value+"&"+"Stamina="+document.getElementById("staminaEdit").value+"&"+"Beauty="+document.getElementById("beautyEdit").value+"&"+"EyeColor="+document.getElementById("eyeColorEdit").value+"&"+"Smile="+document.getElementById("smileEdit").value+"&"+"Gender="+document.getElementById("selectEdit").value;
	var xmlHttp = new XMLHttpRequest();
	xmlHttp.open("POST","http://127.0.0.1:2000/", true);
	xmlHttp.send(params);
    $('#modalEdit').modal('hide');
};

var deletePerson = function (element)
{
	var id = element.alt;
	var funct = "Funct=<Delete>";
	var params = funct +"&"+"ID="+id;
	var xmlHttp = new XMLHttpRequest();
	xmlHttp.open("POST","http://127.0.0.1:2000/", true);
	xmlHttp.send(params);
	location.reload();
}
