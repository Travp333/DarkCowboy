using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{  
    [SerializeField]
    [Tooltip("true for market, false for street")]
    public bool location;
    public int trickOrTreated;
    public float hunger = 100;
    public float hp = 100;
    [SerializeField, Min(0)]
    public int coinA,coinB,coinC,coinD,coinE,coinF,coinG,coinH;
    [SerializeField]
    AudioSource[] painSounds;
    int range;
    public bool inSafeZone;
    //private void Update() {
        //Debug.Log(trickOrTreated);
    //}
    public void takeDamage(int amount){
        if(hp - amount <=0){
            die();
        }
        else{
            hp-=amount;
            range = Random.Range(1, 6);
            painSounds[range].Play();
        }
    }
    public void die(){
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Grab>().teleportToMarket();
        hp = 45;
        coinA -= coinA/2;
        coinB -= coinB/2;
        coinC -= coinC/2;
        coinD -= coinD/2;
        coinE -= coinE/2;
        coinF -= coinF/2;
        coinG -= coinG/2;
        coinH -= coinH/2;
        if(coinA < 0 ) coinA = 0;
        if(coinB < 0 ) coinB = 0;
        if(coinC < 0 ) coinC = 0;
        if(coinD < 0 ) coinD = 0;
        if(coinE < 0 ) coinE = 0;
        if(coinF < 0 ) coinF = 0;
        if(coinG < 0 ) coinG = 0;
        if(coinH < 0 ) coinH = 0;

        }

    }

