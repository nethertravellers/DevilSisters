using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;




public class player : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float rotSpeed = 50;

    private Vector3 moveX;
    private Vector3 moveZ;
    private float currentV;
    private float currentH;

    public bool walkable;

    private bool ground;
    private float JumpSpeed;
     
    //public float ChangeTime = 3f;
    //public float ChangeTimer;
    public GameObject vfx;  
   
    public GameObject OldSisterBody;
    public float OSJumpSpeed = 1;
    public GameObject YoungSisterBody;
    public float YSJumpSpeed = 10;
    public GameObject attackCollider;

    public bool attack;
    public bool IsOldSister;

    public float ChangeTime = 15;
    public float ChangeTimer;
    public int chaange = 1;
    public enum State { OldSister, YoungSister }
    public State currentState;
    //private CharacterController characterController;
    private void Awake()
    {
        //characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.OldSister;
        walkable = true;
        OldSisterBody.gameObject.SetActive(true);
        YoungSisterBody.gameObject.SetActive(false);
        
    }
    void walk()
    {
        walkable = true;
    }
    public void isAttacked()
    {       
            attackCollider.GetComponent<AttackDestoryableCollider>().isAttack = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        ChangeTimer += Time.deltaTime;
        if(ChangeTimer >= ChangeTime)
        {
            chaange = chaange * -1;
            ChangeTimer = 0;
        }
        
        switch (currentState)
        {
            case State.OldSister:
                IsOldSister = true;
                JumpSpeed = OSJumpSpeed;

                if (chaange == -1)
                {
                    walkable = false;
                    //ChangeTimer += Time.deltaTime;
                    GameObject newVFX = Instantiate(vfx, gameObject.transform.position, Quaternion.identity);
                    Destroy(newVFX, 2);
                    Invoke("walk",1.5f);

                    OldSisterBody.gameObject.SetActive(false);
                    YoungSisterBody.gameObject.SetActive(true);
                        currentState = State.YoungSister;                       
                }
                break;
            case State.YoungSister:
                IsOldSister = false;
                JumpSpeed = YSJumpSpeed;
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    attackCollider.GetComponent<AttackDestoryableCollider>().isAttack = true;
                    Invoke("isAttacked", 2f);
                }

                if (chaange == 1)
                {
                    walkable = false;
                    //ChangeTimer += Time.deltaTime;
                    GameObject newVFX = Instantiate(vfx, gameObject.transform.position, Quaternion.identity);
                    Destroy(newVFX, 2);
                    Invoke("walk", 1.5f);

                    OldSisterBody.gameObject.SetActive(true);
                    YoungSisterBody.gameObject.SetActive(false);
                        currentState = State.OldSister;     
                }
                break;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(walkable == true)
        {
            moveX = transform.right * h;
            moveZ = transform.forward * v;
            currentV = Mathf.Lerp(currentV, v, Time.deltaTime * 20);
            currentH = Mathf.Lerp(currentH, h, Time.deltaTime * 20);

            //Vector3 movement = new Vector3(h, 0, v);
            //characterController.SimpleMove(movement * Time.deltaTime * MoveSpeed);
            //if(movement.magnitude > 0)
            //{
            //    Quaternion newDirection = Quaternion.LookRotation(movement);
            //    transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * rotSpeed);
            //}
            transform.position += transform.forward * currentV * Time.deltaTime * MoveSpeed;         
            transform.rotation *= Quaternion.Euler(new Vector3(0, currentH * Time.deltaTime * rotSpeed, 0));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ground == true)
                {
                    //transform.Translate(new Vector3(Input.GetAxis(“Horizontal”)*distance, 2, Input.GetAxis(“Vertical”)*distance));
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
                    GetComponent<Rigidbody>().AddForce(Vector3.up * JumpSpeed);
                    ground = false;     
                }
            }
        }     
    }   
    void OnCollisionEnter(Collision collision)
    {
        ground = true;
    }
    //bool IsGrounded()
    //{
    //    return Physics.Raycast(transform.position, -Vector3.up, 0.75f);
    //}
}
