using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public float timeBetweenWaves;
    private float countdown;
    private int numberOfEnemyKilled;
    private int waveIndex;

    private static WaveManager _instance = null;
    public static WaveManager Instance
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

    void Start()
    {
    }

    IEnumerator SpawnWave()
    {
       
        Wave wave = waves[waveIndex];
        wave.CurrentNumberOfEnemy = wave.InitialNumberOfEnemy;
        
        while(wave.CurrentNumberOfEnemy > 0)
        {
            foreach (var spwn in wave.EnemySpawns)
            {
                spwn.SpawnEnemies();
                wave.CurrentNumberOfEnemy -= spwn.SpawnPoints.Length;
            }
            yield return new WaitForSeconds(wave.TimeBetweenSpawn);
        }
		
        waveIndex++;
        if (waveIndex >= waves.Length)
        {
	        foreach (var spwn in wave.EnemySpawns)
	        {
		        spwn.NoLongerInUser();
	        }
	        GameManager.Instance.EndGame("Win");
        }
    }
    

    void Update()
    {
	    if (waveIndex >= waves.Length)
	    {
		    return;
	    }
	    
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

}
