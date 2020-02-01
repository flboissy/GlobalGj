using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{

    public List<Transform> Anchors;
    public ActionButton prefab;

    public void InstantiateActionsAndTarget(List<Action> actionList, Transform target)
    {
        for (int i = 0; i < actionList.Count; i++)
        {
            if (actionList[i].Available)
            {
                ActionButton instance = Instantiate(prefab, Anchors[i]);
                instance.GetComponentInChildren<Image>().sprite = actionList[i].sprite;
                instance.target = target;
                instance.action = actionList[i];
            }
        }
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
