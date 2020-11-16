using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSnake : MonoBehaviour
{
    
    public GameObject RedballPoint;
    public GameObject BlueballPoint;
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
        if (RedballPoint.gameObject.GetComponent<RedballPoint>().RedHaveItem == true &&
            BlueballPoint.gameObject.GetComponent<BlueballPoint>().BlueHaveItem == true )
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
