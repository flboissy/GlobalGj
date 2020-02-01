using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drones : MonoBehaviour
{
	private List<Transform> DronesObj;
	
    // Start is called before the first frame update
    void Start()
    {
	    DronesObj = transform.Cast<Transform>().ToList();
    }

    // Update is called once per frame
    private void LaunchDrone(Transform target)
    {
	    if (DronesObj.Count > 0)
	    {
		    Transform drone = DronesObj[0];
		    drone.GetComponent<DroneEntity>().SetTarget(target);
		    DronesObj.RemoveAt(0);
	    }
	    
    }

    private void IsUnderAttack(Collider other)
    {
	    if (other.CompareTag("Enemy") )
	    {
		    LaunchDrone(other.transform);
	    }
    }

    private void OnTriggerEnter(Collider other)
    {
	    IsUnderAttack(other);
	    Debug.Log(other);
    }

}
