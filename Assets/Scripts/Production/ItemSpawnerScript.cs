using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {

    public float speed;
    public GameObject goodItem;
    public GameObject badItem;
    public float nextActionTime;
    public float period;

    float timeElapsed;
    // Start is called before the first frame update
    void Start () {
        timeElapsed = 0f;
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