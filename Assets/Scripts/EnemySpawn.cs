using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject[] EnemyPrefabs;
    public Transform[] SpawnPoints;
    public GameObject Fx_Spawn;
    
	private GameManager GameMngr;

	private List<GameObject> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        GameMngr = GameManager.Instance;
        GameObject obj = Instantiate(Fx_Spawn, transform);
        obj.transform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        
    }

    public void SpawnEnemies()
    {
	    for (int i = 0; i < SpawnPoints.Length; i++)
	    {
		    int index = Random.Range(0, EnemyPrefabs.Length);
		    Instantiate(EnemyPrefabs[index], SpawnPoints[i].position, Quaternion.identity);
	    }

    }

    public void NoLongerInUser()
    {
	    Destroy(transform.GetChild(0));
    }

    //public void EnemyKill(GameObject enemy)
    //{
	   // Enemies.Remove(enemy);
	   // if (Enemies.Count < 1)
	   // {
		  //  GameMngr.LoseEnemySpawnPoint(this);
		  //  Destroy(gameObject);
	   // }
    //}
}
