using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefPurple : MonoBehaviour
{
    public bool PurpleHaveItem = false;
    public bool PurpleInPurple = false;
    private void OnTriggerStay(Collider Item)
    {
        if (Item.tag == "Interactive Objects")
        {
            PurpleHaveItem = true;
            if (Item.name == "Cubepurple")
            {
                PurpleInPurple = true;
            }
        }
    }
    public void Reset()
    {
        PurpleHaveItem = false;
        PurpleInPurple = false;
    }
}
