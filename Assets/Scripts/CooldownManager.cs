using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CooldownManager : MonoBehaviour
{

    private Clickable clickableElement;

    // Start is called before the first frame update
    void Start()
    {
        clickableElement = GetComponent<Clickable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
