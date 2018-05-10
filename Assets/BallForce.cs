using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour , IPoolObject
{

    public float sideForce = 2f;
	public void OnObjectSpawn()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = 1f;

        Vector2 force = new Vector2(xForce, yForce);

        GetComponent<Rigidbody2D>().velocity = force;

	}	
	
}
