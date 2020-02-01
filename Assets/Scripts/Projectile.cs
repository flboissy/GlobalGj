using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{

	// Update is called once per frame
    void Update()
    {
	    Move(Vector3.forward);
    }

    private void OnCollisionEnter(Collision other)
    {
	    if (other.gameObject.CompareTag("Enemy"))
	    {
		    other.gameObject.GetComponent<Entity>().TakeDammages();
	    }
	    Dead();
    }
}
