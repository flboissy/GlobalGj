using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlayer : Entity
{
	private Transform Target;

	private NavMeshAgent IaAgent;
    // Start is called before the first frame update
    void Start()
    {
	    IaAgent = gameObject.GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SetTarget(player.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Target) return;
        Move(Target.position);
    }

    public void SetTarget(Transform target)
    {
	    Target = target;
    }

    protected override void Move(Vector3 targetPos)
    {
	    IaAgent.SetDestination(targetPos);
    }
}
