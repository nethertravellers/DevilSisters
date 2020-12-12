using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObjectMaterialChange : MonoBehaviour
{
    public Material OriginalMaterial;
    public Material AttributesMaterial;
    
   
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = OriginalMaterial;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameObject.Find("player").GetComponent<player>().IsOldSister == true)
        {
            gameObject.GetComponent<Renderer>().material = AttributesMaterial;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = OriginalMaterial;
        }
    }
    
}
