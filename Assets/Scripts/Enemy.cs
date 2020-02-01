using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
	protected NavMeshAgent IaAgent;

	protected override void Init()
	{
		IaAgent = gameObject.GetComponent<NavMeshAgent>();
	}

	protected override void MoveTo(Vector3 position)
	{
		IaAgent.SetDestination(position);
	}
}
