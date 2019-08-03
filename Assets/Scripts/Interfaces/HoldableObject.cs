using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// All objects that are interactable by the finger should inherit this class.
public class HoldableObject : MonoBehaviour {
    protected bool isHeld;
    protected Transform heldObjPos;
    protected AudioSource audioSrc;
    protected ParticleSystem particleSrc;
    protected Rigidbody2D rb2d;

    /// Strength of the collision required to register as a collision and not a bump.
    public float collisionStrength = 3f;

    /// Strength of flick
    public float flickStrength = 10f;

    /// Distance between hand and object where object can be interacted with
    public float minDistanceToHold = 3f;

    /// Strength when moving from held to flicked. Should be less than flickStrength
    public float holdFlickStrength = 5f;
    public bool holdable;

    // Start is called before the first frame update
    virtual protected void Start () {
        audioSrc = GetComponent<AudioSource> ();
        //particleSrc = GetComponent<ParticleSystem> ();
        rb2d = GetComponent<Rigidbody2D> ();
        //particleSrc.Stop ();

        heldObjPos = GameObject.Find ("Held Object Position").transform;
    }

    // Update is called once per frame
    virtual protected void Update () {
        if (isHeld && holdable) {
            transform.position = heldObjPos.position;
            rb2d.velocity = Vector2.zero;
        }
    }

    virtual protected void OnCollisionEnter2D (Collision2D collision) {
        if (collision.relativeVelocity.magnitude > collisionStrength) {
            Collide ();
        }
    }

    /// Override this method to set custom collision behavior
    virtual protected void Collide () {
        audioSrc.Play ();
        //StartCoroutine(ImpactParticles());
    }

    /// Override this method to set custom flick behavior
    virtual public void Flick (Vector2 direction) {

        print("FLICK");
        
        if (isHeld) {
            rb2d.AddForce (direction * holdFlickStrength, ForceMode2D.Impulse);
        } else {
            rb2d.AddForce (direction * flickStrength, ForceMode2D.Impulse);
        }
    }

    /// Override this method to set custom hold behavior
    virtual public void Hold () {
        isHeld = true;
    }

    /// Override this method to set custom behavior when hand lets go of object
    virtual public void LetGo () {
        isHeld = false;
    }

    /// Override this method to set custom behavior when finger is extended
    virtual public void Click () {
        // Default: do nothing
    }

    /// Shows particles for the specified number of seconds.
    virtual protected IEnumerator ShowParticles (float seconds) {
        particleSrc.Play ();
        yield return new WaitForSeconds (seconds);
        particleSrc.Stop ();
    }
}