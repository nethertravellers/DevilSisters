using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instforce : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject player;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.mouse1Active = false;
        player = GameObject.Find("player");
        Vector3 move =   gameObject.transform.position -player.transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(move.x *250, move.y *150, move.z * 250);
    }
}
