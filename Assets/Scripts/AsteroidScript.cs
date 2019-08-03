using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : HoldableObject {

    protected override void Start () {
        base.Start ();
        rb2d.AddForce (new Vector2 (Random.Range (-5, 5), Random.Range (-5, 0)), ForceMode2D.Impulse);
        StartCoroutine (DieNow ());
    }

    IEnumerator DieNow () {
        yield return new WaitForSeconds (6);
        Destroy (gameObject);
    }
}