using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubObjectGeneration : MonoBehaviour
{
    public GameObject DestoryedCube;
    public bool IsInstantiate;
    // Start is called before the first frame update
    void Update()
    {
        if(IsInstantiate == true) 
        {
            Instantiate(DestoryedCube, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
     
    }
}
