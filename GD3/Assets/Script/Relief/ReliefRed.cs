using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefRed : MonoBehaviour
{
    public bool RedHaveItem = false;
    public bool RedInRed = false;
    private void OnTriggerStay(Collider Item)
    {
        if (Item.tag == "Interactive Objects")
        {
            RedHaveItem = true;
            if(Item.name == "Cubered")
            {
                RedInRed = true;
            }
        }
    }
    public void Reset()
    {
     RedHaveItem = false;
     RedInRed = false;
    }
}
