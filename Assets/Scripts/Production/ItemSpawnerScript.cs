using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {

    public float speed;
    public GameObject goodItem;
    public GameObject badItem;
    public float nextActionTime;
    public float period = 1f;

    float timeElapsed;
    // Start is called before the first frame update
    void Start () {
        timeElapsed = 0f;

        if (MinigameTracker.numPlayed > 3) {
            period = 0.8f;
        }
        if (MinigameTracker.numPlayed > 6) {
            period = 0.6f;
        }
        if (MinigameTracker.numPlayed > 9) {
            period = 0.5f;
        }
        if (MinigameTracker.numPlayed > 12) {
            period = 0.4f;
        }
    }

    // Update is called once per frame
    void Update () {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > nextActionTime && !(GameObject.FindObjectOfType (typeof (CountDownMiniGame)) as CountDownMiniGame).hasLost) {
            nextActionTime += period;
            if (Random.Range (1, 5) == 1) { GameObject defect = Instantiate (badItem, gameObject.transform.position, Quaternion.identity); } else { GameObject regular = Instantiate (goodItem, gameObject.transform.position, Quaternion.identity); }
            period -= speed;
        }
    }

}