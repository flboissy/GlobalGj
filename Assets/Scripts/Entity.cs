using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Entity : MonoBehaviour
{

	public float Speed;
	public float RotateSpeed;
	
	protected Transform Target;
	
	/**
     * Init entity Instance
     */
    protected virtual void Init()
    {
        
    }

    /**
     * Move entity to a specific target
     */
    protected virtual void MoveTo(Vector3 position)
    {
	    float step = Speed * Time.deltaTime;
	    transform.position = Vector3.MoveTowards(transform.position, position, step);
    }
    
    /**
     * Move entity along a vector
     */
    protected virtual void Move(Vector3 moveDirection)
    {
	    moveDirection *= Speed;
	    transform.Translate(moveDirection*Time.deltaTime);
    }

    protected void Rotate(Vector3 rotDirection)
    {
	    float angle = Mathf.Atan2(rotDirection.x, rotDirection.y) * Mathf.Rad2Deg;
	    transform.rotation = Quaternion.AngleAxis(angle,Vector3.up);
    }

    protected virtual void Attack()
    {
	    
    }
    
    public void SetTarget(Transform target)
    {
	    Target = target;
    }
}
