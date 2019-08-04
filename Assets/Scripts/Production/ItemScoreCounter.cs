using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScoreCounter : MonoBehaviour
{
    public string counting;


    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == counting)
        {
            StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(.15f, .4f));
            (GameObject.FindObjectOfType(typeof(CountDownMiniGame)) as CountDownMiniGame).DeductPoint();
        }
        Destroy(collision.gameObject);
    }
    
}
