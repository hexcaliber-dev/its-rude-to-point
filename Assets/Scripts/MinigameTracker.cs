using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameTracker : MonoBehaviour {
    public static Color ACHIEVED_COLOR = new Color32 (42, 245, 20, 255);
    public static Color DENIED_COLOR = new Color32 (245, 50, 20, 255);
    public static int lastGamePlayed = -1;
    public enum MinigameList { SaveTheWorld, PaperBasketBall, GearProduction, Juggling, CogSort }
    public static int lives = 5;
    public static int points = 0;

    public static int bestScore = 0;

    private const int GAME_OVER_SCENE = 1;

    private const string LOSS_TEXT = "Was that a misclick?";
    private const string WIN_TEXT = "Finger-clicking good!";

    public Transform loseScreen;

    public Text livesLeft, splashText, scoreText, bestScoreText, instructionText;
    public Image livesLeftImage, checkImage, xImage;

    public Sprite[] livesLeftSprites;

    public Sprite victoryBG, defeatBG;

    public bool isTutorial = false;

    void Start () {
        bestScoreText.text = "" + bestScore;

        StartCoroutine (HideInstructions ());
    }

    // Update is called once per frame
    void Update () {
        if (lives == 0) {
            SceneManager.LoadScene (GAME_OVER_SCENE);
        }
    }

    public void SwitchMiniGame () {
        int x = lastGamePlayed;
        while (x == lastGamePlayed)
            x = Random.Range (0, MinigameList.GetNames (typeof (MinigameList)).Length);
        SceneManager.LoadScene (x + 2);
    }

    public void LoseLife () {
        lives--;
        splashText.text = LOSS_TEXT;
        loseScreen.GetComponent<Image> ().sprite = defeatBG;
        StartCoroutine (ShowOverlay (xImage));
    }

    public void addPoints (int pts) {
        splashText.text = WIN_TEXT;
        points += pts;
        scoreText.text = "" + points;
        loseScreen.GetComponent<Image> ().sprite = victoryBG;
        StartCoroutine (ShowOverlay (checkImage));
    }

    public IEnumerator ShowLoseScreen () {

        if (!loseScreen.gameObject.activeSelf) {

            livesLeft.text = "" + lives;

            livesLeftImage.sprite = livesLeftSprites[lives];

            loseScreen.gameObject.SetActive (true);
            loseScreen.localScale = new Vector3 (0, 0, 1);
            loseScreen.Translate (-5f, 0, 0);

            int frame = 0;
            while (frame < 30) {
                loseScreen.Translate (5f / 30, 0, 0);
                loseScreen.Rotate (new Vector3 (0, 0, 360f / 30));
                loseScreen.localScale += new Vector3 (1f / 30, 1f / 30, 0);
                frame++;
                yield return new WaitForSeconds (1f / 60);
            }

            yield return new WaitForSeconds (3);
            SwitchMiniGame ();
            loseScreen.gameObject.SetActive (false);
        }

    }

    IEnumerator ShowOverlay (Image img) {

        yield return new WaitForSeconds (0.5f);
        int frame = 0;
        img.enabled = true;
        img.transform.localScale = new Vector2 (0, 0);
        while (frame < 10) {
            img.transform.localScale += new Vector3 (6 / 10f, 6 / 10f, 0);
            frame++;
            yield return new WaitForSeconds (1f / 60);
        }
        yield return new WaitForSeconds (1);
        img.enabled = false;
    }

    IEnumerator HideInstructions () {

        int frame = 0;
        instructionText.transform.localScale = new Vector2 (0, 0);
        while (frame < 30) {
            instructionText.transform.Rotate (new Vector3 (0, 0, 360f / 30));
            instructionText.transform.localScale += new Vector3 (.16f / 30, .16f / 30, 0);
            frame++;
            yield return new WaitForSeconds (1f / 60);
        }

        if(!isTutorial) {
            yield return new WaitForSeconds (5);
            instructionText.gameObject.SetActive (false);
        }
    }
}