using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnScript : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        aSource.Play();
    }
}
