using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter(Collision collision)
    //{
//if(collision.gameObject.tag == "Interactive Objects")
 //       {
  //          collision.gameObject.GetComponent<PickItem>().respawned();
  //      }
   // }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Interactive Objects")
        {
            collider.gameObject.GetComponent<PickItem>().Respawned();
        }
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<playerreset>().Playerreset();
        }
    }
}
