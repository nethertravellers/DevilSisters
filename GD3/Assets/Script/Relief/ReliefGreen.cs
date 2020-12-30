using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefGreen : MonoBehaviour
{
    private GameObject greenobj;
    public bool GreenHaveItem = false;
    public bool GreenInGreen = false;
    private void Update()
    {
        greenobj.transform.position = gameObject.transform.position;
        greenobj.transform.rotation = gameObject.transform.rotation;
        greenobj.GetComponent<Rigidbody>().Sleep();
        if(greenobj != null)
        {
            GreenHaveItem = true;
        }
        
    }
    private void OnTriggerStay(Collider Item)
    {
        if (Item.tag == "Interactive Objects")
        {
            if (greenobj == null)
            {
                greenobj = Item.gameObject;
                
            }
            
            
            if (Item.name == "greenobj")
            {
                GreenInGreen = true;
            }
        }
    }
    public void Reset()
    {
        greenobj = null;
        GreenHaveItem = false;
        GreenInGreen = false;
    }
}
