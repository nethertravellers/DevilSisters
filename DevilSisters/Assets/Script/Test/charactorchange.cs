using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactorchange : MonoBehaviour
{
    public GameObject vfx;

    public GameObject a;
    public GameObject b;
    public bool Changeing;
    public enum State { Oldsister, Youngsister }
    public State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Oldsister;
        Changeing = false;
    }

    void changed()
    {
        Changeing = false;
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Oldsister:
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Changeing = true;
                    //ChangeTimer += Time.deltaTime;
                    GameObject newVFX = Instantiate(vfx, gameObject.transform.position, Quaternion.identity);
                    Destroy(newVFX, 3);
                    Invoke("changed", 2f);

                    a.gameObject.SetActive(false);
                    b.gameObject.SetActive(true);
                    currentState = State.Youngsister;
                }

                break;
            case State.Youngsister:
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Changeing = true;
                    //ChangeTimer += Time.deltaTime;
                    GameObject newVFX = Instantiate(vfx, gameObject.transform.position, Quaternion.identity);
                    Destroy(newVFX, 3);
                    Invoke("changed", 2f);

                    a.gameObject.SetActive(true);
                    b.gameObject.SetActive(false);
                    currentState = State.Oldsister;
                }

                break;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       

    }
}
