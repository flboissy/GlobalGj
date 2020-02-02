using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFabric : MonoBehaviour
{

    public FireWall fireWall;
    public Drones drones;
    public Electrochoc electrochoc;

    private static ActionFabric _instance = null;
    public static ActionFabric Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }

    public void InstantiateAction(ActionType type, Transform target)
    {
        switch (type)
        {
            case ActionType.Electrochoc:
	            Instantiate(electrochoc, target);
	            GameManager.Instance.LoseEnergy(electrochoc.associatedAction.EnergyCost);
                break;
            case ActionType.Firewall:
	            Instantiate(fireWall, target);
                GameManager.Instance.LoseEnergy(fireWall.associatedAction.EnergyCost);
                break;
            case ActionType.Quarantine:
                Debug.Log("I will instantiate: " + type);
                break;
            case ActionType.Drone:
	            Instantiate(electrochoc, target);
	            GameManager.Instance.LoseEnergy(drones.associatedAction.EnergyCost);
                break;
            case ActionType.Push:
                Debug.Log("I will instantiate: " + type);
                break;
            default:
                break;
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
