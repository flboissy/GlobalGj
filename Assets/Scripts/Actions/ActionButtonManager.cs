using Assets.Scripts;
using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButtonManager : MonoBehaviour
{
    public ScriptableAction associatedAction;
    private Component associatedComponent;
    public Image cooldownImage;
    private bool isCooldown;
    private float startingCooldownTime;

      
    private void Update()
    {
        if (associatedComponent.getIsSelected() && Input.GetButtonDown(associatedAction.inputName) && !isCooldown)
        {
            startingCooldownTime = Time.time;
            cooldownImage.fillAmount = 0;
            isCooldown = true;
            ActionFabric.Instance.InstantiateAction(associatedAction.Type, associatedComponent.transform);
        }
        
        if(isCooldown)
        {
            cooldownImage.fillAmount = ((Time.time - startingCooldownTime) *  associatedAction.Cooldown) / 100f; 
        }

        if (Time.time > startingCooldownTime + associatedAction.Cooldown && isCooldown)
        {
            isCooldown = false;
        }

    }

    private void Start()
    {
        associatedComponent = GetComponentInParent<Component>();
    }
}
