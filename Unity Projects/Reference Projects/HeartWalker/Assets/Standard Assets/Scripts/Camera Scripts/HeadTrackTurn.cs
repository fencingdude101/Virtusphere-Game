using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UIVA;

/// HeadTrackTurn C# script 
/// This script goes on the character controller
/// HeadTrackTurn will turn the character controller right or left based on data read from the UIVA client.

///   
[AddComponentMenu("Camera-Control/HeadTrackTurn")]
public class HeadTrackTurn : MonoBehaviour {
    UIVA_Client uiva;

    private double[] quaternions;
	private Quaternion newRotation = Quaternion.identity;
	
    //0 = Freespace, 1 = Intersense(Virtusphere)
    private int trkType; 

	// Use this for initialization
	void Start () 
    {
        uiva = UIVA_Client.Instance("localhost");
        quaternions = new double[4];
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		// Get rotation data from input device
		GetDeviceData();
		// Assign new rotation directly to object
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -1 * newRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		
		PossibleQuit();
	}

    void GetDeviceData()
    {
        uiva.GetHeadTrackerData(ref trkType, ref quaternions);
		
		// get rotation from device as a quaternion
		newRotation = new Quaternion((float)quaternions[0], (float)quaternions[1], (float)quaternions[2], (float)quaternions[3]);
    }

    void PossibleQuit()
    {
        if (Input.GetKeyDown("escape"))
        {
            uiva.Disconnect();
        }
    }
		
}
