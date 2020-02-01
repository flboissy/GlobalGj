using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Action action;
    public Clickable target;
    private float lastClick;
    private bool isInCooldown;
    private bool canClick = true;
    private Shadow shadowComponent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!action.inCooldown)
        {
            ActionFabric.Instance.InstantiateAction(action.Type, target.transform);
            target.StartCooldownCoroutine(action);
            MenuClickManager.Instance.closeMenu();
        }
    }

    private void Update()
    {
        if(action != null && action.inCooldown)
        {
            //TODO Gerer l'affichage du CD
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
