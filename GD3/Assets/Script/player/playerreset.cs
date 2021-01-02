using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerreset : MonoBehaviour
{
    public Transform respawnpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            respawnpoint.transform.position = gameObject.transform.position;
        }
              
    }

    public void Playerreset()
    {
        gameObject.transform.position =  respawnpoint.transform.position;
    }
}

