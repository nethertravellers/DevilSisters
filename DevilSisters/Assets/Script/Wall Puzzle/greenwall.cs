using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenwall : MonoBehaviour
{
    public Animator animator;
    public bool start;
    public bool finish;
    public enum State { idle, play, end}
    public State currentState;    
    public GameObject redlight;
    public GameObject bluelight;
    public GameObject yellowlight;
    public GameObject greenlight;
    // Start is called before the first frame update
    void Start()
    { 
        start = false;
        finish = false;
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.idle:
                if (start == true && finish == false)
                {
                    animator.SetBool("start", true);
                    currentState = State.play;
                }
                break;
            case State.play:
                if(bluelight.gameObject.GetComponent<lightchange>().lightchangebool == true && 
                    yellowlight.gameObject.GetComponent<lightchange>().lightchangebool == true&&
                   redlight.gameObject.GetComponent<lightchange>().lightchangebool == false)
                {
                    greenlight.gameObject.GetComponent<lightchange>().lightchangebool = true;
                    finish = true;
                }
                else if(bluelight.gameObject.GetComponent<lightchange>().lightchangebool == false &&
                    yellowlight.gameObject.GetComponent<lightchange>().lightchangebool == true &&
                   redlight.gameObject.GetComponent<lightchange>().lightchangebool == true)
                {
                    Reset();
                }
                else if (bluelight.gameObject.GetComponent<lightchange>().lightchangebool == true &&
                    yellowlight.gameObject.GetComponent<lightchange>().lightchangebool == false &&
                   redlight.gameObject.GetComponent<lightchange>().lightchangebool == true)
                {
                    Reset();
                }
                if (finish == true)
                {
                    animator.SetBool("finish", true);
                    currentState = State.end;
                }
                break;
            case State.end:
                break;
        }       
    }
    public void Reset()
    {
        bluelight.gameObject.GetComponent<lightchange>().lightchangebool = false;
        yellowlight.gameObject.GetComponent<lightchange>().lightchangebool = false;
        redlight.gameObject.GetComponent<lightchange>().lightchangebool = false;
    }
}
