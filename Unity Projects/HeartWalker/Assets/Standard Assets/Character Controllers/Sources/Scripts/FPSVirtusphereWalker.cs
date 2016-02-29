using UnityEngine;
using System.Collections;

/// FPSVirtusphereWalker C# script 
/// Based off of the FPSWalker script
/// FPSVirtusphereWalker uses the mouse movement input from the virtusphere
/// to move around

[RequireComponent(typeof(CharacterController))]
public class FPSVirtusphereWalker : MonoBehaviour
{
    private CharacterController controller;

    public bool flipAxes = false;
    public bool useMouse = false;

    public float speed = 6F;
    public float jumpSpeed = 8F;
    public float gravity = 20F;

    private string strInputHorizontal;
    private string strInputVertical;
    private bool grounded = false;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (useMouse)
        {
            if (flipAxes)
            {
                strInputHorizontal = "Mouse Y";
                strInputVertical = "Mouse X";
            }
            else
            {
                strInputHorizontal = "Mouse X";
                strInputVertical = "Mouse Y";
            }
        }
        else
        {
            if (flipAxes)
            {
                strInputHorizontal = "Vertical";
                strInputVertical = "Horizontal";
            }
            else
            {
                strInputHorizontal = "Horizontal";
                strInputVertical = "Vertical";
            }
        }
    }

    //void FixedUpdate() 
	void Update() 
    {
	    if (grounded) 
        {
		    // We are grounded, so recalculate movedirection directly from axes (x, y, z)
            moveDirection = new Vector3(Input.GetAxis(strInputHorizontal), 0, Input.GetAxis(strInputVertical));
		    moveDirection = transform.TransformDirection(moveDirection);
		    moveDirection *= speed;
    		
		    if (Input.GetButton ("Jump")) {
			    moveDirection.y = jumpSpeed;
		    }
	    }

	    // Apply gravity
	    moveDirection.y -= gravity * Time.deltaTime;
    	
	    // Move the controller
	    var flags = controller.Move(moveDirection * Time.deltaTime);
	    grounded = (flags & CollisionFlags.CollidedBelow) != 0;
		
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu2");
		}
    }
}
