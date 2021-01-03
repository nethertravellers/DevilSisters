using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;
    //[SerializeField, Range(0f, 360f)]
    //float tandisplacement = 0;
    Vector3 velocity;
    [SerializeField]
    Transform playerInputSpace = default;
   
    void Start()
    {  
    }
    void Update()
    {   
    Vector2 playerInput;
        playerInput.x = 0f;
        playerInput.y = 0f;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        
        Vector3 desiredVelocity;
        if (playerInputSpace)
        {
            Vector3 forward = playerInputSpace.forward;
            forward.y = 0f;
            forward.Normalize();
            Vector3 right = playerInputSpace.right;
            right.y = 0f;
            right.Normalize();
            desiredVelocity = (forward * playerInput.y + right * playerInput.x) * maxSpeed;
        }
        else
        {
            desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        }
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        Vector3 displacement = velocity * Time.deltaTime;    
        transform.localPosition += displacement;
        float TurnAmount = Mathf.Atan2(displacement.x, displacement.z);
        float turnSpeed = Mathf.Lerp(180, 360, displacement.x); 
            transform.Rotate(0, TurnAmount * turnSpeed * Time.deltaTime, 0);      
        transform.Rotate(0, TurnAmount * turnSpeed * Time.deltaTime, 0);
        
    }
}
