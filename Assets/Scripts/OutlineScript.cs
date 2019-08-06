using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{

    public float thickness;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3 (0f, 0f, 0.08f);
        GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<SpriteRenderer>().sprite;
        transform.localScale += new Vector3(thickness, thickness, thickness);
        if(transform.parent.GetComponent<HoldableObject>().holdable)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
            GetComponent<SpriteRenderer>().color = Color.yellow;
        //GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
