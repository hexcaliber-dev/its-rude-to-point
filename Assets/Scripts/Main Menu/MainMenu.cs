using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Transform center, switchObj;
    GameObject bottom;
    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.Find("Center").transform;
        switchObj = GameObject.Find("Switch").transform;
        bottom = GameObject.Find("Bottom Text");

        center.localScale = switchObj.localScale = new Vector3(0, 0, 1);
        bottom.SetActive(false);

        StartCoroutine(BeginningAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BeginningAnimation() {

        int frame = 0;

        while(frame < 60) {

            center.localScale += new Vector3(1f/60, 1f/60, 0);
            switchObj.localScale += new Vector3(1f/60, 1f/60, 0);
            center.Rotate(0, 0, 360f/60f*5f);
            switchObj.Rotate(0, 0, 360f/60f*5f);
            
            frame++;
            yield return new WaitForSeconds(1f/60);
        }

        bottom.SetActive(true);
    }
}
