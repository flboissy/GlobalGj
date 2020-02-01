﻿using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Image energy;
    public ScriptablePlayer player;

    public void LoseEnergy(float amount)
    {
        energy.fillAmount -= amount / player.totalEnergy;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
