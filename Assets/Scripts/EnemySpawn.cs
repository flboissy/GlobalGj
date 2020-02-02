using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject[] EnemyPrefabs;

	private GameManager GameMngr;

	private List<GameObject> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        GameMngr = GameManager.Instance;
    }

    public void SpawnEnemies()
    {
	    for (int i = 0; i < 60; i++)
	    {
		    int index = Random.Range(0, EnemyPrefabs.Length);
		    Instantiate(EnemyPrefabs[index], transform.position, Quaternion.identity);
	    }
	    
    }

    public void EnemyKill(GameObject enemy)
    {
	    Enemies.Remove(enemy);
	    if (Enemies.Count < 1)
	    {
		    GameMngr.LoseEnemySpawnPoint(this);
		    Destroy(gameObject);
	    }
    }
}
