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

    private List<ActionableComponent> ComponentsInScene = new List<ActionableComponent>();
    private List<ActionableComponent> SelectableComponent = new List<ActionableComponent>();
    public List<Action> actions;
	private List<EnemySpawn> EnemySpawnPoints;
	
	// Start is called before the first frame update
    private void Awake()
    {
	    Instance = this;
    }

    void Start()
    {
        Debug.Log("START - GAME MANAGER");
       
        if (!SpawnPoint)
	    {
		    Debug.Log("No spawn point for player");
		    return;
	    }
	    InstantiatePlayer(SpawnPoint.position);
	    FindEnemySpawnPoints();
	    FindComponents();
	    StartCoroutine("WaitBeforeSpawnEnemy");
    }

    private void FindEnemySpawnPoints()
    {
	    EnemySpawnPoints = FindObjectsOfType<EnemySpawn>().ToList();
    }

    private void FindComponents()
    {
        ComponentsInScene = GameObject.FindGameObjectsWithTag("Component").Select((go) => go.GetComponent<ActionableComponent>()).ToList();
        SelectableComponent = ComponentsInScene.Where((comp) => comp.getIsVisible()).ToList();

    }
    
    private void InstantiatePlayer(Vector3 position)
    {
	    PlayerObj = Instantiate(PlayerPrefab, position, Quaternion.identity);
    }
    
    private void InstantiateEnemies()
    {
	    foreach (EnemySpawn spawn in EnemySpawnPoints)
	    {
		    spawn.SpawnEnemies();
	    }
    }

    public void LoseEnergy(float amount)
    {
        EnergyBar.LoseEnergy(amount);
    }

    public void LoseComponent(ActionableComponent component)
    {
        ComponentsInScene.Remove(component);
	    if (ComponentsInScene.Count < 1)
	    {
		    Debug.Log("Game Over");
	    }
    }

    public void LoseEnemySpawnPoint(EnemySpawn spawnPoint)
    {
	    EnemySpawnPoints.Remove(spawnPoint);
	    if (EnemySpawnPoints.Count < 1)
	    {
		    Debug.Log("Win");
	    }
    }

    public void Update()
    {
        if (SelectableComponent.Count > 1)
        {
            if (Input.GetButtonDown("NextComp"))
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

            if (Input.GetButtonDown("PreviousComp"))
            {
                if (currentSelected == -1)
                {
                    currentSelected = SelectableComponent.Count - 1;
                    SelectableComponent[currentSelected].setIsSelected(true);
                }
                else
                {
                    if (currentSelected == 0)
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
            if (SelectableComponent.Count == 1)
            {
                currentSelected = 0;
                SelectableComponent[currentSelected].setIsSelected(true);
            }
        }

    }

    IEnumerator WaitBeforeSpawnEnemy()
    {
        yield return new WaitForSeconds(3.0f);
        InstantiateEnemies();
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
