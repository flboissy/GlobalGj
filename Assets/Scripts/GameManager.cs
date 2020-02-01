using Assets.Scripts.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	private GameObject PlayerObj;
	public GameObject PlayerPrefab;
    public EnergyBar EnergyBar;
    public ScriptablePlayer player;
	public Transform SpawnPoint;
	
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
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnergyBar.LoseEnergy(10f);
        }
    }
}
