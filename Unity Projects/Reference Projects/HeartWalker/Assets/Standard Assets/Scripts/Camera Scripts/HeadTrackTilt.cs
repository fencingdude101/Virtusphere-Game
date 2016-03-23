using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UIVA;

/// HeadTrackTilt C# script 
/// This script goes on the camera which is a child of the character controller
/// HeadTrackTilt will tilt the camera up and down based on data read from the UIVA client.

///   
[AddComponentMenu("Camera-Control/HeadTrackTilt")]
public class HeadTrackTilt : MonoBehaviour {
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
		// Assign new rotation to object 
		transform.rotation = Quaternion.Euler(newRotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		
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
