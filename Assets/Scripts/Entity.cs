using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

public class Entity : MonoBehaviour
{

	public float Speed;
    protected float InitialSpeed;
	public float RotateSpeed;
	public float MaxLife;
	public float Dammages;
	
	private float Life;
	protected Transform Target;
	protected Animator EntityAnimator;
	
	/**
     * Init entity Instance
     */
    protected virtual void Init()
	{
		Life = MaxLife;
	}

    /**
     * Move entity to a specific target
     */
    protected virtual void MoveTo(Vector3 position)
    {
	    float step = Speed * Time.deltaTime;
	    transform.position = Vector3.MoveTowards(transform.position, position, step);
	    LookTo(position);
    }
    
    /**
     * Move entity along a vector
     */
    protected virtual void Move(Vector3 moveDirection)
    {
	    moveDirection *= Speed;
	    transform.Translate(moveDirection*Time.deltaTime);
    }
	
    /**
     * Rotate enity along an angle
     */
    protected void Rotate(Vector3 rotDirection)
    {
	    float angle = Mathf.Atan2(rotDirection.x, rotDirection.y) * Mathf.Rad2Deg;
	    transform.rotation = Quaternion.AngleAxis(angle,Vector3.up);
    }
    
    /**
     * Entity look to a target
     */
    protected virtual void LookTo(Vector3 position)
    {
	    transform.LookAt(position,Vector3.up);
    }
    /**
     * Entity Launch Attack
     */
    protected virtual void LaunchAttack()
    {
	    SetTriggerAnim("Attack");
    }
    
    /**
     * Entity Attack
     */
    protected virtual void Attack()
    {
	    SetTriggerAnim("Attack");
    }
	
    /**
     * Get current speed of entity with its velocity
     */
    protected float GetCurrentSpeed(Vector3 velocity)
    {
	    return velocity.magnitude;
    }

    public void TakeDammages()
    {
	    Dead();
    }

    public void TakeDammages(float dammages)
    {
	    AudioManager.instance.Play("player_taking_dmg");
	    Life -= dammages;
	    if (Life<=0 ) Dead();
    }

    protected virtual void Dead()
    {
	    gameObject.SetActive(false);
	    Destroy(gameObject);
    }
    
    /**
     * Set entity target
     */
    public void SetTarget(Transform target)
    {
	    Target = target;
    }

    public void Stop()
    {
        this.Speed = 0;
    }

    public void Restart()
    {
        this.Speed = InitialSpeed;
    }

    protected void SetBoolAnim(string name, bool value)
    {
	    if(EntityAnimator) EntityAnimator.SetBool(name,value);
    }
    
    protected void SetTriggerAnim(string name)
    {
	    if(EntityAnimator) EntityAnimator.SetTrigger(name);
    }

    protected void SetFloatValue(string name, float value)
    {
	    if(EntityAnimator) EntityAnimator.SetFloat(name, value);
    }
    
    protected void SetInt(string name, int value)
    {
	    if(EntityAnimator) EntityAnimator.SetInteger(name, value);
    }

}
