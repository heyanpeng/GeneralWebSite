var obj=null;
var As=document.getElementById('nav').getElementsByTagName('a');
obj = As[0];
for(i=1;i<As.length;i++){if(window.location.href.indexOf(As[i].href)>=0)
obj=As[i];}
obj.id='nav_current'

window.onload = function ()
{
	var oLi = document.getElementById("tab").getElementsByTagName("li");
	var oUl = document.getElementById("content").getElementsByTagName("ul");
	for(var i = 0; i < oLi.length; i++)
	{
		oLi[i].index = i;
		oLi[i].onmouseover = function ()
		{
			for(var n = 0; n < oLi.length; n++) oLi[n].className="";
			this.className = "current";
			for(var n = 0; n < oUl.length; n++) oUl[n].style.display = "none";
			oUl[this.index].style.display = "block"
		}	
	}
	var oLinewstab1 = document.getElementById("newstab1").getElementsByTagName("li");
	var oUlnewstab1 = document.getElementById("content1").getElementsByTagName("ul");

	for (var i = 0; i < oLinewstab1.length; i++) {
	    oLinewstab1[i].index = i;
	    oLinewstab1[i].onmouseover = function () {
	        for (var n = 0; n < oLinewstab1.length; n++) oLinewstab1[n].className = "";
	        this.className = "content1";
	        for (var n = 0; n < oUlnewstab1.length; n++) oUlnewstab1[n].style.display = "none";
	        oUlnewstab1[this.index].style.display = "block"
	    }
	}
	var oLinewstab2 = document.getElementById("newstab2").getElementsByTagName("li");
	var oUlnewstab2 = document.getElementById("content2").getElementsByTagName("ul");
	for (var i = 0; i < oLinewstab2.length; i++) {
	    oLinewstab2[i].index = i;
	    oLinewstab2[i].onmouseover = function () {
	        for (var n = 0; n < oLinewstab2.length; n++) oLinewstab2[n].className = "";
	        this.className = "content2";
	        for (var n = 0; n < oUlnewstab2.length; n++) oUlnewstab2[n].style.display = "none";
	        oUlnewstab2[this.index].style.display = "block"
	    }
	}
	var oLinewstab3 = document.getElementById("newstab3").getElementsByTagName("li");
	var oUlnewstab3 = document.getElementById("content3").getElementsByTagName("ul");
	for (var i = 0; i < oLinewstab3.length; i++) {
	    oLinewstab3[i].index = i;
	    oLinewstab3[i].onmouseover = function () {
	        for (var n = 0; n < oLinewstab3.length; n++) oLinewstab3[n].className = "";
	        this.className = "content3";
	        for (var n = 0; n < oUlnewstab3.length; n++) oUlnewstab3[n].style.display = "none";
	        oUlnewstab3[this.index].style.display = "block"
	    }
	}
	var oLinewstab4 = document.getElementById("newstab4").getElementsByTagName("li");
	var oUlnewstab4 = document.getElementById("content4").getElementsByTagName("ul");
	for (var i = 0; i < oLinewstab4.length; i++) {
	    oLinewstab4[i].index = i;
	    oLinewstab4[i].onmouseover = function () {
	        for (var n = 0; n < oLinewstab4.length; n++) oLinewstab4[n].className = "";
	        this.className = "content4";
	        for (var n = 0; n < oUlnewstab4.length; n++) oUlnewstab4[n].style.display = "none";
	        oUlnewstab4[this.index].style.display = "block"
	    }
	}
	var oLinewstab5 = document.getElementById("newstab5").getElementsByTagName("li");
	var oUlnewstab5 = document.getElementById("content5").getElementsByTagName("ul");
	for (var i = 0; i < oLinewstab5.length; i++) {
	    oLinewstab5[i].index = i;
	    oLinewstab5[i].onmouseover = function () {
	        for (var n = 0; n < oLinewstab5.length; n++) oLinewstab5[n].className = "";
	        this.className = "content5";
	        for (var n = 0; n < oUlnewstab5.length; n++) oUlnewstab5[n].style.display = "none";
	        oUlnewstab5[this.index].style.display = "block"
	    }
	}
	var oLinewstab6 = document.getElementById("newstab6").getElementsByTagName("li");
	var oUlnewstab6 = document.getElementById("content6").getElementsByTagName("ul");
	for (var i = 0; i < oLinewstab6.length; i++) {
	    oLinewstab6[i].index = i;
	    oLinewstab6[i].onmouseover = function () {
	        for (var n = 0; n < oLinewstab6.length; n++) oLinewstab6[n].className = "";
	        this.className = "content6";
	        for (var n = 0; n < oUlnewstab6.length; n++) oUlnewstab6[n].style.display = "none";
	        oUlnewstab6[this.index].style.display = "block"
	    }
	}
}
