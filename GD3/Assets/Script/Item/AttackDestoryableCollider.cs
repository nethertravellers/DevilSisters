using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDestoryableCollider : MonoBehaviour
{
    public bool isAttack;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Destoryable Objects")
        {


            if (isAttack == true)
            {
                col.gameObject.GetComponent<SubObjectGeneration>().IsInstantiate = true;
                gameManager.mouse1Active = false;
            }
            
           
        }
    }
}
