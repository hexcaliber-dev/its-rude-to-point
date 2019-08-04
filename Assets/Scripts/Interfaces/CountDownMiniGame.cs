using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// DOES NOT INHERIT MINIGAMETRACKER because it is completely separate!
public class CountDownMiniGame : MonoBehaviour {
    MinigameTracker tracker;
    Text timer;

    Text oneText, twoText, threeText;

    /// Number of seconds required to achieve each of these point values. onePt should be the least, threePt the greatest.
    public int onePt, twoPt, threePt;
    RawImage oneImg;
    Image twoImg, threeImg;
    /// Set a unique consecutive numerical ID for this minigame!
    public int gameID;
    protected int currPoints;

    protected float timeRemaining;

    public bool hasLost;

    /// Starting time, in seconds. Game will end when the time is up! 
    public float startingTime = 10f;

    /// Set to true if points should be automatically deducted when a certain time is reached.
    public bool timeBasedPoints = false;

    // Start is called before the first frame update
    void Start () {
        tracker = GameObject.FindObjectOfType (typeof (MinigameTracker)) as MinigameTracker;
        timer = GameObject.Find ("Timer").GetComponent<Text> ();
        oneText = GameObject.Find ("1Text").GetComponent<Text> ();
        twoText = GameObject.Find ("2Text").GetComponent<Text> ();
        threeText = GameObject.Find ("3Text").GetComponent<Text> ();
        oneImg = GameObject.Find ("1Img").GetComponent<RawImage> ();
        twoImg = GameObject.Find ("2Img").GetComponent<Image> ();
        threeImg = GameObject.Find ("3Img").GetComponent<Image> ();

        currPoints = 3;
        timeRemaining = startingTime;
        hasLost = false;
    }

    // Update is called once per frame
    void Update () {
        // Timer
        
        timeRemaining -= Time.deltaTime;

        string minutes = Mathf.Floor (timeRemaining / 60).ToString ("00");
        string seconds = (timeRemaining % 60).ToString ("00");
        timer.text = "" + minutes + ":" + seconds;

        if (timeBasedPoints) {
            // Update visuals and points
            if (currPoints > 2 && timeRemaining < threePt) {
                threeText.color = MinigameTracker.DENIED_COLOR;
                threeImg.color = MinigameTracker.DENIED_COLOR;
                currPoints--;
            } else if (currPoints > 1 && timeRemaining < twoPt) {
                twoText.color = MinigameTracker.DENIED_COLOR;
                twoImg.color = MinigameTracker.DENIED_COLOR;
                currPoints--;
            } else if (currPoints > 0 && timeRemaining < onePt) {
                oneText.color = MinigameTracker.DENIED_COLOR;
                oneImg.color = MinigameTracker.DENIED_COLOR;
                currPoints--;
            }
        }

        // Check for loss
        if (LoseCondition ()) {
            Lose ();
        }
    }

    /// Specify how to check for loss. Default: lose when time runs out.
    virtual protected bool LoseCondition () {
        return timeRemaining <= 0 || currPoints <= 0;
    }

    virtual public void DeductPoint () {
        currPoints--;
        if (currPoints == 2) {
            threeText.color = MinigameTracker.DENIED_COLOR;
            threeImg.color = MinigameTracker.DENIED_COLOR;
        }
        else if (currPoints == 1) {
            twoText.color = MinigameTracker.DENIED_COLOR;
            twoImg.color = MinigameTracker.DENIED_COLOR;
        }
        else if (currPoints == 0) {
            oneText.color = MinigameTracker.DENIED_COLOR;
            oneImg.color = MinigameTracker.DENIED_COLOR;
        }
    }

    /// Called either when LoseCondition() returns true OR if manually called by an external script.
    virtual public void Lose () {
        if (!hasLost) {
            hasLost = true;
            MinigameTracker.lastGamePlayed = gameID;
            if (currPoints < 1)
                tracker.LoseLife ();
            else
                tracker.addPoints (currPoints);
            StartCoroutine (tracker.ShowLoseScreen ());
        }
    }
}