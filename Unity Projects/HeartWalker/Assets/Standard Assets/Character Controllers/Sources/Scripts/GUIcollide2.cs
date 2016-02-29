using UnityEngine;
using System.Collections;

public class GUIcollide2 : MonoBehaviour
{

public static bool on; //switch the messages on and off
public static string text; //text to be displayed
GUIText messages; // this will hold the GUIText component, to access its text

void Start()
{
	
	messages=(GUIText)GetComponent("GUIText");
	
}

void Update()
{
	
	if(on)
	{
		messages.enabled=true;
		messages.text= "text";
	}
	
	else
	{
		messages.enabled=false;
	}

}

void onCollisionEnter (Collision col)
{

	GUIcollide2.text = "Text 1";
	GUIcollide2.on = true;
	
}
}