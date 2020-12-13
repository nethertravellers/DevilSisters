using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instforce : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));
    }
}
