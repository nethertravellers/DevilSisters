using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefGreen : MonoBehaviour
{
    public GameObject greenobj;
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
        if (greenobj.name == "greenobj")
        {
            GreenInGreen = true;
        }
    }
    
    public void Reset()
    {
        greenobj = null;
        GreenHaveItem = false;
        GreenInGreen = false;
    }
}
