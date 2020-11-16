using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class firstcaompiete : MonoBehaviour
{
    private GameObject key;
    public GameObject ui;
    private void Update()
    {
        key = GameObject.Find(name = "DoorKey(Clone)");
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            print(collider.transform.gameObject.GetComponent<player>().takingItem.name);
            if (key == collider.transform.gameObject.GetComponent<player>().takingItem)
            {
                ui.gameObject.SetActive(true);
            }
                

           
        }
    }
}
