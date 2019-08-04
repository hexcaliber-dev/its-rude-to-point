using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(.15f, .4f));
        GameObject.Find("CountDownMinigame").GetComponent<CountDownMiniGame>().DeductPoint();
        Destroy(col.gameObject);
    }
}
