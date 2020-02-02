using Assets.Scripts.Classes;
using System;
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

	private List<GameObject> Components;
	private List<EnemySpawn> EnemySpawnPoints;
	
	// Start is called before the first frame update
    private void Awake()
    {
	    Instance = this;
    }

    void Start()
    {
	    if (!SpawnPoint)
	    {
		    Debug.Log("No spawn point for player");
		    return;
	    }
	    
	    FindEnemySpawnPoints();
	    FindComponents();
	    InstantiatePlayer(SpawnPoint.position);
	    StartCoroutine("WaitBeforeSpawnEnemy");
    }

    private void FindEnemySpawnPoints()
    {
	    EnemySpawnPoints = FindObjectsOfType<EnemySpawn>().ToList();
    }

    private void FindComponents()
    {
	    Components = GameObject.FindGameObjectsWithTag("Component").ToList();
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

    public void LoseComponent(GameObject component)
    {
	    Components.Remove(component);
	    if (Components.Count < 1)
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

    IEnumerator WaitBeforeSpawnEnemy()
    {
	    yield return new WaitForSeconds(3.0f);
	    InstantiateEnemies();
    }
}
