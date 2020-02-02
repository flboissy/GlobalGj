using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Drones : MonoBehaviour
{
	private List<Transform> DronesObj;
	public GameObject Drone;
	public ScriptableAction associatedAction;
    // Start is called before the first frame update
    void Start()
    {
	    DronesObj = new List<Transform>();
	    BoxCollider parentCollider = transform.parent.GetComponent<BoxCollider>();
	    BoxCollider collider = GetComponent<BoxCollider>();
	    collider.size = parentCollider.size + new Vector3(1, 1, 0);
	    Bounds bounds = collider.bounds;
	    InstantiateDrone(new Vector3(bounds.min.x,bounds.center.y,bounds.min.z));
	    InstantiateDrone(new Vector3(bounds.max.x,bounds.center.y,bounds.min.z));
	    InstantiateDrone(new Vector3(bounds.min.x,bounds.center.y,bounds.max.z));
	    InstantiateDrone(new Vector3(bounds.max.x,bounds.center.y,bounds.max.z));
    }

    private void InstantiateDrone(Vector3 pos)
    {
	    GameObject drone = Instantiate(Drone, transform);
	    drone.transform.position = pos;
	    DronesObj.Add(drone.transform);
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
