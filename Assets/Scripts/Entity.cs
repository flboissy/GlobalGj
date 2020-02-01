using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Entity : MonoBehaviour
{

	public float Speed;
	/**
     * Init entity Instance
     */
    protected virtual void Init()
    {
        
    }

    /**
     * Move entity to a specific target
     */
    protected virtual void Move(Transform target)
    {
	    
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
}
