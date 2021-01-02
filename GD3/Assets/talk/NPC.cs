using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    //public Transform ChatBackGround;
    private GameObject ChatUI;
    public Transform NPCCharacter;
    [SerializeField]
    private float dialoguepositionZ;
    [SerializeField]
    private float dialoguepositionY;
    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
	
	void Update () {
          //Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Vector3 Pos = NPCCharacter.position;
          Pos.y += dialoguepositionY;
        Pos.z += dialoguepositionZ;
        ChatUI.transform.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        ChatUI = dialogueSystem.dialogueGUI;
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
        {
            
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
              
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        ChatUI = null;
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}

