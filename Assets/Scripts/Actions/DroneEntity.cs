﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEntity : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Target) return;
        MoveTo(Target.position);
    }
}