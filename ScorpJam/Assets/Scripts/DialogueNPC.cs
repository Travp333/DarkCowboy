using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    [SerializeField]
    bool involveCurrencies;
    Shop shop;
    // Start is called before the first frame update
    public Dialogue dialogue;
    Grab grab;

    PolSounds sounds;

    void Start() {
        grab = FindObjectOfType<Grab>();
        shop = GetComponent<Shop>();
        //sounds = GetComponent<PolSounds>();
    }

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, shop, grab, involveCurrencies);
        //if(TryGetComponent<PolSounds>(out var sound)){
            //sound.playRandomPolSound();
        //}
        
    }
    public void CancelDialogue() {
        FindObjectOfType<DialogueManager>().EndDialogue( grab, shop, involveCurrencies);
    }
    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence(grab, shop, involveCurrencies);
    }
}
