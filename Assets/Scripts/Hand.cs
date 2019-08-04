using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    GameObject FingerTip, FingerMid, FingerBack;
    Animator animator;
    public enum FingerState { Idle, Extended, Clenched, Flicked }
    FingerState currState;
    bool isReversed;
    Quaternion currRotation;

    float moveSpeed = 0.5f;
    float rotateSpeed = 15f;

    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start () {
        currState = FingerState.Idle;
        FingerTip = GameObject.Find ("fingertip");
        FingerMid = GameObject.Find ("fingermid");
        FingerBack = GameObject.Find ("fingerback");
        animator = GetComponent<Animator> ();
        currRotation = Quaternion.identity;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {

        HoldableObject currObj = GetHoldableObject ();

        // position
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
        transform.position = Vector3.Lerp (transform.position, mousePosition, moveSpeed) - (FingerTip.transform.position - transform.position);

        //rotation
        currRotation *= Quaternion.Euler (0, 0, Input.mouseScrollDelta.y * rotateSpeed);
        Vector2 objectPos = Camera.main.WorldToScreenPoint (FingerTip.transform.position);
        mousePosition -= objectPos;

        float angle = Mathf.Atan2 (mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (new Vector3 (0, 0, angle)) * currRotation, moveSpeed);

        // Clenching
        if (Input.GetKeyDown (KeyCode.Mouse0)) {
            animator.SetBool ("isClenched", true);
            if (currObj != null)
                currObj.Hold ();
        }
        if (Input.GetKeyUp (KeyCode.Mouse0)) {
            animator.SetBool ("isClenched", false);
            if (currObj != null)
                currObj.LetGo ();
        }

        // Stretch or flick
        if (Input.GetKeyDown (KeyCode.Mouse1)) {
            if (!animator.GetBool ("isFlicked")) {
                animator.SetBool ("isClenched", true);
                animator.SetBool ("isFlicked", true);
                GetComponent<ParticleSystem>().Play();
                    Debug.Log("wtf");
                if (currObj != null) {
                    currObj.Flick (new Vector2 (-Mathf.Cos (transform.eulerAngles.z * Mathf.Deg2Rad), -Mathf.Sin (transform.eulerAngles.z * Mathf.Deg2Rad)));
                    currObj.LetGo ();
                }

                StartCoroutine (DelayUnclench ());

            }
        }
        if (Input.GetKeyUp (KeyCode.Mouse1)) {
            animator.SetBool ("isFlicked", false);
        }

        if (animator.GetBool ("isClenched"))
            currState = FingerState.Clenched;
        if (animator.GetBool ("isFlicked"))
            currState = FingerState.Flicked;

    }

    // Returns null if no object is in range; returns the object to hold otherwise.
    HoldableObject GetHoldableObject () {
        float minDistance = float.MaxValue;
        HoldableObject currBestObj = null;

        foreach (HoldableObject obj in GameObject.FindObjectsOfType (typeof (HoldableObject))) {
            float distance = Vector2.Distance (FingerTip.transform.position, obj.transform.position);
            if (distance < obj.minDistanceToHold && distance < minDistance) {
                minDistance = distance;
                currBestObj = obj;
            }
        }
        return currBestObj;
    }

    IEnumerator DelayUnclench () {
        yield return new WaitForSeconds(0.25f);
        animator.SetBool ("isClenched", false);
    }
}