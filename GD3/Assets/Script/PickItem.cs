using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    // Start is called before the first frame update
 
    private void OnTriggerStay(Collider Player)
    {
        if (Player.tag == "Player")
        {
            Player.gameObject.GetComponent<player>().cantaking = true;
        }
    }
    private void OnTriggerExit(Collider Player)
    {
        if (Player.tag == "Player")
        {
            Player.gameObject.GetComponent<player>().cantaking = false;
        }
    }

}
