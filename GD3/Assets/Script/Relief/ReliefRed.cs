using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefRed : MonoBehaviour
{
    public bool RedHaveItem = false;
    public bool RedInRed = false;
    public GameObject redobj;
    private void Update()
    {
        redobj.transform.position = gameObject.transform.position;
        redobj.transform.rotation = gameObject.transform.rotation;

        redobj.GetComponent<Rigidbody>().Sleep();
        if (redobj != null)
        {
            RedHaveItem = true;
        }
        if(redobj.name == "redobj")
        {
            
                RedInRed = true;
            
        }
    }
   
    public void Reset()
    {
     redobj = null;
     RedHaveItem = false;
     RedInRed = false;
    }
}
