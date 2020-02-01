using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public List<Action> Actions;

    private void OnMouseDown()
    {
        MenuClickManager.Instance.GameObjectClicked(this, Actions);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartCooldownCoroutine(Action action)
    {
        foreach (var act in Actions)
        {
            if(act.Type == action.Type)
            {
                StartCoroutine(CoolDownCoroutine(act));
            }
        }
    }

    IEnumerator CoolDownCoroutine(Action action)
    {
        action.inCooldown = true;
        yield return new WaitForSeconds(action.Cooldown);
        action.inCooldown = false;
    }
}
