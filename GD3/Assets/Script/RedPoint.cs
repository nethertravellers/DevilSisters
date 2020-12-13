using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPoint : MonoBehaviour
{
    public bool RedHaveItem = false;
    public Transform redkeyset;
    private GameObject key;
  
    private void Update()
    {
        key.transform.position = redkeyset.position;
        key.GetComponent<Rigidbody>().Sleep();
        
    }
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.tag == "Player")
        {
            
            Player.gameObject.GetComponent<playerObjInteraction>().canputing = true;
            
        }
    }
    private void OnTriggerExit(Collider Player)
    {
        if (Player.tag == "Player")
        {
            
            Player.gameObject.GetComponent<playerObjInteraction>().canputing = false;
        }
    }
    private void OnCollisionStay(Collision Item)
     {
        if (Item.gameObject.name == "RedKey")
        {
              key = Item.gameObject;
            RedHaveItem = true;

      }
     }
    // private void OnCollisionStay(Collision Item)
    // {
    //    if (Item.gameObject.name == "RedballKey")
    //    {
    //       RedHaveItem = true;

    //   }
    // }
}
