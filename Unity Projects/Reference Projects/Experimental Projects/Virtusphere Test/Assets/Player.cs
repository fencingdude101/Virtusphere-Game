using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]private float playerspeed;
    private float playertranslation;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        movePlayer();
	}

    void movePlayer(){
        calculatePlayerMovement();
        
        transform.Translate(0, 0, playertranslation);
    }

    void calculatePlayerMovement(){
		playertranslation = Input.GetAxis("Vertical") * playerspeed * Time.deltaTime;
    }
}
