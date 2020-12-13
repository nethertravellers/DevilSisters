using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePoint : MonoBehaviour
{
    public bool BlueHaveItem = false;
    public Transform bluekeyset;
    private GameObject key;

    private void Update()
    {
        key.transform.position = bluekeyset.position;
        key.GetComponent<Rigidbody>().Sleep();

    }
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.tag == "Player")
        {
            Player.gameObject.GetComponent<playerObjInteraction>().canputing = true;

        }
    }
    private void OnTriggerExit(Collider Player)
    {
        if (Player.tag == "Player")
        {
            Player.gameObject.GetComponent<playerObjInteraction>().canputing = false;
        }
    }
    private void OnCollisionStay(Collision Item)
    {
        if (Item.gameObject.name == "BlueKey")
        {
            key = Item.gameObject;
            BlueHaveItem = true;
        }
    }
}
