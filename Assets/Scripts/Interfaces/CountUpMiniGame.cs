using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// DOES NOT INHERIT MINIGAMETRACKER because it is completely separate!
public class CountUpMiniGame : MonoBehaviour {
    MinigameTracker tracker;
    Text timer;

    Text oneText, twoText, threeText;

    /// Number of seconds required to achieve each of these point values
    public int onePt, twoPt, threePt;
    /// Set a unique consecutive numerical ID for this minigame!
    public int gameID;
    int currPoints;

    float timeElapsed;

    // Start is called before the first frame update
    void Start () {
        tracker = GameObject.FindObjectOfType (typeof (MinigameTracker)) as MinigameTracker;
        timer = GameObject.Find ("Timer").GetComponent<Text> ();
        oneText = GameObject.Find ("1Text").GetComponent<Text> ();
        twoText = GameObject.Find ("2Text").GetComponent<Text> ();
        threeText = GameObject.Find ("3Text").GetComponent<Text> ();

        currPoints = 0;
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update () {
        // Timer
        timeElapsed += Time.deltaTime;

        string minutes = Mathf.Floor (timeElapsed / 60).ToString ("00");
        string seconds = (timeElapsed % 60).ToString ("00");
        timer.text = "" + minutes + ":" + seconds;

        // Update visuals and points
        if (currPoints < 1 && timeElapsed > onePt) {
            oneText.color = MinigameTracker.ACHIEVED_COLOR;
            currPoints++;
        } else if (currPoints < 2 && timeElapsed > twoPt) {
            twoText.color = MinigameTracker.ACHIEVED_COLOR;
            currPoints++;
        } else if (currPoints < 3 && timeElapsed > threePt) {
            threeText.color = MinigameTracker.ACHIEVED_COLOR;
            currPoints++;
        }

        // Check for loss
        if (LoseCondition ()) {
            Lose ();
        }
    }

    /// Specify how to check for loss.
    virtual protected bool LoseCondition () {
        return false;
    }

    /// Called either when LoseCondition() returns true OR if manually called by an external script.
    virtual public void Lose () {
        MinigameTracker.lastGamePlayed = gameID;
        if (currPoints < 1)
            tracker.LoseLife ();
        else
            tracker.addPoints (currPoints);
        StartCoroutine (tracker.ShowLoseScreen ());
    }
}