﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Perpetual Music").GetComponent<PerpetualMusic>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
