using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	private GameObject PlayerObj;
	public GameObject PlayerPrefab;
    public EnergyBar EnergyBar;
    public ScriptablePlayer player;
	public Transform SpawnPoint;

    private int currentSelected = -1;

    private List<Component> ComponentsInScene = new List<Component>();
    private List<Component> SelectableComponent = new List<Component>();
    public List<Action> actions;
	
	// Start is called before the first frame update
    private void Awake()
    {
	    Instance = this;
    }

    void Start()
    {

        ComponentsInScene = GameObject.FindGameObjectsWithTag("Component").Select((go) => go.GetComponent<Component>()).ToList();
        if (!SpawnPoint)
	    {
		    Debug.Log("No spawn point for player");
		    return;
	    }

	    RetrieveEnemySpawnPoints();
	    InstantiatePlayer(SpawnPoint.position);

    }

    private void RetrieveEnemySpawnPoints()
    {
	    //GameObject[] spawnPoints;
    }
    
    private void InstantiatePlayer(Vector3 position)
    {
	    PlayerObj = Instantiate(PlayerPrefab, position, Quaternion.identity);
    }

    public GameObject GetPlayer()
    {
	    return PlayerObj;
    }
    
    public void LoseEnergy(float amount)
    {
        EnergyBar.LoseEnergy(amount);
    }
    // Update is called once per frame
    void Update()
    {
        if(SelectableComponent.Count > 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentSelected == -1)
                {
                    currentSelected = 0;
                    SelectableComponent[currentSelected].setIsSelected(true);
                }
                else
                {
                    if (currentSelected == SelectableComponent.Count - 1)
                    {
                        SelectableComponent[currentSelected].setIsSelected(false);
                        currentSelected = 0;
                        SelectableComponent[currentSelected].setIsSelected(true);
                    }
                    else
                    {
                        SelectableComponent[currentSelected].setIsSelected(false);
                        currentSelected++;
                        SelectableComponent[currentSelected].setIsSelected(true);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(currentSelected == -1)
                {
                    currentSelected = SelectableComponent.Count - 1;
                    SelectableComponent[currentSelected].setIsSelected(true);
                }
                else
                {
                    if(currentSelected == 0)
                    {
                        SelectableComponent[currentSelected].setIsSelected(false);
                        currentSelected = SelectableComponent.Count - 1;
                        SelectableComponent[currentSelected].setIsSelected(true);
                    }
                    else
                    {
                        SelectableComponent[currentSelected].setIsSelected(false);
                        currentSelected--;
                        SelectableComponent[currentSelected].setIsSelected(true);
                    }
                }
            }
        }
        else
        {
            if(SelectableComponent.Count == 1)
            {
                currentSelected = 0;
                SelectableComponent[currentSelected].setIsSelected(true);
            }
        }
       

    }


    public void UpdateSelectableComponenent()
    {
        currentSelected = -1;
        foreach (var comp in SelectableComponent)
        {
            comp.setIsSelected(false);
        }
        SelectableComponent = ComponentsInScene.Where((comp) => comp.getIsVisible()).ToList();
        SelectableComponent = SelectableComponent.OrderByDescending(comp => comp.transform.position.y).ToList() ;
    }
}
