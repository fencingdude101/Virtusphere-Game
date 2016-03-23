using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	private int playMinutes;
	private int playSeconds;
	private int startSeconds;
	public int playTime;
	
	// Use this for initialization
	void Start () 
	{
		if( !GetComponent<GUIText>() )
        {
            Debug.Log("This timer requires a GUIText component");
            enabled = false;
            return;
        }
		playMinutes = playTime;
		startSeconds = playMinutes *60;
		InvokeRepeating("Countdown",1,1);
	}
	
	void Countdown()
	{
		if (--startSeconds ==0) CancelInvoke ("Countdown");
		playMinutes = (int) (startSeconds / 60f);
		playSeconds = (int) (startSeconds % 60f);
		GetComponent<GUIText>().text = playMinutes.ToString()+":"+playSeconds.ToString("00");
	}
	
}
