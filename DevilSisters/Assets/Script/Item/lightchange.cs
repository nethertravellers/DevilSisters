using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightchange : MonoBehaviour
{
    public Material OriginalMaterial;
    public Material AttributesMaterial;
    public Material OpenOriginalMaterial;
    public Material OpenAttributesMaterial;
    public bool lightchangebool;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material = OriginalMaterial;
        lightchangebool = false;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("player").GetComponent<player>().IsOldSister == true)
        {
            if(lightchangebool == false)
            {
                gameObject.GetComponent<Renderer>().material = AttributesMaterial;
            }
            if(lightchangebool ==true)
            {
                gameObject.GetComponent<Renderer>().material = OpenAttributesMaterial;
            }
        }
        else
        {
            if (lightchangebool == false)
            {
                gameObject.GetComponent<Renderer>().material = OriginalMaterial;
            }
            if (lightchangebool == true)
            {
                gameObject.GetComponent<Renderer>().material = OpenOriginalMaterial;
            }
        }
    }
}
