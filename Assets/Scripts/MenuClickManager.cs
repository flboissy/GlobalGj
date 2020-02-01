using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickManager : MonoBehaviour
{
    //public GameObject instantiateMenu;
    //public GameObject menuPrefab;
    //private static MenuClickManager _instance = null;
    //public static MenuClickManager Instance
    //{
    //    get { return _instance; }
    //}

    //private void Awake()
    //{
    //    if (_instance != null && _instance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //    else
    //    {
    //        _instance = this;
    //    }
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse1))
    //    {
    //        closeMenu();
    //    }
    //}

    //public void GameObjectClicked(Clickable clickableTransform, List<Action> actions)
    //{
    //    if(this.instantiateMenu == null)
    //    {
    //        this.instantiateMenu = Instantiate(this.menuPrefab, this.transform, false);
    //        this.instantiateMenu.transform.position = Input.mousePosition;
    //        ActionMenu actionMenu = this.instantiateMenu.GetComponent<ActionMenu>();
    //        actionMenu.InstantiateActionsAndTarget(actions);


    //    }
    //    else
    //    {
    //        Destroy(this.instantiateMenu);
    //        this.instantiateMenu = Instantiate(this.menuPrefab, this.transform, false);
    //        this.instantiateMenu.transform.position = Input.mousePosition;
    //        this.instantiateMenu.GetComponent<ActionMenu>().InstantiateActionsAndTarget(actions, clickableTransform);
    //    }
    //    //this.instantiateMenu.transform.
    //}

    //public void closeMenu()
    //{
    //    if (this.instantiateMenu != null)
    //    {
    //        Destroy(this.instantiateMenu);
    //    }
    //}
}
