using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedballPoint : MonoBehaviour
{
    public bool RedHaveItem = false;

    private void OnTriggerEnter(Collider Item)
    {
        if (Item.name == "RedballKey")
        {
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
