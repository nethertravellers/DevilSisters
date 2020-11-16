using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuzzle : MonoBehaviour
{
    public GameObject gamestartcollider;
    public GameObject greenwall;
    public GameObject orangewall;
    public GameObject purplewall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamestartcollider.GetComponent<GameStartCollider>().gamestart == true)
        {
            greenwall.GetComponent<greenwall>().start = true;
            orangewall.GetComponent<orangewall>().start = true;
            purplewall.GetComponent<purplewall>().start = true;
            
        }
    }
    
}
