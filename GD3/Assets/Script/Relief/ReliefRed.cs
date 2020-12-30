using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefRed : MonoBehaviour
{
    public bool RedHaveItem = false;
    public bool RedInRed = false;
    private GameObject redobj;
    private void Update()
    {
        redobj.transform.position = gameObject.transform.position;
        redobj.transform.rotation = gameObject.transform.rotation;

        redobj.GetComponent<Rigidbody>().Sleep();
        if (redobj != null)
        {
            RedHaveItem = true;
        }
    }
    private void OnTriggerStay(Collider Item)
    {
        if (Item.tag == "Interactive Objects")
        {
            if (redobj == null)
            {
                redobj = Item.gameObject;
                
            }
          
            
            if(Item.name == "redobj")
            {
                RedInRed = true;
            }
        }
    }
    public void Reset()
    {
     redobj = null;
     RedHaveItem = false;
     RedInRed = false;
    }
}
