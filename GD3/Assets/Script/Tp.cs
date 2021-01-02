using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public Transform tppoint;
    private GameObject tpplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Player)
    {
            if (Player.tag == "Player" )
            {
            tpplayer = Player.gameObject;
            TP();
            }
        
    }
    private void TP()
    {
        tpplayer.transform.position = tppoint.position;
    }
}
