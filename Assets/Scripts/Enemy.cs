using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
	protected NavMeshAgent IaAgent;
	public EnemySpawn Spawner;
    public float attackCooldown;
	
	protected override void Init()
	{
        InitialSpeed = Speed;
        IaAgent = gameObject.GetComponent<NavMeshAgent>();
        EntityAnimator = gameObject.GetComponent<Animator>();
        base.Init();
	}

	protected virtual void Update()
	{
		if(IaAgent)SetFloatValue("Speed", GetCurrentSpeed(IaAgent.velocity));
	}

	protected override void MoveTo(Vector3 position)
	{
		IaAgent.SetDestination(position);
		LookTo(position);
	}

	protected override void Dead()
	{
		//if(Spawner)Spawner.EnemyKill(gameObject);
		base.Dead();
	}
}
