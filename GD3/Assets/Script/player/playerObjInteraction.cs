using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerObjInteraction : MonoBehaviour
{
    // public GameObject playercamera;
    public Camera cam;
    public bool IsDroping = false;
    public float takedropingCDtimer;
    public float takedropingCDtime = 0.5f;
    public GameObject takingItem;
    public Transform takingItempoint;
    private Transform dropingpoint;
    public bool cantaking = false;
    public bool Istaking = false;
    public bool canputing = false;
    public RaycastHit hitInfo;
    [SerializeField] private float force = 0;
    [SerializeField] private float Maxforce = 1000;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "lightbutton")
            {
                gameManager.mouse0Active = true;
                gameManager.mouse0text.text = "點亮";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hitInfo.collider.transform.gameObject.GetComponent<lightchange>().lightchangebool = true;
                }
            }
            else
            {
                gameManager.mouse0Active = false;
            }
        }
        takedropingCDtimer += Time.deltaTime;
        //拿道具
        if (cantaking == true)
        {
            gameManager.keyeActive = true;
            gameManager.keyetext.text = "撿起";
            if (Input.GetKeyDown(KeyCode.E) && Istaking == false && takedropingCDtimer >= takedropingCDtime)
            {
                takeItem();
                cantaking = false;
                gameManager.keyeActive = false;
            }
        }
        
        //放置道具
        if (Istaking == true)
        {
            gameManager.keyeActive = false;
            takingItem.transform.position = takingItempoint.position;
            takingItem.transform.rotation = takingItempoint.rotation;
            takingItem.gameObject.GetComponent<PickItem>().taken = true;
            
            if (gameObject.GetComponent<player>().IsOldSister == false)
            {
                gameManager.mouse0Active = true;
                gameManager.mouse0text.text = "丟";
                if (Input.GetKey(KeyCode.Mouse0) && takedropingCDtimer >= takedropingCDtime)
                {
                    dropItem();
                }
            }
            
            if (!Input.GetKey(KeyCode.Mouse0) && force < Maxforce)
            {
                force -= 1000 * Time.deltaTime;
                IsDroping = false;
            }
            force = Mathf.Clamp(force, 0, Maxforce);
            
            if(canputing == true)
            {
                gameManager.keyeActive = true;
                gameManager.keyetext.text = "放置";
                if (Input.GetKey(KeyCode.E) && takedropingCDtimer >= takedropingCDtime)
                {
                    putItem();
                }
            }
            

        }
    }
    public void putItem()
    {
        float radius = 0.1f;
     
        while (radius < 1)
        {
           
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);
            
            if (cols.Length > 0)
                for (int i = 0; i < cols.Length; i++)
                    if (cols[i].tag.Equals("putpoint"))
                    {
                        
                            Istaking = false;                            
                            takingItem = null;
                        
                    }
           
            radius += 0.1f;
        }
        takedropingCDtimer = 0;
    }
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
                        takingItem.GetComponent<Rigidbody>().Sleep();
                        Istaking = true;
                    }
            //沒有檢測到Enemy,將檢測半徑擴大2米
            radius += 0.1f;
        }
        takedropingCDtimer = 0;
    }
    private void dropItem()
    {
        IsDroping = true;
        force += Maxforce * Time.deltaTime;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
        if (Input.GetKey(KeyCode.Mouse0) && force >= Maxforce)
        {
            takedropingCDtimer = 0;
            Istaking = false;
            takingItem.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            takingItem.GetComponent<Rigidbody>().AddForce(ray.direction * force + new Vector3(0, 10, 0));
            takingItem.gameObject.GetComponent<PickItem>().taken = false;
            takingItem = null;
            force = 0;
            gameManager.mouse0Active = false;
            IsDroping = false;
        }
        //Istaking = false;
        //dropingpoint = hitInfo.collider.transform.parent.gameObject.transform;
        //takingItem.transform.position = dropingpoint.position;
        //takingItem = null;
    }
}
