using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBasket : MonoBehaviour {

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Good") {
            (GameObject.FindObjectOfType (typeof (CountDownMiniGame)) as CountDownMiniGame).Lose();
        }
    }
}