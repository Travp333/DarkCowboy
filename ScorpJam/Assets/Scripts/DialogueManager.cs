using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public GameObject textLayer;
    public bool NPCisTalking;

    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    // this is just me trying to tie the shop script and the dialogue script together ==================================================

    public void StartDialogue(Dialogue dialogue, Shop shop, Grab grab, bool involveCurrencies) 
    {
        textLayer.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        NPCisTalking = true;

        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(grab, shop, involveCurrencies);
    }

    public void DisplayNextSentence(Grab grab, Shop shop, bool involveCurrencies) 
    {
        if (sentences.Count == 0) 
        {
            EndDialogue(grab, shop, involveCurrencies);
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, shop));
        
    }
    void EndDialogue(Grab grab, Shop shop, bool involveCurrencies) {
        if(involveCurrencies){
            //Debug.Log("ended conversation with currency man");
            if(shop.getTreatOrTrater()){
                grab.currencyInteraction(shop);
            }
            else{
                //SELLING A =============================================================================================
                if(shop.selling == Shop.coinType.coinA){
                    grab.Aseller(shop);
                }
                //SELLING B =============================================================================================
                if(shop.selling == Shop.coinType.coinB){
                    grab.Bseller(shop);
                }
                //SELLING C =============================================================================================
                if(shop.selling == Shop.coinType.coinC){
                    grab.Cseller(shop);
                }
                //SELLING D =============================================================================================
                if(shop.selling == Shop.coinType.coinD){
                    grab.Dseller(shop);
                }
                //SELLING E =============================================================================================
                if(shop.selling == Shop.coinType.coinE){
                    grab.Eseller(shop);
                }
                if(shop.selling == Shop.coinType.coinF){
                    grab.Fseller(shop);
                }
                if(shop.selling == Shop.coinType.coinG){
                    grab.Gseller(shop);
                }
                if(shop.selling == Shop.coinType.coinH){
                    grab.Hseller(shop);
                }
            }
            
        }
        else{
            //Debug.Log("ended conversation with normal man");
        }
        //imma add a thing here so that the dialogue ending calls a method, 
        NPCisTalking = false;
        textLayer.SetActive(false);
        
    }

    IEnumerator TypeSentence(string sentence, Shop shop) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //text noise here
            shop.playTextSound();
            dialogueText.text += letter;
            yield return null;
        }
    }
}

    //Below here is just the normal script ==============================================

/*
    public void StartDialogue(Dialogue dialogue) 
    {
        textLayer.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        NPCisTalking = true;

        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() 
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }
    void EndDialogue() {
        Debug.Log("ended conversation");
        NPCisTalking = false;
        textLayer.SetActive(false);
    }
}
*/
