using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPooling : MonoBehaviour {

    public GameObject BallPrefab;
    public int candyPoolSize = 9;
    public float spawnRate = 3f;
    public float sideForce = 3f;

    private GameObject[] Candies;
    private int currentCandie = 0;

    private Vector2 objectPoolPosition = new Vector2(0, 8);

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        //Initialize the columns collection.
        Candies = new GameObject[candyPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < candyPoolSize; i++)
        {
            //...and create the individual columns.
            Candies[i] = (GameObject)Instantiate(BallPrefab, objectPoolPosition, Quaternion.identity);
        }
    }


    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameManager.Instance.GameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float xForce = Random.Range(-sideForce, sideForce);
            float yForce = 1f;            



            //...then set the current column to that position.
            Candies[currentCandie].transform.position = new Vector3(xForce, yForce, -7f);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentCandie++;

            if (currentCandie >= candyPoolSize)
            {
                currentCandie = 0;
            }
        }
    }

    public void OnObjectSpawn()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = 1f;

        Vector2 force = new Vector2(xForce, yForce);

        GetComponent<Rigidbody2D>().velocity = force;

    }
}
