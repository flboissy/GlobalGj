using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEntity : Entity
{

	// Update is called once per frame
    void Update()
    {
        if(!Target) return;
        MoveTo(Target.position);
    }
    
    private void OnTriggerEnter(Collider other)
    {
	    Debug.Log(other);
	    if (other.CompareTag("Enemy"))
	    {
		    Attack();
		    other.GetComponent<Entity>().TakeDammages();
		    Debug.Log(other);
	    }
	    Dead();
    }
	
    protected override void LookTo(Vector3 position)
    {
	    
    }
    
    public void EnablePhysics()
    {
	    GetComponent<BoxCollider>().enabled = true;
    }
    protected override void Attack()
    {
	    //explosion
    }
}
