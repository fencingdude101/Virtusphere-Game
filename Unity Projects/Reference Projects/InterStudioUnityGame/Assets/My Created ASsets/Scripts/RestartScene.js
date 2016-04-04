#pragma strict

 function OnCollisionEnter(other : Collision){
 if(other.gameObject.name == "Finish2")
 Application.LoadLevel ("Scene2");
 }