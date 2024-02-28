using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Drowned in water");
        collider.transform.position = new Vector3(4f, 0.57f, 0f);
    }
}
