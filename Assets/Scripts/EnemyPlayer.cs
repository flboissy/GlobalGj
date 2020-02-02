using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPlayer : Enemy
{
	public GameObject ExplosionPrefab;
	
	// Start is called before the first frame update
    void Start()
    {
	    Init();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            SetTarget(player.transform);
        }
        else
        {
            Destroy(this.gameObject);
        }
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
		    LaunchAttack();
		    other.gameObject.GetComponent<Entity>().TakeDammages(Dammages);
	    }
    }

    protected override void Attack()
    {
	    AudioManager.instance.Play("enemy_explosion");
	    Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
	    Dead();
    }
}
