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
    public RaycastHit hitInfo;
    [SerializeField] private float force = 0;
    [SerializeField] private float Maxforce = 1000;

    void Start()
    {
        
    }
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "lightbutton")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hitInfo.collider.transform.gameObject.GetComponent<lightchange>().lightchangebool = true;
                }
            }
        }
        takedropingCDtimer += Time.deltaTime;
        //拿道具
        if (cantaking == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Istaking == false && takedropingCDtimer >= takedropingCDtime)
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
            takingItem.gameObject.GetComponent<PickItem>().taken = true;
            //dropingCDtimer += Time.deltaTime;
            //if (Physics.Raycast(ray, out hitInfo))
            //{
            //    if (hitInfo.collider.gameObject.tag == "Dropcollider" )
            //    {
            if (Input.GetKey(KeyCode.Mouse0) && takedropingCDtimer >= takedropingCDtime)
            {
                dropItem();
            }
            else if (!Input.GetKey(KeyCode.Mouse0) && force < Maxforce)
            {
                force -= 1000 * Time.deltaTime;
                IsDroping = false;
            }
            force = Mathf.Clamp(force, 0, Maxforce);
            //    }
            //}
        }
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
            IsDroping = false;
        }
        //Istaking = false;
        //dropingpoint = hitInfo.collider.transform.parent.gameObject.transform;
        //takingItem.transform.position = dropingpoint.position;
        //takingItem = null;
    }
}
