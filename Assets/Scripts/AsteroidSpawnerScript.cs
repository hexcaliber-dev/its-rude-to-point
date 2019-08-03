using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    public float nextActionTime;
    public float period;

    //private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        StartCoroutine(SpawnAsteroid());
    }*/


    void Update () {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
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
