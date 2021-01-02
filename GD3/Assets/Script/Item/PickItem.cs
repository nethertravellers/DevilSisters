using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    private Vector3 spawnedpoint;
    private GameManager gameManager;
    private Vector3 Ogscale;
    private void Awake()
    {
        spawnedpoint = gameObject.transform.position;
        Ogscale = gameObject.transform.localScale;
    }
    public void Respawned()
    {
        gameObject.GetComponent<Rigidbody>().Sleep();
        gameObject.transform.position = spawnedpoint;
        gameObject.GetComponent<MeshCollider>().isTrigger = false;

    }
    void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
       if (taken == true)
        {
            gameObject.transform.localScale = Ogscale * 0.3f;
        }
        else
        {
            gameObject.transform.localScale = Ogscale;
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    Respawned();
        //}
    }
    // Start is called before the first frame update
    public bool taken = false;
    private void OnTriggerStay(Collider Player)
    {
        if(taken == false)
        {
            if (Player.tag == "Player" && Player.gameObject.GetComponent<playerObjInteraction>().Istaking == false)
            {
                gameManager.keyeActive = true;
                gameManager.keyetext.text = "撿起";
                Player.gameObject.GetComponent<playerObjInteraction>().cantaking = true;
            }
        }
       
    }
    private void OnTriggerExit(Collider Player)
    {
        if (taken == false)
        {
            if (Player.tag == "Player" && Player.gameObject.GetComponent<playerObjInteraction>().Istaking == false)
            {
                gameManager.keyeActive = false;
                Player.gameObject.GetComponent<playerObjInteraction>().cantaking = false;
            }
        }       
    }

}
