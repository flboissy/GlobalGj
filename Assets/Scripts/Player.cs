using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	private CharacterController CharCtrl;
	public GameObject BulletPrefab;
	public float AttackCooldown = 0.5f;
	
	private Vector3 rotDirection;
	private Vector3 moveDirection;
	private bool canAttack = true;
	
    // Start is called before the first frame update
    void Start()
    {
	    CharCtrl = gameObject.GetComponent<CharacterController>();
	    EntityAnimator = gameObject.GetComponent<Animator>();
	    Init();
    }

    // Update is called once per frames
    void Update()
    {
	    if(CharCtrl)SetFloatValue("Speed", GetCurrentSpeed(CharCtrl.velocity));
	    if (CharCtrl.isGrounded)
	    {
		    moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		    rotDirection = new Vector3(Input.GetAxis("Rot_H"),Input.GetAxis("Rot_V"),0);
	    }
	    moveDirection.y -= 9.0f * Time.deltaTime;
	    
	    if (Input.GetAxis("Fire")>0 && canAttack)
	    {
		    canAttack = false;
		    LaunchAttack();
		    StartCoroutine("WaitBetweenAttack");
	    }
	    
	    Move(moveDirection);
	    
    }

    private void FixedUpdate()
    {
	    if (rotDirection.x != 0 || rotDirection.y != 0)
	    {
		    Rotate(rotDirection);
	    }
    }

    protected override void Move(Vector3 moveDirection)
    {
	    moveDirection *= Speed;
	    CharCtrl.Move( moveDirection * Time.deltaTime);
    }

    protected override void Attack()
    {
	    Instantiate(BulletPrefab, transform.position + transform.forward + new Vector3(0,0.5f,0), transform.localRotation);
    }

    IEnumerator WaitBetweenAttack()
    {
	    yield return new WaitForSeconds(AttackCooldown);
	    canAttack = true;
    }
}
