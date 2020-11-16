using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartCollider : MonoBehaviour
{
    public bool gamestart = false;
    public void OnTriggerEnter(Collider Player)
    {
        if (Player.tag == "Player")
        {
            gamestart = true;
        }
    }
}
