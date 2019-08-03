using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameTracker : MonoBehaviour
{
    public int lastGamePlayed;
    public enum MinigameList {SaveTheWorld, PaperBasketBall};
    public static int lives = 5;

    private const int GAME_OVER_SCENE = 1;


    // Update is called once per frame
    virtual protected void Update()
    {
        if (lives == 0)
        {
            SceneManager.LoadScene(GAME_OVER_SCENE);
        }
    }

    virtual protected void SwitchMiniGame ()
    {
        int x = lastGamePlayed;
        while (x == lastGamePlayed)
            x = Random.Range(0, MinigameList.GetNames(typeof(MinigameList)).Length);
        SceneManager.LoadScene(x+1);
        
    }
}
