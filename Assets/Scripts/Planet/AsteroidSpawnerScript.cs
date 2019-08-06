using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    public float nextActionTime;

    public float period = 1f;

    float minPeriod = 0.3f;

    /// How much to subtract from the period every asteroid spawn
    public float periodSubtracter = 0.01f;

    /// How much to add to the period on new round
    public float periodAdder = 0.2f;

    float timeElapsed;

    //private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;

        if(MinigameTracker.numPlayed > 3) {
            period = 0.8f;
            minPeriod = 0.2f;
        }
        else if(MinigameTracker.numPlayed > 5) {
            period = 0.7f;
            minPeriod = 0.1f;
        }
        else if(MinigameTracker.numPlayed > 8) {
            period = 0.5f;
            minPeriod = 0.1f;
        }
        else if(MinigameTracker.numPlayed > 11) {
            period = 0.3f;
            minPeriod = 0.1f;
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        StartCoroutine(SpawnAsteroid());
    }*/


    void Update () {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > nextActionTime ) {
            nextActionTime += period;

            if(period > minPeriod)
                period -= periodSubtracter;

            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 7.5f, 0);
            GameObject Asteroid = Instantiate(prefab, position, Quaternion.identity);
            //var rb2d = Asteroid.GetComponent<Rigidbody2D> ();
            Asteroid.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0.0f, -180.0f));
            //rb2d.AddForce(1, 1, ForceMode2D.Impulse);
        }
    }

    /*IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds(3);
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 7.5f, 0);
        GameObject Asteroid = Instantiate(prefab, position, Quaternion.identity);
        var rot = Asteroid.transform.rotation;
    }*/
}
