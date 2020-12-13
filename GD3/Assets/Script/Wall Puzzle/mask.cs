using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask : MonoBehaviour
{
    public AudioSource audioSourceSFX;
    public AudioClip audioClip;
    
    
    private bool IsInteractive;
    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void PlaySoundFX(AudioClip clip)
    {       
        audioSourceSFX.PlayOneShot(clip);
    }
    private void OnTriggerStay(Collider Player)
    {
        
        if (Player.tag == "Player")
        {
            if (IsInteractive == false)
            {
                gameManager.keyeActive = true;
                gameManager.keyetext.text = "互動";
            }
            
            if (Input.GetKeyDown(KeyCode.E) && IsInteractive == false)
            {
                IsInteractive = true;
                PlaySoundFX(audioClip);
                gameManager.keyeActive = false;
                Invoke("reclick", 7f);
            }
        }
    }
   
    private void OnTriggerExit(Collider Player)
    {
        if (Player.tag == "Player")
        {
            gameManager.keyeActive = false;
        }
    }
   private void reclick()
    {
        IsInteractive = false;
    }
   
}
