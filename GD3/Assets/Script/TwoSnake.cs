using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSnake : MonoBehaviour
{
    
    public GameObject RedPoint;
    public GameObject BluePoint;
    public GameObject fakeDoorKey;
    public GameObject DoorKey;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RedPoint.gameObject.GetComponent<RedPoint>().RedHaveItem == true &&
            BluePoint.gameObject.GetComponent<BluePoint>().BlueHaveItem == true )
        {            
                if (finish == false)
                {
                    Instantiate(DoorKey, new Vector3(0, 2.5f, -2), new Quaternion(0, 0, 0, 0));
                Destroy(fakeDoorKey);
                    finish = true;
                }
            
        }
    }

}
