using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public List<Action> Actions;

    private void OnMouseDown()
    {
        MenuClickManager.Instance.GameObjectClicked(transform, Actions);
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
