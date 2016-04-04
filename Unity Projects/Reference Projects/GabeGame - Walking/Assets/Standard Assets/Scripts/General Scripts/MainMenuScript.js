var newSkin : GUISkin;
//var logoTexture : Texture2D;

function theFirstMenu() {
    //layout start
    GUI.BeginGroup(Rect((Screen.width / 2) - 400, Screen.height / 2 - 300, 800, 600));
   
    //the menu background box
    //GUI.Box(Rect(0, 0, 800, 600), "");
    GUI.Box(Rect((Screen.width / 2) - 400, Screen.height / 2 - 300, 800, 600),"");
   
    GUI.Label(Rect(275, 80, 700, 80), "HeartWalker");
   
    ///////main menu buttons 
    //game start button
    if(GUI.Button(Rect(310, 250, 180, 50), "Left Atrium")) 
    {
	    //var script = GetComponent("MainMenuScript");
	    //script.enabled = false;
	    //var script2 = GetComponent("LocationMenuScript");
	    //script2.enabled = true;
	    SceneManager.LoadScene("LeftAtrium4b");
    }
    //quit button
    if(GUI.Button(Rect(310, 400, 180, 50), "Exit")) 
    {
    	Application.Quit();
    }
   
    //layout end
    GUI.EndGroup();
}

function OnGUI () {
    //load GUI skin
    GUI.skin = newSkin;
   
    //execute theFirstMenu function
    theFirstMenu();
}