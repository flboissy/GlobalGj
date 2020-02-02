using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Drones : MonoBehaviour
{
	private List<Transform> DronesObj;

	public ScriptableAction associatedAction;
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
		    DroneEntity droneEntity = drone.GetComponent<DroneEntity>();
		    droneEntity.SetTarget(target);
		    droneEntity.EnablePhysics();
		    DronesObj.RemoveAt(0);
		    if (DronesObj.Count < 1)
		    {
			    Destroy(gameObject);
			    gameObject.SetActive(false);
		    }
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
    }

}
