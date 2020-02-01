using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
	protected NavMeshAgent IaAgent;

	protected override void Init()
	{
        InitialSpeed = Speed;
        IaAgent = gameObject.GetComponent<NavMeshAgent>();
	}

	protected override void Move(Vector3 targetPos)
	{
		IaAgent.SetDestination(targetPos);
	}
}
