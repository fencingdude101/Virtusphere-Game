using UnityEngine; //must happen in C# script
using System.Collections; //must happen in C# script

public class GUIcollide : MonoBehaviour //must happen in C# script
{
	
	public GUIText myGUItext;
	//public GUITexture texture;
	public int guiTime = 5;

	// Use this for initialization
	void Start () 
	{
	
		myGUItext.gameObject.SetActive(false);
		//texture.gameObject.active = false;
	
	}
	
	void onCollisionEnter( Collider c ) 
	{
	
		myGUItext.text = "Display msg here";
		myGUItext.gameObject.SetActive(true);
		//texture.gameObject.active = true;
		// Start coroutine for deactivating gui elements
		StartCoroutine(GuiDisplayTimer());
		
	}
		
		IEnumerator GuiDisplayTimer() 
	{
			
			//Waits an amount of tmie
			yield return new WaitForSeconds(guiTime);
			//Deactivate GUI objects
			myGUItext.gameObject.SetActive(false);
			//texture.gameObject.active = false;
			
	}
	
}
