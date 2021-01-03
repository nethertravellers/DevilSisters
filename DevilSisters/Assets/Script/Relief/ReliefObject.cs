using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefObject : MonoBehaviour
{
    private GameObject player;
    private Transform spawnedpoint;
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        spawnedpoint = gameObject.transform;
        player = GameObject.FindWithTag("Player");
        
    }
    void Start()
    {
        
    }
    public void respawned()
    {
        gameObject.GetComponent<Rigidbody>().Sleep();
        gameObject.transform.position = spawnedpoint.position;
        gameObject.transform.rotation = spawnedpoint.rotation;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<PickItem>().taken == false )
        {
            //&& gameObject.GetComponent<Rigidbody>().
        }
    }
}
