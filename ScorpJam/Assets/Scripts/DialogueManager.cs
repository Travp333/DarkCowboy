using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public FPSMovingSphere player;
    [SerializeField]
    public PlayerStats stats;
    [SerializeField]
    public SimpleCameraMovement camMovement;
    public Text nameText;
    public Text dialogueText;
    public GameObject textLayer;
    public bool NPCisTalking, ShopisOpen;
   

    public GameObject itemSlotPrefab = default;

    public GameObject shopLayer, shopMenu,errorLayer, inventoryUI;

    public Texture[] coins;

    bool flipflop=false;

    private Queue<string> sentences;
    private Queue<Item> shopInventory;
    float errorTime = 2f;
    float timer;
    
    void Start()
    {
        sentences = new Queue<string>();
        shopInventory = new Queue<Item>();
        textLayer.SetActive(false);
        shopLayer.SetActive(false);
        errorLayer.SetActive(false);
        inventoryUI.SetActive(false);
        timer = 0f;

    }

    void Update() {

        if (ShopisOpen){
            if (Input.GetKeyDown(KeyCode.Mouse1)) {

                CloseShopMenu();  
            }
        }
        if (errorLayer.activeSelf) {
            timer += Time.deltaTime;
            
            if (timer > errorTime)
            {
                Debug.Log(timer +" " +errorTime);
                Debug.Log("errorscreenfalse");
                errorLayer.SetActive(false);
                timer = 0f;
            }
        }
        
        camMovement.cameraRotLock = NPCisTalking||ShopisOpen;
        if (camMovement.cameraRotLock)
        {
            player.blockMovement();
        }
        else {
            player.unblockMovement();
        }


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

            grab.gameObject.transform.root.gameObject.GetComponent<FPSMovingSphere>().unblockMovement();
            EndDialogue(grab, shop, involveCurrencies);
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(sentence, shop, involveCurrencies));
        

    }
    //this is getting fired over and over constantly while you are not in range of an npc it seems
    public void EndDialogue(Grab grab, Shop shop, bool involveCurrencies)
    {
        
        if (involveCurrencies)
        {
            //Debug.Log("ended conversation with currency man");
            if (shop.getTreatOrTrater())
            {
                shop.beenTreated = true;
                grab.currencyInteraction(shop);
                grab.gameObject.transform.root.gameObject.GetComponent<PlayerStats>().trickOrTreated += 1;
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
        
        
        Debug.Log("dialogue set to true");

    }

    IEnumerator TypeSentence(string sentence, Shop shop, bool involveCurrencies)
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
        inventoryUI.SetActive(true);
        camMovement.cameraRotLock = true;
        shopInventory.Clear();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        foreach (Item item in shopItems.inventory)
        {
            shopInventory.Enqueue(item);
        }
        int ct = shopInventory.Count;
        if(!ShopisOpen)
        {
            for (int i = 0; i < ct; i++)
        {
            DisplayVendorInventory(i);
            Debug.Log(i);
        }
            }
        ShopisOpen = true;
    }
    public void DisplayVendorInventory(int i)
    {
        var Slot = Instantiate(itemSlotPrefab, shopMenu.transform);
        Slot.transform.SetParent(shopMenu.transform, false);

        Item item = shopInventory.Dequeue();
        Debug.Log(item.name);

       /* Texture icon = item.icon;
        string name = item.name;
        int cost = item.cost;
        Shop.coinType costCoin = item.costCoin;*/

        GameObject itemSlot = shopMenu.transform.GetChild(i).gameObject;
        

        GameObject currentElement = itemSlot.transform.GetChild(0).gameObject;
        RawImage pic = currentElement.GetComponent<RawImage>();
        pic.texture = item.icon;
        if ((int)item.ItemType < 8) //ignores icon if item is a coin and gives it the correct icon based on the type
        {pic.texture = pic.texture = CurrencyEnumtoTexture(item.ItemType);
        }
        currentElement = currentElement.transform.GetChild(0).gameObject;
        Text currentText = currentElement.GetComponent<Text>();
        currentText.text = "x" + item.quantity.ToString();

        Debug.Log("texture"+ i+"changed");

        currentElement = itemSlot.transform.GetChild(1).gameObject;
        currentText = currentElement.GetComponent<Text>();
        currentText.text = item.name;

        Debug.Log("name" + i +"changed");

        currentElement = itemSlot.transform.GetChild(2).gameObject;
        currentText = currentElement.GetComponent<Text>();
        currentText.text = item.cost.ToString();

        

        Debug.Log("Cost" + i + "changed");

        currentElement = itemSlot.transform.GetChild(3).gameObject;
        pic = currentElement.GetComponent<RawImage>();
        pic.texture = CurrencyEnumtoTexture(item.costCoin);

        currentElement = itemSlot.transform.GetChild(4).gameObject;
        Button buy = currentElement.GetComponent<Button>();
        buy.onClick.AddListener(delegate{Trade(item);});

        



    }

    public void CloseShopMenu() {
        Debug.Log("CloseShopMenuCalled");
        foreach (Transform child in shopMenu.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        shopLayer.SetActive(false);
        
        ShopisOpen = false;
        inventoryUI.SetActive(false);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public Texture CurrencyEnumtoTexture(Shop.coinType en)
    {
        if (coins.Length > 0)
        {

            return coins[(int)en];
        }
        else
            return null;
    }
    public void Trade(Item getItem) {
        PlayerStats pStats = FindObjectOfType<PlayerStats>();
        if (!pStats) { Debug.Log("CouldntFindStats");}
        int[] playerCoins = { pStats.coinA, pStats.coinB, pStats.coinC, pStats.coinD, pStats.coinE, pStats.coinF, pStats.coinG, pStats.coinH};

        if ((int)getItem.ItemType < 8)//if the item is a coin
        {
            if (playerCoins[(int)getItem.costCoin] > getItem.cost)
            {
                playerCoins[(int)getItem.costCoin] -= getItem.cost; //subtract from inventory
                playerCoins[(int)getItem.ItemType] += getItem.quantity;
            }
            else {
                Debug.Log("elsebeforecant");
                CantDoThat();
            }
        }
        if ((int)getItem.ItemType == 8) {
            //special cases for items
            if (playerCoins[(int)getItem.costCoin] >= getItem.cost)
            {
                if (getItem.name.Equals("Burger(11hp)"))
                {

                    if (stats.hp <= stats.maxHp)
                    {
                        stats.hp += 11;
                        playerCoins[(int)getItem.costCoin] -= getItem.cost;

                    }
                    else { CantDoThat(); }
                }
                if (getItem.name == "GUN")
                {
                    stats.hasGun = true;
                }

            }
            else {
                CantDoThat();

            }
        }
            pStats.coinA = playerCoins[0];
            pStats.coinB = playerCoins[1];
            pStats.coinC = playerCoins[2];
            pStats.coinD = playerCoins[3];
            pStats.coinE = playerCoins[4];
            pStats.coinF = playerCoins[5];
            pStats.coinG = playerCoins[6];
            pStats.coinH = playerCoins[7];
    }

    void CantDoThat() {
        
        errorLayer.SetActive(true);
        Debug.Log("cantdothat");
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
