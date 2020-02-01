using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrochoc : MonoBehaviour
{
    public ScriptableAction associatedAction;
    private float startTime;
    private List<GameObject> triggers;

    private void Start()
    {
        startTime = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            triggers.Add(other.gameObject);
            other.GetComponent<Entity>().Stop();
        }
    }
    
    private void OnDestroy()
    {
        foreach (var go in triggers)
        {
            go.GetComponent<Entity>().Restart();
        }
    }
}
