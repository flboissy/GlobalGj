﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    Move(Vector3.right);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
	    Destroy(gameObject);
    }
}
