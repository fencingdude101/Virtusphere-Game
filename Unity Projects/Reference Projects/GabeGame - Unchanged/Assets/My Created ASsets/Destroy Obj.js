
var score = 0;

function OnTriggerEnter( other : Collider ) {
    if (other.tag == "Coin") {
        score += 5;
        Destroy(other.gameObject);
    }
}
