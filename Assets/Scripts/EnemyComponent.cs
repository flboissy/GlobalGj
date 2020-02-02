using System;
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
    protected override void Update()
    {
	    base.Update();
	    if (!Target)
	    {
		    FindTarget(curRadius);
		    return;
	    }
	    MoveTo(Target.position);
    }

    private void FindTarget(float radius)
    {
	    Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
	    foreach (Collider collider in hitColliders) 
	    {
			if (collider.CompareTag("Component"))
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

    private void OnCollisionEnter(Collision other)
    {
	    if (other.gameObject.CompareTag("Component"))
	    {
            if (canAttack)
            {
                other.gameObject.GetComponent<ActionableComponent>().TakeDamages(Dammages);
                Attack();
                StartCoroutine(CooldownAttackCoroutine());
            }
	    }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Component"))
        {
            if (canAttack)
            {
                collision.gameObject.GetComponent<ActionableComponent>().TakeDamages(Dammages);
                Attack();
                StartCoroutine(CooldownAttackCoroutine());
            }
        }
    }

    IEnumerator CooldownAttackCoroutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    protected override void Attack()
    {
	    base.Attack();
    }
}
