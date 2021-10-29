using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    //currently the way this is set up is that you can only deposit or withdraw one type of coin at a time.
    //
    [SerializeField]
    public GameObject bankLayer;
    [SerializeField]
    public RawImage coinIcon;
    [SerializeField]
    public GameObject[] values;//ui elements
    public Shop.coinType S;
    GameObject player;
    int coinA,coinB,coinC,coinD,coinE,coinF,coinG,coinH;
    int[] vals;
    // Start is called before the first frame update

    public void switchCoin(){
        
        //I Added a -1 because it was including ITEM as well
        S = (Shop.coinType)Random.Range(0, System.Enum.GetValues(typeof(Shop.coinType)).Length - 1);
        coinIcon.texture = dialogueManager.CurrencyEnumtoTexture(S);
    }
    public void deposit(){
        if(S == Shop.coinType.coinA){
            coinA += player.GetComponent<PlayerStats>().coinA;
            player.GetComponent<PlayerStats>().coinA = 0;
        }
        if(S == Shop.coinType.coinB){
            coinB += player.GetComponent<PlayerStats>().coinB;
            player.GetComponent<PlayerStats>().coinB = 0;
        }
        if(S == Shop.coinType.coinC){
            coinC += player.GetComponent<PlayerStats>().coinC;
            player.GetComponent<PlayerStats>().coinC = 0;
        }
        if(S == Shop.coinType.coinD){
            coinD += player.GetComponent<PlayerStats>().coinD;
            player.GetComponent<PlayerStats>().coinD = 0;
        }
        if(S == Shop.coinType.coinE){
            coinE += player.GetComponent<PlayerStats>().coinE;
            player.GetComponent<PlayerStats>().coinE = 0;
        }
        if(S == Shop.coinType.coinF){
            coinF += player.GetComponent<PlayerStats>().coinF;
            player.GetComponent<PlayerStats>().coinF = 0;
        }
        if(S == Shop.coinType.coinG){
            coinG += player.GetComponent<PlayerStats>().coinG;
            player.GetComponent<PlayerStats>().coinG = 0;
        }
        if(S == Shop.coinType.coinH){
            coinH += player.GetComponent<PlayerStats>().coinH;
            player.GetComponent<PlayerStats>().coinH = 0;
        }
    }
    public void withdraw(){
        if(coinA > 0){
            player.GetComponent<PlayerStats>().coinA += coinA;
            coinA = 0;
        }
        if(coinB > 0){
            player.GetComponent<PlayerStats>().coinB += coinB;
            coinB = 0;
        }
        if(coinC > 0){
            player.GetComponent<PlayerStats>().coinC += coinC;
            coinC = 0;
        }
        if(coinD > 0){
            player.GetComponent<PlayerStats>().coinD += coinD;
            coinD = 0;
        }
        if(coinE > 0){
            player.GetComponent<PlayerStats>().coinE += coinE;
            coinE = 0;
        }
        if(coinF > 0){
            player.GetComponent<PlayerStats>().coinF += coinF;
            coinF = 0;
        }
        if(coinG > 0){
            player.GetComponent<PlayerStats>().coinG += coinG;
            coinG = 0;
        }
        if(coinH > 0){
            player.GetComponent<PlayerStats>().coinH += coinH;
            coinH = 0;
        }
    }

    DialogueManager dialogueManager;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dialogueManager = bankLayer.transform.gameObject.GetComponentInParent<DialogueManager>();
        coinIcon.texture = dialogueManager.CurrencyEnumtoTexture(S);
        vals = new int[values.Length];
    }

    // Update is called once per frame
    void Update()
    {
            for (int i = 0; i < values.Length; i++)
            {
                vals[0] = coinA;
                vals[1] = coinB;
                vals[2] = coinC;
                vals[3] = coinD;
                vals[4] = coinE;
                vals[5] = coinF;
                vals[6] = coinG;
                vals[7] = coinH;
                values[i].GetComponent<Text>().text = "x" + vals[i].ToString();
            }

        
    }


}
