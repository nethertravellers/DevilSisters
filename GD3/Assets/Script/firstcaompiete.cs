using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
                gameManager.OnStartGame("second round");
                SceneManager.LoadScene(4);
            }
                

           
        }
    }
}
