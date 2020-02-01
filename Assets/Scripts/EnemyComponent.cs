using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyComponent : Entity
{
	
	private Transform Target;
	private NavMeshAgent IaAgent;

	public float startRadius;
	private float curRadius = 0;
    // Start is called before the first frame update
    void Start()
    {
	    IaAgent = gameObject.GetComponent<NavMeshAgent>();
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
	    if (hitColliders.Length > 0)
	    {
		    Target = hitColliders[0].transform;
		    curRadius = startRadius;
	    }
	    else
	    {
		    curRadius++;
	    }
    }
    
    protected override void Move(Vector3 targetPos)
    {
	    IaAgent.SetDestination(targetPos);
    }
}
