using UnityEngine;
using System.Collections;

public class HeartGUI : MonoBehaviour {

	public CharacterController vsWalker;
	
	void Start()
	{
		vsWalker = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		if(vsWalker)
		{
			if(vsWalker.tag == "LeftA")
			{
				GetComponent<GUIText>().text = "Left Atrium";
			}
		
			if(vsWalker.tag == "LeftV")
			{
				GetComponent<GUIText>().text = "Left Ventricle";
			}
	
			if(vsWalker.tag == "RightA")
			{
				GetComponent<GUIText>().text = "Left Atrium";		
			}
		
			if(vsWalker.tag == "RightV")
			{
				GetComponent<GUIText>().text = "Right Ventricle";
			}
		}

	}
}
