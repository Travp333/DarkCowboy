using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public GameObject textLayer;
    public bool NPCisTalking, ShopisOpen;


    public GameObject shopLayer;

    public Texture[] coins;

    bool flipflop=false;

    private Queue<string> sentences;
    private Queue<Item> shopInventory;
    void Start()
    {
        sentences = new Queue<string>();
        shopInventory = new Queue<Item>();
        textLayer.SetActive(false);
        shopLayer.SetActive(false);


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
    void EndDialogue(Grab grab, Shop shop, bool involveCurrencies)
    {
        if (involveCurrencies)
        {
            //Debug.Log("ended conversation with currency man");
            if (shop.getTreatOrTrater())
            {
                grab.currencyInteraction(shop);
            }
            else
            {
                //SELLING A =============================================================================================
                if (shop.selling == Shop.coinType.coinA)
                {
                    grab.Aseller(shop);
                }
                //SELLING B =============================================================================================
                if (shop.selling == Shop.coinType.coinB)
                {
                    grab.Bseller(shop);
                }
                //SELLING C =============================================================================================
                if (shop.selling == Shop.coinType.coinC)
                {
                    grab.Cseller(shop);
                }
                //SELLING D =============================================================================================
                if (shop.selling == Shop.coinType.coinD)
                {
                    grab.Dseller(shop);
                }
                //SELLING E =============================================================================================
                if (shop.selling == Shop.coinType.coinE)
                {
                    grab.Eseller(shop);
                }
                if (shop.selling == Shop.coinType.coinF)
                {
                    grab.Fseller(shop);
                }
                if (shop.selling == Shop.coinType.coinG)
                {
                    grab.Gseller(shop);
                }
                if (shop.selling == Shop.coinType.coinH)
                {
                    grab.Hseller(shop);
                }
            }
        }
        NPCisTalking = false;
        textLayer.SetActive(false);


    }

    IEnumerator TypeSentence(string sentence, Shop shop)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (NPCisTalking)
            {
                //text noise here
                //the flip flop makes it so that it only playe the sound for every other letter, to slow it down a bit 
                if (flipflop)
                {
                    shop.playTextSound();
                    dialogueText.text += letter;
                    yield return null;
                    flipflop = false;
                }
                else
                {
                    dialogueText.text += letter;
                    yield return null;
                    flipflop = true;
                }

            }
        }
    }

    public void StartVendor(ShopItems shopItems)
    {
        shopLayer.SetActive(true);
        ShopisOpen = true;
        shopInventory.Clear();
        foreach (Item item in shopItems.inventory)
        {
            shopInventory.Enqueue(item);
        }
        int ct = shopInventory.Count;
        for (int i = 0; i < ct; i++)
       {
            DisplayVendorInventory(i);
           Debug.Log(i);
       }
    }
    public void DisplayVendorInventory(int i)
    {
        Item item = shopInventory.Dequeue();
        Debug.Log(item.name);

       /* Texture icon = item.icon;
        string name = item.name;
        int cost = item.cost;
        Shop.coinType costCoin = item.costCoin;*/

        GameObject itemSlot = shopLayer.transform.GetChild(i).gameObject;
        

        GameObject currentElement = itemSlot.transform.GetChild(0).gameObject;
        RawImage pic = currentElement.GetComponent<RawImage>();
        pic.texture = item.icon;
        
        Debug.Log("texture"+ i+"changed");

        currentElement = itemSlot.transform.GetChild(1).gameObject;
        Text currentName = currentElement.GetComponent<Text>();
        currentName.text = item.name;

        Debug.Log("name" + i +"changed");

        currentElement = itemSlot.transform.GetChild(2).gameObject;
        Text currentCost = currentElement.GetComponent<Text>();
        currentCost.text = item.cost.ToString();

        Debug.Log("Cost" + i + "changed");

        currentElement = itemSlot.transform.GetChild(3).gameObject;
        pic = currentElement.GetComponent<RawImage>();
        pic.texture = CurrencyEnumtoTexture(item.costCoin);

    }

    public Texture CurrencyEnumtoTexture(Shop.coinType en)
    {

        if (coins.Length == 8)
        {

            return coins[(int)en];
        }
        else
            return null;
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
