using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool taken = false;
    private void OnTriggerStay(Collider Player)
    {
        if (Player.tag == "Player")
        {
            Player.gameObject.GetComponent<playerObjInteraction>().cantaking = true;
        }
    }
    private void OnTriggerExit(Collider Player)
    {
        if (Player.tag == "Player")
        {
            Player.gameObject.GetComponent<playerObjInteraction>().cantaking = false;
        }
    }

}
