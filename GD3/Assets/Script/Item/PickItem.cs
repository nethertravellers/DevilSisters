using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
