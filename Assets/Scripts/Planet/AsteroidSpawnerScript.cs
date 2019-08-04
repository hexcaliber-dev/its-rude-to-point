using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    public float nextActionTime;

    // Period does not reset on next round!
    public static float period = 0.5f;

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
        period += periodAdder;
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

            if(period > 0.02)
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
