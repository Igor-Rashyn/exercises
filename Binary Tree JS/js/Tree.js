var tree = new Tree();

function run ()
{
	tree.add();
	document.getElementById("display").value = "";
};

function runDel ()
{
	tree.deleteNode();
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.clearRect(0,0,c.width,c.height);
	InOrder(tree.root);
	DrawAllTree(tree.root);
	document.getElementById("display").value = "";
};


 function Tree ()
 {
	 this.root=null;
 };
 
 Tree.prototype.makeNode= function(value)
 {
	var node = {};        
		node.value = value;
		node.left = null;
		node.right = null;
		node.parent = null;
		node.x= 0;
		node.y=0;
		node.pictured = false;
		node.wh = 0;
	return node;
 };
 
 Tree.prototype.add = function()
 {
   var value = document.getElementById('display').value;
   var temporeryNode = this.makeNode(value);
   if (this.root==null)
    {
	 this.root=temporeryNode;  
    }
   else
    {
	 this.insert(temporeryNode);
    }
	Draw(this.root);
 };
 
 Tree.prototype.insert = function (temporeryNode)
 {
	 var value = temporeryNode.value;
	 var traverse = function (node)
	 {
		 if (node.value>value)
         {
            if (node.left == null)
             {
			  temporeryNode.parent=node;
              node.left = temporeryNode;
             }
             else
             {
			  traverse(node.left);
             }
         }
        else if (value > node.value)
                {
                    if (node.right == null)
                    {
						temporeryNode.parent=node;
                        node.right = temporeryNode;
                    }
                    else
                    {
                        traverse(node.right);
                    }
                }
	 };
	 traverse(this.root);
 };
 Tree.prototype.deleteNode = function()
 {
	 var value = document.getElementById('display').value;
	 var valueRoot = tree.root.value;
	 var del  = function (node)
	 {
		 if (value<node.value)
		 {
			 del(node.left);
		 }
		 else if (value>node.value)
		 {
			 del(node.right)
		 }
		 else
		 {
			if (tree.root.value==value &&node.right==null && node.left==null)
			 {
				 tree.root=null;
			 }
			else if (node.right==null && node.left==null && tree.root.value!=value)
			{
    			if (node.parent.left.value==value)
				{
					node.parent.left=null;
				}
				else
				{
					node.parent.right=null;
				}
			}
			else if (node.left==null && node.right!=null)
			{
				if(node.parent.left!=null)
				{
					if (node.parent.left.value==value)
					{
					node.parent.left = node.right;
					node.right.parent = node.parent;	
					}
					else
					{
					node.parent.right = node.right;
					node.right.parent = node.parent;
					}
				}
				else 
				{
					if (node.parent.right.value==value)
					{
					node.parent.right = node.right;
					node.right.parent = node.parent;
					}
					else
					{
					node.parent.left = node.right;
					node.right.parent = node.parent;
					}
				}
			}
			else if (node.right==null && node.left!=null)
			{
				if(node.parent.left!=null)
				{
					if (node.parent.left.value==value)
					{
					node.parent.left = node.left;
					node.left.parent=node.parent;
					}
					else
					{
					node.parent.right = node.left;
					node.left.parent=node.parent;
					}
				}
				else
				{
					if (node.parent.right.value==value)
					{
					node.parent.right = node.left;
					node.left.parent=node.parent;
					}
					else
					{
					node.parent.left = node.left;
					node.left.parent=node.parent;
					}
				}
			}
			else
			{
				if (node.right.left==null && node.parent!=null)
				{
					node.right.parent=node.parent;
					node.left.parent=node.right;
					node.parent.right=node.right;
					node.right.left=node.left;
				}
				else
				{
					var min = FindMin(node.right);
					node.value=min.value;
					min.parent.right=null;
					min=null;
				}			
			}		
		 }
	 };
	 del (tree.root);
 };
 
 function FindMin(node)
 {
	 var curNode = node;
	 var min = null;
	 while (curNode.left!=null)
	 {
		 if (curNode.left==null)
		 {
			 min=curNode;
		 }
		 else
		 {
			 var cur = curNode.left;
			 curNode=cur; 
		 }
	 }
	 return min;
 };
 
 function Draw (node)
 {
	 var canvas = document.getElementById("myCanvas");
	 if (node.pictured==false)
	 {
		 if (node.parent==null)
		 {
			 DrawCircle(250,22,node.value);
			 node.pictured=true;
			 node.x= canvas.width/2;
			 node.y = 22;
			 node.wh=canvas.width/2;
		 }
		 else if (node.value>node.parent.value)
		 {
			 node.wh=node.parent.wh/2;
			 DrawCircle(node.parent.x+node.wh, node.parent.y+50,node.value);
			 node.pictured=true;
			 node.x=node.parent.x+node.wh;
			 node.y=node.parent.y+50;
			 DrawLine(node.parent.x,node.parent.y,node.x,node.y);
		 }
		 else 
		 {
			 node.wh=node.parent.wh/2;
			 DrawCircle(node.parent.x-node.wh, node.parent.y+50,node.value);
			 node.pictured=true;
			 node.x=node.parent.x-node.wh;
			 node.y=node.parent.y+50;
			 DrawLine(node.parent.x,node.parent.y,node.x,node.y);
		 }
	 }
	 else
	 {
		 if (node.left!=null)
		 {
			 Draw(node.left);
		 }
		 if (node.right!=null)
		 {
			 Draw(node.right);
		 }
	 }
 };
 
  function DrawCircle(x,y,value)
 {
	var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
	ctx.beginPath();
	ctx.arc(x,y,20,0,2*Math.PI);
	ctx.stroke();
	ctx.font = "20px Arial";
	ctx.fillText(value,x-10,y+5)
 };
 
 function DrawLine (sx,sy, ex, ey)
 {
	 var c = document.getElementById("myCanvas");
     var ctx = c.getContext("2d");
	 ctx.moveTo(sx,sy+20);
     ctx.lineTo(ex,ey-20);
     ctx.stroke();
 };
 function DrawAllTree (node)
 {
	var canvas = document.getElementById("myCanvas");
	if (node==null)
	{
		return;
	}
	else 
	{
		 if (node.parent==null)
		 {
			 DrawCircle(250,22,node.value);
			 node.pictured=true;
			 node.x= canvas.width/2;
			 node.y = 22;
			 node.wh=canvas.width/2;
		 }
		 else if (node.value>node.parent.value)
		 {
			 node.wh=node.parent.wh/2;
			 DrawCircle(node.parent.x+node.wh, node.parent.y+50,node.value);
			 node.pictured=true;
			 node.x=node.parent.x+node.wh;
			 node.y=node.parent.y+50;
			 DrawLine(node.parent.x,node.parent.y,node.x,node.y);
		 }
		 else 
		 {
			 node.wh=node.parent.wh/2;
			 DrawCircle(node.parent.x-node.wh, node.parent.y+50,node.value);
			 node.pictured=true;
			 node.x=node.parent.x-node.wh;
			 node.y=node.parent.y+50;
			 DrawLine(node.parent.x,node.parent.y,node.x,node.y);
		 }
		 if (node.left!=null)
		 {
			 DrawAllTree(node.left);
		 }
		 if (node.right!=null)
		 {
			 DrawAllTree(node.right);
		 }
	 } 
 };
 function InOrder(node)
 {
	 if (node == null)
	 {
		 return;
	 }
	 else
	 {
		 node.pictured=false;
		 if (node.left!=null)
		 {
			 InOrder(node.left);
		 }
		 if (node.right!=null)
		 {
			 InOrder(node.right);
		 }
	 }
 };