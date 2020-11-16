using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueballPoint : MonoBehaviour
{
    public bool BlueHaveItem = false;

    private void OnTriggerEnter(Collider Item)
    {
        if (Item.name == "BlueballKey")
        {
            BlueHaveItem = true;

        }
    }
   // private void OnCollisionStay(Collision Item)
  //  {
   //     if (Item.gameObject.name == "BlueballKey")
    //    {
     //       BlueHaveItem = true;
//
  //      }
    //}
}
