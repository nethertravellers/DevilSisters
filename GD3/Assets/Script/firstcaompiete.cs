using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class firstcaompiete : MonoBehaviour
{
    
    
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //print(collider.transform.gameObject.GetComponent<playerObjInteraction>().takingItem.name);
            if (collider.transform.gameObject.GetComponent<playerObjInteraction>().takingItem.gameObject.GetComponent<Key>())
            {
                gameManager.currentState = GameManager.State.end;
            }
                

           
        }
    }
}
