using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{  
    [SerializeField]
    AudioSource[] coinss;
    [SerializeField]
    AudioSource joined;
    [SerializeField]
    AudioSource coinGet;
    [SerializeField]
    AudioSource wetFood;
    [SerializeField]
    public GameObject cowboyVolumes;
    [SerializeField]
    public bool hasGun;
    [SerializeField]
    public bool hasColdShoe;
    [SerializeField]
    public bool hasJumpBoost;
    [SerializeField]
    public AudioSource track1;
    [SerializeField]
    public AudioSource track2;
    [SerializeField] 
    public AudioSource track3;
    [SerializeField]
    public GameObject blocker;
    [SerializeField]
    [Tooltip("true for market, false for street")]
    public bool location;
    [SerializeField]
    public int trickOrTreated;
    [SerializeField]
    public float hunger = 100;
    [SerializeField]
    public float maxHp = 100f;
    [SerializeField]
    public float hp = 100;
    [SerializeField, Min(0)]
    public int coinA,coinB,coinC,coinD,coinE,coinF,coinG,coinH;
    [SerializeField]
    AudioSource[] painSounds;
    int range;
    public bool inSafeZone;
    [SerializeField]
    GameObject gun;
    [SerializeField]

    public void playJoined(){
        joined.Play();
    }
    public bool crowdBlocker = true;
    //private void Update() {
        //Debug.Log(trickOrTreated);
    //}]
    public void playgetCoin(){
        coinGet.Play();
    }
    public void playWetFood(){
        wetFood.Play();
    }
    public void playLoudo(){
        coinss[0].Play();
    }
    public void playHallo(){
        coinss[2].Play();
    }
    public void glassBreak(){
        coinss[1].Play();
        
    }
    public void nightmares(){
        coinss[3].Play();
    }
    public void dropGun(){
        hasGun = false;
        GameObject var;
        var = Instantiate(gun, this.transform.GetChild(0).transform.GetChild(0).transform.position, Quaternion.identity);
        var.GetComponent<Rigidbody>().AddForce(this.transform.GetChild(0).transform.GetChild(0).transform.forward * 10f , ForceMode.Impulse);

    }
    public void getGun(){
        hasGun = true;
    }
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
        //this is making the player lose coins as a penalty for death, unecc
        /*coinA -= coinA/2;
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
        */
        }

    }

