using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    //currently the way this is set up is that you can only deposit or withdraw one type of coin at a time.
    //
    
    [SerializeField]
    public enum storing{coinA, coinB, coinC, coinD, coinE, coinF, coinG, coinH};
    public storing S;
    GameObject player;
    int coinA,coinB,coinC,coinD,coinE,coinF,coinG,coinH;
    // Start is called before the first frame update
    public void switchCoin(){
        S = (storing)Random.Range(0, System.Enum.GetValues(typeof(storing)).Length);
    }
    public void deposit(){
        if(S == storing.coinA){
            coinA += player.GetComponent<PlayerStats>().coinA;
            player.GetComponent<PlayerStats>().coinA = 0;
        }
        if(S == storing.coinB){
            coinB += player.GetComponent<PlayerStats>().coinB;
            player.GetComponent<PlayerStats>().coinB = 0;
        }
        if(S == storing.coinC){
            coinC += player.GetComponent<PlayerStats>().coinC;
            player.GetComponent<PlayerStats>().coinC = 0;
        }
        if(S == storing.coinD){
            coinD += player.GetComponent<PlayerStats>().coinD;
            player.GetComponent<PlayerStats>().coinD = 0;
        }
        if(S == storing.coinE){
            coinE += player.GetComponent<PlayerStats>().coinE;
            player.GetComponent<PlayerStats>().coinE = 0;
        }
        if(S == storing.coinF){
            coinF += player.GetComponent<PlayerStats>().coinF;
            player.GetComponent<PlayerStats>().coinF = 0;
        }
        if(S == storing.coinG){
            coinG += player.GetComponent<PlayerStats>().coinG;
            player.GetComponent<PlayerStats>().coinG = 0;
        }
        if(S == storing.coinH){
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


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
