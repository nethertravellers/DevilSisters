using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //public Button StartBtn;
    //public Button EndBtn;
    //public GameObject startmenu;
    //public GameObject endmenu;

    //public Button ReStartBtn;
    //public Button GameEndBtn;
    
    public bool keyeActive;
    public GameObject keye;
    public Text keyetext;
    public bool mouse0Active;
    public GameObject mouse0;
    public Text mouse0text;
    public bool mouse1Active;
    public GameObject mouse1;
    public Text mouse1text;

    public enum State { title,  play,  game_over, end }
    public State currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        mouse0Active = false;
        mouse1Active = false;
        keyeActive = false;
        //StartBtn.onClick.AddListener(() => OnStartBtnPressed());
        //EndBtn.onClick.AddListener(() => OnEndBtnPressed());
        //ReStartBtn.onClick.AddListener(() => OnReStartBtnPressed());
        //GameEndBtn.onClick.AddListener(() => OnEndBtnPressed());
        currentState = State.play;
        //endmenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currentState)
        {
            case State.title:
                Time.timeScale = 0;
                //startmenu.gameObject.SetActive(true);
                              
                break;
            

            case State.play:              
                Time.timeScale = 1;
                //startmenu.gameObject.SetActive(false);
                //Cursor.lockState = CursorLockMode.None;
                //Cursor.lockState = CursorLockMode.Locked;
                if (keyeActive == true)
                {
                    keye.gameObject.SetActive(true);
                }
                else
                {
                    keye.gameObject.SetActive(false);
                }
                if (mouse0Active == true)
                {
                    mouse0.gameObject.SetActive(true);
                }
                else
                {
                    mouse0.gameObject.SetActive(false);
                }
                if (mouse1Active == true)
                {
                    mouse1.gameObject.SetActive(true);
                }
                else
                {
                    mouse1.gameObject.SetActive(false);
                }

                break;

            

            case State.game_over:
                Time.timeScale = 0;
                //lose.gameObject.SetActive(true);
                break;

            case State.end:
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                //endmenu.gameObject.SetActive(true);
                //win.gameObject.SetActive(true);

                break;
        }
    }
    void OnStartBtnPressed()
    {
        currentState = State.play;
    }
    void OnEndBtnPressed()
    {
        Application.Quit();
    }
    void OnReStartBtnPressed()
    {
        SceneManager.LoadScene(0);
    }
    public void OnStartGame(string ScneneName)
    {
        Application.LoadLevel(ScneneName);
    }
}
