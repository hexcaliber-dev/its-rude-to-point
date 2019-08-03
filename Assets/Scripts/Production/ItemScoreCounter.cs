using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScoreCounter : MonoBehaviour
{
    public static int mistakes;
    public string counting;

    // Start is called before the first frame update
    void Start()
    {
         mistakes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == counting)
        {
            mistakes++;
            Debug.Log(mistakes);
        }
        Destroy(collision.gameObject);
    }
    
}
