using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubObjectGeneration : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject DestoryedCube;
    public bool IsInstantiate;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {

        if(IsInstantiate == true) 
        {
            Instantiate(DestoryedCube, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
     
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
           
                gameManager.mouse1Active = false;
            
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.GetComponent<player>().IsOldSister == false)
            {
                gameManager.mouse1Active = true;
            }
            else
            {
                gameManager.mouse1Active = false;
            }            
        }
    }
}

