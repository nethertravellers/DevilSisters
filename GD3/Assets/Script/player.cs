using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;




public class player : MonoBehaviour
{
    public float MoveSpeed = 1;
    //public float ChangeTime = 3f;
    //public float ChangeTimer;
    public GameObject vfx;
   // public GameObject playercamera;
    public Camera cam;
    public GameObject OldSisterBody;
    public GameObject YoungSisterBody;
    public GameObject attackCollider;


    
    public float RotateSpeed = 1;
    public float rotSpeed = 50;
    public bool walkable;
    public bool attack;
    private Vector3 moveX;
    private Vector3 moveZ;
    private float currentV;
    private float currentH;
    public bool IsOldSister;

    public float ChangeTime = 15;
    public float ChangeTimer;
    public int chaange = 1;
    public enum State { OldSister, YoungSister }
    public State currentState;

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
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    attackCollider.GetComponent<AttackDestoryableCollider>().isAttack = true;
                    Invoke("isAttacked", 2f);

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

            //currentH = Mathf.Lerp(currentH, h, 10);

            transform.position += transform.forward * currentV * Time.deltaTime * MoveSpeed;
           // transform.position += (moveX + moveZ) * Time.deltaTime * MoveSpeed;
            transform.rotation *= Quaternion.Euler(new Vector3(0, currentH * Time.deltaTime * rotSpeed, 0));
            //transform.rotation *= Quaternion.Euler(new Vector3(0, currentH * rotSpeed, 0));
            //transform.localRotation *= Quaternion.Euler(new Vector3(0, currentH * rotSpeed, 0));
            //transform.rotation *= Quaternion.Euler(0, h  ,0);
        }
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "lightbutton")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hitInfo.collider.transform.parent.gameObject.GetComponent<lightchange>().lightchangebool = true;
    
                }
            }
        }
        //拿道具
        if (cantaking == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Istaking == false)
            {
                takeItem();
                cantaking = false;
            }
        }
        //放置道具
        if (Istaking == true)
        { 
            takingItem.transform.position = takingItempoint.position;
            takingItem.transform.rotation = takingItempoint.rotation;
           // dropingCDtimer += Time.deltaTime;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Dropcollider" )
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0)) //&& dropingCDtimer >= dropingCDtime)
                    {
                        Istaking = false;
                        dropingpoint =  hitInfo.collider.transform.parent.gameObject.transform;
                        takingItem.transform.position = dropingpoint.position;
                        takingItem = null;
                        //dropingCDtimer = 0;
                    }
                  
                }
            }
        }
    }
   // public float dropingCDtimer;
   // public float dropingCDtime = 0.5f;
    public GameObject takingItem;
    public Transform takingItempoint;
    private Transform dropingpoint;
    public bool cantaking = false;
    public bool Istaking = false;
    public RaycastHit hitInfo;
   // public float dropforce = 3000;
    //尋找道具
    void takeItem()
    {
        float radius = 0.1f;
        //一步一步擴大搜索半徑,最大擴大到100
        while (radius < 1)
        {
            //球形射線檢測,得到半徑radius米範圍內所有的物件
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);
            //判斷檢測到的物件中有沒有Enemy
            if (cols.Length > 0)
                for (int i = 0; i < cols.Length; i++)
                    if (cols[i].tag.Equals("Interactive Objects"))
                    {
                   takingItem = cols[i].gameObject;
                        Istaking = true;
                    }
            //沒有檢測到Enemy,將檢測半徑擴大2米
            radius += 0.1f;
        }
      
    }
 
}
