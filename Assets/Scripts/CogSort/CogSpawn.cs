using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSpawn : MonoBehaviour {

    public float speed;
    public GameObject redCog, greenCog, blueCog;
    public float nextActionTime;
    public float period = 2f;

    float timeElapsed;
    // Start is called before the first frame update
    void Start () {
        timeElapsed = 0f;

        if(MinigameTracker.numPlayed > 3) {
            period = 1.5f;
        }
        if(MinigameTracker.numPlayed > 6) {
            period = 1f;
        }
        if(MinigameTracker.numPlayed > 9) {
            period = 0.75f;
        }
        if(MinigameTracker.numPlayed > 12) {
            period = 0.5f;
        }
    }

    // Update is called once per frame
    void Update () {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > nextActionTime && !(GameObject.FindObjectOfType (typeof (CountDownMiniGame)) as CountDownMiniGame).hasLost) {
            nextActionTime += period;

            int rand = Random.Range (1, 4);

            switch (rand) {
                case 1:
                    GameObject red = Instantiate (redCog, transform.position, Quaternion.identity);
                    break;
                case 2:
                    GameObject green = Instantiate (greenCog, transform.position, Quaternion.identity);
                    break;
                case 3:
                    GameObject blue = Instantiate (blueCog, transform.position, Quaternion.identity);
                    break;
            } 
            period -= speed;
        }
    }
}