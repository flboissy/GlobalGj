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
    public ActionableComponent associatedComponent;
    public Image cooldownImage;
    private bool isCooldown;
    private float startingCooldownTime;
    private float timeInCooldown;

      
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
            timeInCooldown = Time.time - startingCooldownTime;
            cooldownImage.fillAmount = (timeInCooldown *  associatedAction.Cooldown) / 100f;
            if (cooldownImage.fillAmount == 1){
                isCooldown = false;
            }
        }


    }
}
