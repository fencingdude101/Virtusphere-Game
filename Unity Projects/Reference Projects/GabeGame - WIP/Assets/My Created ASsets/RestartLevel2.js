#pragma strict

function OnCollisionEnter(other : Collision){
    if(other.gameObject.name == "respawn")
        Application.LoadLevel ("Scene2");
}