using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    Text scoreText, bestScoreText;
    // Start is called before the first frame update
    void Start () {
        scoreText = GameObject.Find ("CurrScoreText").GetComponent<Text> ();
        bestScoreText = GameObject.Find ("BestScoreText").GetComponent<Text> ();

        if (MinigameTracker.points > MinigameTracker.bestScore)
            MinigameTracker.bestScore = MinigameTracker.points;
        scoreText.text = "" + MinigameTracker.points;
        bestScoreText.text = "" + MinigameTracker.bestScore;
    }

    // Update is called once per frame
    void Update () {

    }
}