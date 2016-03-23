using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UIVA;

/// SmoothHeadTrackerLook C# script 
/// Based off of the SmoothMouseLook script (Unify Community Wiki)
/// HeadTrackerLook rotates the transform based on data read from the UIVA client.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add a rigid body to the capsule
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSWalker script to the capsule

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a HeadTrackerLook script to the camera.
///   -> This script will tilt the camera up and down like a head. 
///   -> The character already turns via the MouseLook script on the FPS controller itself.
///   
///   
[AddComponentMenu("Camera-Control/Smooth Head Tracker Look")]
public class SmoothHeadTrackerLook : MonoBehaviour {
    UIVA_Client uiva;
	
    public enum RotationAxes {  MouseX = 0, MouseY = 1 }
    public RotationAxes axes = RotationAxes.MouseY;
	//public int axes = 1;

    private double[] quaternions;
    private double quatX = 0.0;
    private double quatY = 0.0;
	//private double quatZ = 0.0;
	//private double quatW = 0.0;

    //0 = Freespace, 1 = Intersense(Virtusphere)
    private int trkType; 

    public float sensitivityX = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;

    public float sensitivityY = 15F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationX = 0F;
    float rotationY = 0F;
   
    private List<float> rotArrayX = new List<float>();
    float rotAverageX = 0F; 
   
    private List<float> rotArrayY = new List<float>();
    float rotAverageY = 0F;
   
    public float frameCounter = 20;
   
    Quaternion originalRotation;
	private Quaternion qRightLeft;
	private Quaternion qDownUp;

	// Use this for initialization
	void Start () 
    {
        uiva = UIVA_Client.Instance("localhost");
        quaternions = new double[4];
		
		// Reset origin
		//uiva.ResetHeadTracker(1, ref quaternions);
		
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
    void Update ()
    {
        if (axes == RotationAxes.MouseX)
        {   // Rotate around Y-axis (look right/left) 
     
            rotAverageX = 0f;

			// Get rotation data from input device
			GetDeviceData();      

			// Look right/left where camera rotation is about the y-axis i.e. Vector3(0,1,0)
			// Apply sensitivity factor to quat           
            rotationX += (float)quatY * sensitivityX;
           
            rotArrayX.Add(rotationX);
           
            if (rotArrayX.Count >= frameCounter) {
                rotArrayX.RemoveAt(0);
            }
            for(int i = 0; i < rotArrayX.Count; i++) {
                rotAverageX += rotArrayX[i];
            }
            rotAverageX /= rotArrayX.Count;
           
            rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);

            qRightLeft = Quaternion.AngleAxis (rotAverageX, Vector3.down);
            transform.localRotation = originalRotation * qRightLeft;         
        }
        else
        {   // Rotate around X-axis (look up/down)

            rotAverageY = 0f;

			// Get rotation data from input device
			GetDeviceData();

			// Look up/down where camera rotation is about the x-axis i.e. Vector3(1,0,0)
			// Apply sensitivity factor to quat      

           
            rotationY += (float)quatX * sensitivityY;
           
            rotArrayY.Add(rotationY);
           
            if (rotArrayY.Count >= frameCounter) {
                rotArrayY.RemoveAt(0);
            }
            for(int j = 0; j < rotArrayY.Count; j++) {
                rotAverageY += rotArrayY[j];
            }
            rotAverageY /= rotArrayY.Count;
           
            rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);

            qDownUp = Quaternion.AngleAxis (rotAverageY, Vector3.right);
            transform.localRotation = originalRotation * qDownUp;
        }
    }
   
    void GetDeviceData()
    {
        uiva.GetHeadTrackerData(ref trkType, ref quaternions);
		quatX = quaternions[0];
		quatY = quaternions[1];			
		//quatZ = quaternions[2];
		//quatW = quaternions[3];
        
    }
   
    public static float ClampAngle (float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F)) {
            if (angle < -360F) {
                angle += 360F;
            }
            if (angle > 360F) {
                angle -= 360F;
            }         
        }
        return Mathf.Clamp (angle, min, max);
    }
}