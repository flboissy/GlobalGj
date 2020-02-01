using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Action action;
    public Transform target;
    private float lastClick;
    private bool isInCooldown;
    private bool canClick;
    private Shadow shadowComponent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canClick)
        {
            ActionFabric.Instance.InstantiateAction(action.Type, target);
            lastClick = Time.time;
        }
    }

    private void Update()
    {
        if (Time.time > lastClick + action.Cooldown)
        {
            isInCooldown = false;
            canClick = true;
        }
        else
        {
            isInCooldown = true;
            canClick = false;
        }

        if (isInCooldown)
        {
            
        }
    }

    private void Start()
    {
        shadowComponent = this.GetComponentInChildren<Shadow>();
        shadowComponent.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        shadowComponent.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shadowComponent.enabled = false;
    }
}
