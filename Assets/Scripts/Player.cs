using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	private CharacterController CharCtrl;
    // Start is called before the first frame update
    void Start()
    {
	    CharCtrl = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frames
    void Update()
    {
	    Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
	    Vector3 rotDirection = new Vector3(Input.GetAxis("Rot_H"),Input.GetAxis("Rot_V"),0);
	    
	    Move(moveDirection);
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
}
