using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOutputInput : MonoBehaviour
{
    int seconds;
    bool lightOn;
    AudioSource asource;
    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
        seconds = Random.Range(2, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spook()
    {
        yield return new WaitForSeconds(seconds);
        asource.Play();
        yield return new WaitForSeconds(1);
        if(lightOn)
        {
            //win
        }

    }
}
