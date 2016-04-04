#pragma strict

function OnCollisionEnter(other : Collision){
    if(other.gameObject.name == "Rainbow")
        Application.LoadLevel ("WeirdScene");
}