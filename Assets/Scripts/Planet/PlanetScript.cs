using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : HoldableObject
{
    public int health;
    
    void OnTriggerStay2D (Collider2D collision) {
        if(collision.tag ==  "Asteroid") {
            Destroy(gameObject);
            GameObject.Find("CountUpMinigame").GetComponent<CountUpMiniGame>().Lose();
        }
        //Debug.Log(collision);
        
    }
}