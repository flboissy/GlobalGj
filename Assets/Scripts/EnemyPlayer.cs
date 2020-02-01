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
    void Update()
    {
        if(!Target) return;
        MoveTo(Target.position);
    }
}
