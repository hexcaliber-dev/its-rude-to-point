using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSwitch : MonoBehaviour {

    public bool isNewGame = false;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Switch") {

            MinigameTracker.points = 0;
            MinigameTracker.lives = 5;

            if (isNewGame) {
                int x = Random.Range (0, MinigameTracker.MinigameList.GetNames (typeof (MinigameTracker.MinigameList)).Length);
                SceneManager.LoadScene (x + 3);
            } else {
                SceneManager.LoadScene (0);
            }
        }
    }
}