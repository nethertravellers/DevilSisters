﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button StartBtn;
    public Button EndBtn;

    public GameObject menu;

    public bool keyeActive;
    public GameObject keye;
    public Text keyetest;

    public enum State { title,  play,  game_over, end }
    public State currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        keyeActive = false;
        StartBtn.onClick.AddListener(() => OnStartBtnPressed());
        EndBtn.onClick.AddListener(() => OnEndBtnPressed());
       // currentState = State.title;
        currentState = State.play;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.title:
                Time.timeScale = 0;
                menu.gameObject.SetActive(true);

                break;
            

            case State.play:              
                Time.timeScale = 1;
                if(keyeActive == true)
                {
                    keye.gameObject.SetActive(true);
                }
                else
                {
                    keye.gameObject.SetActive(false);
                }
                            

                break;

            

            case State.game_over:
                Time.timeScale = 0;
                //lose.gameObject.SetActive(true);
                break;

            case State.end:
                Time.timeScale = 0;
                //win.gameObject.SetActive(true);

                break;
        }
    }
    void OnStartBtnPressed() { }
    void OnEndBtnPressed() { }
}
