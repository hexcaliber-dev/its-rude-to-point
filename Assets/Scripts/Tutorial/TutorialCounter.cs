using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCounter : MonoBehaviour {

   int count = 0;

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Good") {
            count++;
            Destroy(collision.gameObject);
        }
        if(count == 2)
            (GameObject.FindObjectOfType(typeof(Tutorial)) as Tutorial).Lose();
    }
}