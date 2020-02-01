using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyComponent : Enemy
{

	public float startRadius;
	private float curRadius = 0;
	
    // Start is called before the first frame update
    void Start()
    {
	    Init();
	    curRadius = startRadius;
    }

    // Update is called once per frame
    void Update()
    {
	    if (!Target)
	    {
		    FindTarget(curRadius);
		    return;
	    }
	    Move(Target.position);
    }

    private void FindTarget(float radius)
    {
	    Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
	    foreach (Collider collider in hitColliders) 
	    {
			if (collider.tag.Equals("Component"))
			{
				SetTarget(collider.transform);
				curRadius = startRadius;
			}
			else
			{
				curRadius++;
			}
		}
	    
    }
}
