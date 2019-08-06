using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Switch") {

            if (!MinigameTracker.tutorialPlayed)
                SceneManager.LoadScene (1);

            else {
                int x = Random.Range (0, MinigameTracker.MinigameList.GetNames (typeof (MinigameTracker.MinigameList)).Length);
                SceneManager.LoadScene (x + 3);
            }

        }
    }
}