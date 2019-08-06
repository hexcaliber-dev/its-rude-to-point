using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls;
    public int numBalls;
    // Start is called before the first frame update
    void Start()
    {
        numBalls = 3;

        if(MinigameTracker.numPlayed > 3) {
            Instantiate(balls[Random.Range(0, 3)], transform.position, Quaternion.identity);
            numBalls++;
        }
        if(MinigameTracker.numPlayed > 6) {
            Instantiate(balls[Random.Range(0, 3)], transform.position, Quaternion.identity);
            numBalls++;
        }
        if(MinigameTracker.numPlayed > 9) {
            Instantiate(balls[Random.Range(0, 3)], transform.position, Quaternion.identity);
            numBalls++;
        }
        if(MinigameTracker.numPlayed > 12) {
            Instantiate(balls[Random.Range(0, 3)], transform.position, Quaternion.identity);
            numBalls++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
