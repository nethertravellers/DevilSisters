using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instforce : MonoBehaviour
{
    private GameObject player;
    private void Awake()
    {
        player = GameObject.Find("player");
        Vector3 move =   gameObject.transform.position -player.transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(move.x *250, move.y *150, move.z * 250);
    }
}
