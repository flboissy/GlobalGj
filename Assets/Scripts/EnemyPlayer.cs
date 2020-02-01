using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlayer : Enemy
{
	// Start is called before the first frame update
    void Start()
    {
	    Init();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SetTarget(player.transform);
    }

    // Update is called once per frame
    protected override void Update()
    {
	    base.Update();
	    if(!Target) return;
        MoveTo(Target.position);
    }

    private void OnCollisionEnter(Collision other)
    {
	    if (other.gameObject.CompareTag("Player"))
	    {
		    Attack();
		    other.gameObject.GetComponent<Entity>().TakeDammages(Dammages);
		    Debug.Log("player");
	    }
    }

    protected override void Attack()
    {
	    Dead();
    }
}
