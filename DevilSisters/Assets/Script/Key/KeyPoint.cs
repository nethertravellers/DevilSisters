using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPoint : MonoBehaviour
{
    public bool RedHaveItem = false;
    public bool BlueHaveItem = false;
    public Transform keyset;
    public GameObject key;

    private void Update()
    {
        key.transform.position = keyset.position;
        key.transform.rotation = keyset.rotation;
        key.GetComponent<Rigidbody>().Sleep();
        if (key.gameObject.GetComponent<RedKey>())
        {

            RedHaveItem = true;

        }
        if (key.gameObject.GetComponent<BlueKey>())
        {

            BlueHaveItem = true;

        }
        if(key == null)
        {
            RedHaveItem = false;
            BlueHaveItem = false;
        }
    }
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.tag == "Player")
        {

            Player.gameObject.GetComponent<playerObjInteraction>().canputing = true;

        }
    }
    private void OnTriggerExit(Collider Player)
    {
        if (Player.tag == "Player")
        {

            Player.gameObject.GetComponent<playerObjInteraction>().canputing = false;
        }
    }
    
      
    
}
