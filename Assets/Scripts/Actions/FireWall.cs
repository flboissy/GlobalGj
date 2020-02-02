using Assets.Scripts;
using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public ScriptableAction associatedAction;
    private float startTime;

    public GameObject FirewallFX;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        BoxCollider parentCollider = transform.parent.GetComponent<BoxCollider>();
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = parentCollider.size + new Vector3(1, 1, 0);
        AudioManager.instance.Play("firewall");
        GameObject firewall = Instantiate(FirewallFX, transform);
        firewall.transform.localScale= collider.size;
        firewall.transform.localPosition = Vector3.zero;
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
		    other.GetComponent<Entity>().TakeDammages();
	    }
    }
    
}
