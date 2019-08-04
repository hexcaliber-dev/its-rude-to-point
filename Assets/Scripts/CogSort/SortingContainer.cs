using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingContainer : MonoBehaviour {
    public string color;

    void OnCollisionEnter2D (Collision2D collision) {

        print(collision.gameObject.tag);

        if (collision.gameObject.tag != color && (collision.gameObject.tag == "RedCog" || collision.gameObject.tag == "GreenCog" || collision.gameObject.tag == "BlueCog")) {
            StartCoroutine (GameObject.Find ("Main Camera").GetComponent<CameraShake> ().Shake (.15f, .4f));
            (GameObject.FindObjectOfType (typeof (CountDownMiniGame)) as CountDownMiniGame).DeductPoint ();
        }

            Destroy (collision.gameObject);
    }
}