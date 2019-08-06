using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// DOES NOT INHERIT MINIGAMETRACKER because it is completely separate!
public class CountUpMiniGame : MonoBehaviour {
    protected MinigameTracker tracker;
    protected Text timer;

    Text oneText, twoText, threeText;
    RawImage oneImg;
    Image twoImg, threeImg;

    protected bool hasLost;

    /// Number of seconds required to achieve each of these point values
    public int onePt, twoPt, threePt;
    /// Set a unique consecutive numerical ID for this minigame!
    public int gameID;
    protected int currPoints;

    protected float timeElapsed;

    // Start is called before the first frame update
    virtual protected void Start () {
        tracker = GameObject.FindObjectOfType (typeof (MinigameTracker)) as MinigameTracker;
        timer = GameObject.Find ("Timer").GetComponent<Text> ();
        oneText = GameObject.Find ("1Text").GetComponent<Text> ();
        twoText = GameObject.Find ("2Text").GetComponent<Text> ();
        threeText = GameObject.Find ("3Text").GetComponent<Text> ();
        oneImg = GameObject.Find ("1Img").GetComponent<RawImage> ();
        twoImg = GameObject.Find ("2Img").GetComponent<Image> ();
        threeImg = GameObject.Find ("3Img").GetComponent<Image> ();

        currPoints = 0;
        timeElapsed = 0;
        hasLost = false;
    }

    // Update is called once per frame
    virtual protected void Update () {
        // Timer
        timeElapsed += Time.deltaTime;

        string minutes = Mathf.Floor (timeElapsed / 60).ToString ("00");
        string seconds = (timeElapsed % 60).ToString ("00");
        timer.text = "" + minutes + ":" + seconds;

        // Update visuals and points
        if (currPoints < 1 && timeElapsed > onePt) {
            oneText.color = MinigameTracker.ACHIEVED_COLOR;
            oneImg.color = MinigameTracker.ACHIEVED_COLOR;
            currPoints++;
        } else if (currPoints < 2 && timeElapsed > twoPt) {
            twoText.color = MinigameTracker.ACHIEVED_COLOR;
            twoImg.color = MinigameTracker.ACHIEVED_COLOR;
            currPoints++;
        } else if (currPoints < 3 && timeElapsed > threePt) {
            threeText.color = MinigameTracker.ACHIEVED_COLOR;
            threeImg.color = MinigameTracker.ACHIEVED_COLOR;
            currPoints++;
            Lose(); // No point in keeping on going after getting 3 pts!
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
        if(!hasLost) {
            hasLost = true;
            GetComponent<AudioSource>().Stop();
            MinigameTracker.lastGamePlayed = gameID;
            if (currPoints < 1)
                tracker.LoseLife ();
            else
                tracker.addPoints (currPoints);
            StartCoroutine (tracker.ShowLoseScreen ());
        }
    }
}