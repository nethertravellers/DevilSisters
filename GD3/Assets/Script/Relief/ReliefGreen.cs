using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefGreen : MonoBehaviour
{
    public bool GreenHaveItem = false;
    public bool GreenInGreen = false;
    private void OnTriggerStay(Collider Item)
    {
        if (Item.tag == "Interactive Objects")
        {
            GreenHaveItem = true;
            if (Item.name == "Cubegreen")
            {
                GreenInGreen = true;
            }
        }
    }
    public void Reset()
    {
        GreenHaveItem = false;
        GreenInGreen = false;
    }
}
