using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
    public ActionButtonManager prefab;
    public List<Action> actions;
    public Transform target;

    public void InstantiateActions()
    {
        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].Available)
            {
                ActionButtonManager instance = Instantiate(prefab, this.transform);
                instance.GetComponent<Image>().sprite = actions[i].sprite;
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InstantiateActions( );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
