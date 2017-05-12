# VideoPlayer
VideoPlayer for iOS and Android 

For work nice, needs to be installed the component Vitamio at components on your iOS and Android Projects, dont need be installed on PCL.

Setup.
Only for android needs this lines on MainActivity: 
if (!LibsChecker.CheckVitamioLibs(this))
						return;
