using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;





public class player : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;
    Vector3 velocity;
    [SerializeField]
    Transform playerInputSpace = default;
    //public float MoveSpeed = 1;
    //public float rotSpeed = 50;

    //private Vector3 moveX;
    //private Vector3 moveZ;
    //private float currentV;
    //private float currentH;

    public bool walkable;
    private bool ground;
    private float JumpSpeed;
    public Animator animator;
    //public float ChangeTime = 3f;
    //public float ChangeTimer;
    public GameObject vfx;  
   
    public GameObject OldSisterBody;
    public float OSJumpSpeed = 1;
    private Animator OldSisteranimator;
    public GameObject YoungSisterBody;
    public float YSJumpSpeed = 10;
    private Animator YoungSisteranimator;
    public GameObject attackCollider;

    public bool attack;
    public bool IsOldSister;

    public float ChangeTime = 15;
    public float ChangeTimer;
    public int chaange = 1;
    public enum State { OldSister, YoungSister }
    public State currentState;

    
    private void Awake()
    {   
    }
    // Start is called before the first frame update
    void Start()
    {
        OldSisteranimator = OldSisterBody.GetComponent<Animator>();
        YoungSisteranimator = YoungSisterBody.GetComponent<Animator>();

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
        
        //ChangeTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            chaange = chaange * -1;
            ChangeTimer = 0;
        }
        
        switch (currentState)
        {
            case State.OldSister:
                IsOldSister = true;
                JumpSpeed = OSJumpSpeed;
                animator = OldSisteranimator;
                if (chaange == -1)
                {
                    walkable = false;
                    //ChangeTimer += Time.deltaTime;
                    //GameObject newVFX = Instantiate(vfx, gameObject.transform.position, Quaternion.identity);
                    //Destroy(newVFX, 2);
                    Invoke("walk",0f);

                    OldSisterBody.gameObject.SetActive(false);
                    YoungSisterBody.gameObject.SetActive(true);
                        currentState = State.YoungSister;                       
                }
                break;
            case State.YoungSister:
                IsOldSister = false;
                JumpSpeed = YSJumpSpeed;
                animator = YoungSisteranimator;
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    animator.SetTrigger("attack");
                    attackCollider.GetComponent<AttackDestoryableCollider>().isAttack = true;
                    Invoke("isAttacked", 2f);
                }

                if (chaange == 1)
                {
                    walkable = false;
                    //ChangeTimer += Time.deltaTime;
                    //GameObject newVFX = Instantiate(vfx, gameObject.transform.position, Quaternion.identity);
                    //Destroy(newVFX, 2);
                    Invoke("walk", 0f);

                    OldSisterBody.gameObject.SetActive(true);
                    YoungSisterBody.gameObject.SetActive(false);
                        currentState = State.OldSister;     
                }
                break;
        }   
        Vector2 playerInput;
        playerInput.x = 0f;
        playerInput.y = 0f;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        if (walkable == true)
        {
            Vector3 desiredVelocity;
            if (playerInputSpace)
            {
                Vector3 forward;
                forward.y = 0f;  
                Vector3 right;
                right.y = 0f;
                if (gameObject.GetComponent<playerObjInteraction>().IsDroping == true)
                {
                    forward =  gameObject.transform.forward;
                    right = gameObject.transform.right;
                }
                else
                {
                    forward = playerInputSpace.forward;
                    forward.Normalize();
                    right = playerInputSpace.right;
                    right.Normalize();
                }
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
            
            //transform.forward.x = Mathf.Lerp(transform.forward.x, displacement.x, rotSpeed * Time.deltaTime);
            if (displacement.x == 0 && displacement.z == 0)
            {
                animator.SetBool("walk", false);
            }
            else
            {
                transform.forward = displacement;
                animator.SetBool("walk", true);
            }
            


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ground == true)
                {
                    animator.SetTrigger("jump");
                    //transform.Translate(new Vector3(Input.GetAxis(“Horizontal”)*distance, 2, Input.GetAxis(“Vertical”)*distance));
                    Invoke("jump", 0.7f);
                }
            }
        }     
    }   
    void jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        GetComponent<Rigidbody>().AddForce(Vector3.up * JumpSpeed);
        ground = false;
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
