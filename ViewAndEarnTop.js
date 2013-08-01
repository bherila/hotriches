var secs = 30;
var rp = 0;
function secnd() 
{if (secs >= 1){var pb = document.getElementById('btnPause');if (pb.value == 'Pause')
{var secWord = ' seconds';secs--;if (secs == 1) {secWord = ' second';}
document.getElementById('txtTimer').innerHTML = 'Next page in ' + secs + secWord;}
}
else{
rp++;
credits = credits + 0.8;
top.frames[1].location.replace('NextSite.aspx?id=' + uid + '&email=' + uemail + '&rnd=' + rp);
document.getElementById('txtCredits').innerHTML = 'Account Credits: ' + credits;
secs = 30;
}
}
function pauseResume() {var pb = document.getElementById('btnPause');if (pb.value == 'Pause'){pb.value = 'Resume';}else{pb.value = 'Pause';}}
function openSite() {window.open(top.frames[1].location.href);}