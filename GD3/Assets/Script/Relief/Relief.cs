using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relief : MonoBehaviour
{
    public GameObject Cubered;
    public GameObject Cubegreen;
    public GameObject Cubepurple;
    public GameObject ReliefRed;
    public GameObject ReliefGreen;
    public GameObject ReliefPurple;
    public GameObject RedballKey;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
    
        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReliefRed.gameObject.GetComponent<ReliefRed>().RedHaveItem == true && 
            ReliefGreen.gameObject.GetComponent<ReliefGreen>().GreenHaveItem == true &&
            ReliefPurple.gameObject.GetComponent<ReliefPurple>().PurpleHaveItem == true)
        {
            if (ReliefRed.gameObject.GetComponent<ReliefRed>().RedInRed == true &&
                ReliefGreen.gameObject.GetComponent<ReliefGreen>().GreenInGreen == true &&
                ReliefPurple.gameObject.GetComponent<ReliefPurple>().PurpleInPurple == true)
            {
                if(finish == false)
                {
                    Instantiate(RedballKey, new Vector3(-47.5f, 10, 0), new Quaternion(0,0,0,0));
                    finish = true;
                }
            }
            else
            {
               Start();
                ReliefRed.gameObject.GetComponent<ReliefRed>().Reset();
                ReliefGreen.gameObject.GetComponent<ReliefGreen>().Reset();
              ReliefPurple.gameObject.GetComponent<ReliefPurple>().Reset();
            }
        }
    }

}
