using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrochoc : MonoBehaviour
{
    public ScriptableAction associatedAction;
    private float startTime;
    private List<GameObject> triggers;
    public GameObject ElectrochocFX;
    private void Start()
    {
        startTime = Time.time;
        BoxCollider parentCollider = transform.parent.GetComponent<BoxCollider>();
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = parentCollider.size + new Vector3(2, 2, 0);
        GameObject electrochoc = Instantiate(ElectrochocFX, transform);
        electrochoc.transform.localScale= collider.size;
        electrochoc.transform.localPosition = Vector3.zero;
    }
	
    // Update is called once per frame
    void Update()
    {
	    if(Time.time > startTime + associatedAction.Duration)
	    {
		    Destroy(gameObject);
	    }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            triggers.Add(other.gameObject);
            other.GetComponent<Entity>().Stop();
        }
    }
    
    
    
    private void OnDestroy()
    {
        foreach (var go in triggers)
        {
            go.GetComponent<Entity>().Restart();
        }
    }
}
