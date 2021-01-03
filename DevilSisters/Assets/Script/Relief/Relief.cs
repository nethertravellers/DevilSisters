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
    public GameObject ReliefYellow;
    public GameObject ReliefBlue;
    public GameObject ReliefOrange;

    public GameObject RedKey;
    public GameObject Cage;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
        RedKey.gameObject.SetActive(false);
        Cage.gameObject.SetActive(false);
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
                    RedKey.gameObject.SetActive(true);
                    Cage.gameObject.SetActive(true);
                    
                    finish = true;
                }
            }
            else
            {
                Reset();
            }
        }
    }
    public void Reset()
    {
        Start();
        ReliefRed.gameObject.GetComponent<ReliefRed>().Reset();
        ReliefGreen.gameObject.GetComponent<ReliefGreen>().Reset();
        ReliefPurple.gameObject.GetComponent<ReliefPurple>().Reset();
        Cubered.gameObject.GetComponent<PickItem>().Respawned();
        Cubegreen.gameObject.GetComponent<PickItem>().Respawned();
        Cubepurple.gameObject.GetComponent<PickItem>().Respawned();
    }
}
