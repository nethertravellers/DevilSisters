using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
     
    public Transform player;
    private float x;
    private float y;
    private float xSpeed = 400;
    private float ySpeed = 400;
    [SerializeField]
    private float distence;
    //private float disSpeed = 100;
    private float minDistence = -1;
    private float maxDistence = 3.5f;
    [SerializeField]
    private float height = 0;
    [SerializeField]
    private float sidedistance = 0;
    private Quaternion rotationEuler;
    private Vector3 cameraPosition;
    
    // Update is called once per frame
    private void Awake()
    {
        x = player.transform.rotation.x;
        distence = 3.5f;
        sidedistance = 0.6f;
    }
    void Update()
    {
        
        
            
        
        if (player.gameObject.GetComponent<playerObjInteraction>().IsDroping == false)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
            y = Mathf.Clamp(y, -30, 30);
            if (x > 360)
            {
                x -= 360;
            }
            else if (x < 0)
            {
                x += 360;
            }
            
        }
        if (player.gameObject.GetComponent<playerObjInteraction>().IsDroping == true)
        {
            distence = Mathf.Lerp(distence, -2, Time.deltaTime * 20);
            sidedistance = Mathf.Lerp(sidedistance, 0, Time.deltaTime * 20);
        }
        else
        {
            distence = Mathf.Lerp(distence, 3.5f, Time.deltaTime * 20);
            sidedistance = Mathf.Lerp(sidedistance, 0.6f, Time.deltaTime * 20);
        }
        //distence -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;
        distence = Mathf.Clamp(distence, minDistence, maxDistence);
        rotationEuler = Quaternion.Euler(y, x, 0);
        //rotationEuler = Quaternion.Euler(0, 0, 0);
        cameraPosition = rotationEuler * new Vector3(sidedistance, height, -distence ) + player.position;
        //cameraPosition = rotationEuler * new Vector3(0, 0, -4) + player.position;
        
        transform.rotation = rotationEuler;
        transform.position = cameraPosition;
    }
}
