using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDestoryableCollider : MonoBehaviour
{
    public bool isAttack;
   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Destoryable Objects" && isAttack == true)
        {
            col.gameObject.GetComponent<SubObjectGeneration>().IsInstantiate = true;
           
        }
    }
}
