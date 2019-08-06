using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : CountUpMiniGame {
    GameObject getReadyScreen;
    Text countdown;

    // Start is called before the first frame update
    protected override void Start () {
        base.Start ();
        getReadyScreen = GameObject.Find ("Get Ready");
        countdown = GameObject.Find ("Countdown").GetComponent<Text> ();
        StartCoroutine (CountDown ());
    }

    // Update is called once per frame
    protected override void Update () {
        // Timer
        timeElapsed += Time.deltaTime;

        string minutes = Mathf.Floor (timeElapsed / 60).ToString ("00");
        string seconds = (timeElapsed % 60).ToString ("00");
        timer.text = "" + minutes + ":" + seconds;
        
        if (Input.GetKey (KeyCode.Escape))
            Lose ();
    }

    IEnumerator CountDown () {
        yield return new WaitForSeconds (1);
        countdown.text = "2";
        yield return new WaitForSeconds (1);
        countdown.text = "1";
        yield return new WaitForSeconds (1);
        getReadyScreen.SetActive (false);
    }

    public override void Lose () {
        if (!hasLost) {
            MinigameTracker.tutorialPlayed = true;
            hasLost = true;
            MinigameTracker.lastGamePlayed = gameID;
            tracker.addPoints (0);
            StartCoroutine (tracker.ShowLoseScreen ());
        }
    }
}