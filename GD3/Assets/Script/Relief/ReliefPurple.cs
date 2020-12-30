using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefPurple : MonoBehaviour
{
    private GameObject purpleobj;
    public bool PurpleHaveItem = false;
    public bool PurpleInPurple = false;
    private void Update()
    {
        purpleobj.transform.position = gameObject.transform.position;
        purpleobj.transform.rotation = gameObject.transform.rotation;

        purpleobj.GetComponent<Rigidbody>().Sleep();
        if (purpleobj != null)
        {
            PurpleHaveItem = true;
        }
    }
    private void OnTriggerStay(Collider Item)
    {
        if (Item.tag == "Interactive Objects")
        {
            if (purpleobj == null)
            {
                purpleobj = Item.gameObject;
                
            }
           
           
            if (Item.name == "purpleobj")
            {
                PurpleInPurple = true;
            }
        }
    }
    public void Reset()
    {
        purpleobj = null;
        PurpleHaveItem = false;
        PurpleInPurple = false;
    }
}
