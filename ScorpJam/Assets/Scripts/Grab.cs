using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    MovementSpeedController speedController;
    //renda.material.Lerp(renda.material, shadow, .5f);
    Material mat;
    [SerializeField]
    float distance;
    [SerializeField]
    [Tooltip("what objects can be picked up by the player")]

    LayerMask mask = default;

    [SerializeField]
    Transform dummy;
    [SerializeField]
    [Tooltip("where the throwing force originates from")]

    GameObject origin;
    Transform prop;
    Rigidbody propRB;
    CustomGravityRigidbody body;
    Renderer renda;
    [HideInInspector]
    public bool isHolding = false;
    [SerializeField]
    float throwingforce = 5;
    HandAnim hand;
    FPSMovingSphere player;
    disableDynamicBone bone;
    [Tooltip("the point that a fully charged throw will head toward")]

    [SerializeField]
    Transform LowthrowingPoint;
    [SerializeField]
    [Tooltip("the point that a light toss will head toward")]

    Transform HighthrowingPoint;
    GameObject[] balls;
    int ballLength;
    [SerializeField]
    bool highorLow = true;
    float throwingTemp;
    [SerializeField]
    [Tooltip("the heaviest possible object the player can pick up")]

    float strength;
    
    [SerializeField]
    [Tooltip("the maximum force the player can throw an object at, when fully charged")]
    float maxThrowingForce;
    
    [SerializeField]
    [Tooltip("the rate at which the players throw charges")]
    float chargeRate;
    public bool isgrabCharging = false;
    
    public string SmallMediumLarge = "NULL";

    PlayerStats stats;

    DialogueNPC NPC =null;
    public DialogueManager dialogueManager;

    void Start() {
        stats = transform.root.GetComponent<PlayerStats>();
        throwingTemp = throwingforce;
        // fill list with all gameobjects tagged "bball"
        balls = GameObject.FindGameObjectsWithTag("bball");
        // get a reference to the player's moving component
        player = transform.root.GetComponent<FPSMovingSphere>();
        speedController = transform.root.GetComponent<MovementSpeedController>();
        // get a reference to the players animation controller
        hand = GetComponent<HandAnim>();
        //get a reference to the players disable dynamic bones script
        bone = GetComponent<disableDynamicBone>();
    }

    void setisThrowingFalse(){
        hand.setisThrowing(false);
    }


    void detach(){
        
        if( SmallMediumLarge == "MEDIUM"){
            speedController.setFactor(2f);
        }
        else if (SmallMediumLarge == "LARGE"){
            speedController.setFactor(5f);
        }
        SmallMediumLarge = "NULL";
    
        //opposite of the pick up section, just undoing all of that back to its default state
        isgrabCharging = false;
        bone.toggle(false);
        hand.setisHolding(false);
        dummy.GetChild(5).SetParent(null);
       // body = prop.gameObject.GetComponent<CustomGravityRigidbody>();
       // body.enabled = true;
        propRB.isKinematic=(false);
        isHolding = false;
        //this may not be super smart, but i am assuming everything you pick up is labeled as a rigid body. If that changes, this should be updated
        prop.transform.gameObject.layer = 13;
        foreach ( Transform child in prop.transform){
            child.transform.gameObject.layer = 13;
            foreach ( Transform child2 in child.transform){
                child2.transform.gameObject.layer = 13;
            }
        }


    }

    void debugLog(){
        Debug.Log("trick or treater on cooldown");
    }
    void debugOOM(){
        Debug.Log("Out of Money!");
    }


    void Aseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinB){
                if(stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinB = stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinA = stats.coinA +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinC){
                    if(stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinC = stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinA = stats.coinA +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinD){
                    if(stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinD = stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinA = stats.coinA +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinE){
                    if(stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinE = stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinA = stats.coinA +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinF){
                    if(stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinF = stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinA = stats.coinA +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinG){
                    if(stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinG = stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinA = stats.coinA +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinH){
                    if(stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinH = stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinA = stats.coinA +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                        
                    
    }

    void Bseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinA){
                if(stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinA = stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinB = stats.coinB +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinC){
                    if(stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinC = stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinB = stats.coinB +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinD){
                    if(stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinD = stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinB = stats.coinB +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinE){
                    if(stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinE = stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinB = stats.coinB +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }   
                    else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinF){
                    if(stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinF = stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinB = stats.coinB +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinG){
                    if(stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinG = stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinB = stats.coinB +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinH){
                    if(stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinH = stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinB = stats.coinB +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }      
                    
    }

    void Cseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinB){
                if(stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinB = stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinC = stats.coinC +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinA){
                    if(stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinA = stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinC = stats.coinC +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinD){
                    if(stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinD = stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinC = stats.coinC +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinE){
                    if(stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinE = stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinC = stats.coinC +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                } 
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinF){
                    if(stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinF = stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinC = stats.coinC +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinG){
                    if(stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinG = stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinC = stats.coinC +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinH){
                    if(stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinH = stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinC = stats.coinC +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }        
                    
    }
    void Dseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinB){
                if(stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinB = stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinD = stats.coinD +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinA){
                    if(stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinA = stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinD = stats.coinD +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinC){
                    if(stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinC = stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinD = stats.coinD +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinE){
                    if(stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinE = stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinD = stats.coinD +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }  
                    else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinF){
                    if(stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinF = stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinD = stats.coinD +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinG){
                    if(stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinG = stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinD = stats.coinD +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinH){
                    if(stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinH = stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinD = stats.coinD +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }       
                    
    }
    void Eseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinB){
                if(stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinB = stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinE = stats.coinE +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinA){
                    if(stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinA = stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinE = stats.coinE +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinC){
                    if(stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinC = stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinE = stats.coinE +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinD){
                    if(stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinD = stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinE = stats.coinE +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }  
                    else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinF){
                    if(stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinF = stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinE = stats.coinE +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinG){
                    if(stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinG = stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinE = stats.coinE +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinH){
                    if(stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinH = stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinE = stats.coinE +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }                  
    }

    void Fseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinB){
                if(stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinB = stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinF = stats.coinF +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinA){
                    if(stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinA = stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinF = stats.coinF +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinC){
                    if(stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinC = stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinF = stats.coinF +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinD){
                    if(stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinD = stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinF = stats.coinF +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }  
                    else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinE){
                    if(stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinE = stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinF = stats.coinF +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinG){
                    if(stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinG = stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinF = stats.coinF +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinH){
                    if(stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinH = stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinF = stats.coinF +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }                  
    }
    void Gseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinB){
                if(stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinB = stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinG = stats.coinG +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinA){
                    if(stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinA = stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinG = stats.coinG +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinC){
                    if(stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinC = stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinG = stats.coinG +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinD){
                    if(stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinD = stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinG = stats.coinG +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }  
                    else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinF){
                    if(stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinF = stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinG = stats.coinG +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinE){
                    if(stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinE = stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinG = stats.coinG +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinH){
                    if(stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinH = stats.coinH - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinG = stats.coinG +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }                  
    }
    void Hseller(RaycastHit hit){
        if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinB){
                if(stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                    stats.coinB = stats.coinB - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                    stats.coinH = stats.coinH +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                }
                else{
                    debugOOM();
                    }
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinA){
                    if(stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinA = stats.coinA - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinH = stats.coinH +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }
                }       
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinC){
                    if(stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinC = stats.coinC - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinH = stats.coinH +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                      
                }   
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinD){
                    if(stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinD = stats.coinD - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinH = stats.coinH +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }  
                    else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinF){
                    if(stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinF = stats.coinF - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinH = stats.coinH +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinE){
                    if(stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinE = stats.coinE - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinH = stats.coinH +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }
                else if(hit.transform.gameObject.GetComponent<Shop>().buying == Shop.coinType.coinG){
                    if(stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount > 0){
                        stats.coinG = stats.coinG - hit.transform.gameObject.GetComponent<Shop>().takeAmount;
                        stats.coinH = stats.coinH +  hit.transform.gameObject.GetComponent<Shop>().giveAmount;
                    }
                    else{
                        debugOOM();
                    }                    
                }                  
    }


    void currencyInteraction(RaycastHit hit){
        //TREATORS ===============================================================================================================
        if(hit.transform.gameObject.GetComponent<Shop>().getTreatOrTrater()){
            int range = Random.Range(1,9);
            int range2 = Random.Range(1, 50);
            if(range == 1){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin A");
                    stats.coinA = stats.coinA + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }
            }
            else if(range == 2){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin B");
                    stats.coinB = stats.coinB + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }
            }
            else if(range == 3){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin C");
                    stats.coinC = stats.coinC + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }
            }
            else if(range == 4){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin D");
                    stats.coinD = stats.coinD + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }

            }
            else if(range == 5){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin E");
                    stats.coinE = stats.coinE + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }
            }
            else if(range == 6){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin F");
                    stats.coinF = stats.coinF + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }
            }
            else if(range == 7){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin G");
                    stats.coinG = stats.coinG + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }
            }
            else if(range == 8){
                if(hit.transform.gameObject.GetComponent<Shop>().cooldown == 0){
                    //Debug.Log("got" + range2 + " coin H");
                    stats.coinH = stats.coinH + range2;
                    hit.transform.gameObject.GetComponent<Shop>().cooldown = 5;
                }
            }
        }

        //TRADERS=================================================================================================================
        else if (!hit.transform.gameObject.GetComponent<Shop>().getTreatOrTrater()){
            //SELLING A =============================================================================================
             if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinA){
                 Aseller(hit);
             }
             //SELLING B =============================================================================================
             if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinB){
                 Bseller(hit);
             }
             //SELLING C =============================================================================================
             if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinC){
                 Cseller(hit);
             }
             //SELLING D =============================================================================================
             if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinD){
                 Dseller(hit);
             }
             //SELLING E =============================================================================================
             if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinE){
                 Eseller(hit);
             }
            if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinF){
                 Fseller(hit);
             }
             if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinG){
                 Gseller(hit);
             }
             if(hit.transform.gameObject.GetComponent<Shop>().selling == Shop.coinType.coinH){
                 Hseller(hit);
             }
        }
    }


    //(Physics.Raycast(origin.transform.position, (dummy.position - origin.transform.position), out hit, distance, mask)
    void Update()
    {   
        //keeps track of all the basketballs in the level
        if (GameObject.FindGameObjectsWithTag("bball").Length != ballLength){
            balls = GameObject.FindGameObjectsWithTag("bball");
            ballLength = balls.Length;
        }
        RaycastHit hit;
        if (Input.GetKeyDown("e"))
        {
            // if you are not holding anything, and you are not preparing to barrage, and you are not barraging
            if(!isHolding && !hand.barragePrep && !player.isBarraging){
                if (NPC)
                {
                    if (dialogueManager.NPCisTalking)
                    {
                        dialogueManager.DisplayNextSentence();
                        return;
                    }
                    if (!dialogueManager.NPCisTalking) {
                        NPC = null;
                    }
                }
                // send a raycast
                if (Physics.SphereCast(origin.transform.position, 1, (dummy.position - origin.transform.position), out hit, distance, mask))
                {
                    if(hit.transform.gameObject.GetComponent<Shop>() != null){
                        currencyInteraction(hit);
                    }
                    
                    if (hit.transform.gameObject.GetComponent<DialogueNPC>() != null)
                    {
                        NPC = hit.transform.gameObject.GetComponent<DialogueNPC>();
                        NPC.TriggerDialogue();
                        return;
                    }
                    
                    if (hit.transform.gameObject.GetComponent<Rigidbody>() != null){
                        if(hit.transform.gameObject.GetComponent<Rigidbody>().mass <= strength){
                            if(hit.transform.gameObject.GetComponent<objectSize>().isLarge && !hit.transform.gameObject.GetComponent<objectSize>().isMedium && !hit.transform.gameObject.GetComponent<objectSize>().isSmall){
                                SmallMediumLarge = "LARGE";
                                speedController.setFactor(0.2f);
                            }
                            if(hit.transform.gameObject.GetComponent<objectSize>().isMedium && !hit.transform.gameObject.GetComponent<objectSize>().isLarge && !hit.transform.gameObject.GetComponent<objectSize>().isSmall){
                                SmallMediumLarge = "MEDIUM";
                                speedController.setFactor(0.5f);
                            }
                            if(hit.transform.gameObject.GetComponent<objectSize>().isSmall && !hit.transform.gameObject.GetComponent<objectSize>().isLarge && !hit.transform.gameObject.GetComponent<objectSize>().isMedium){
                                SmallMediumLarge = "SMALL";
                                
                            }                        
                            //disable dynamic bones
                            bone.toggle(true);
                            //trigger animation
                            hand.setisHolding(true);
                            // create temp refrences
                            prop = hit.transform;
                            propRB = hit.rigidbody;
                            // move the hit object to the grab point
                            hit.transform.position = dummy.transform.position;
                            // set the hit object to be a child of the grab point
                            hit.transform.SetParent(dummy);
                            // get a reference to the custom gravity rigidbody to disable gravity and sleeping

                            //body = hit.transform.gameObject.GetComponent<CustomGravityRigidbody>();

                            //get a reference to the material, obsolete for now but this should be used to make held objects transparent
                            renda = prop.gameObject.GetComponent<Renderer>();
                            //body.enabled = false;

                            propRB.isKinematic=(true);
                            isHolding = true;
                            // set the held object to the "nocollidewithplayer" layer to prevent clipping with the player
                            prop.transform.gameObject.layer = 16;
                            // do the same for all children and childrens children 
                            foreach ( Transform child in prop.transform){
                                child.transform.gameObject.layer = 16;
                                foreach ( Transform child2 in child.transform){
                                    child2.transform.gameObject.layer = 16;
                                }
                            // find if you grabbed a basketball. If so, disable it's "thruHoop" status
                            }
                            foreach(GameObject b in balls){
                                if (b.gameObject == hit.transform.gameObject){
                                    b.gameObject.GetComponent<BBall>().setThruHoop(false);
                                    break;
                            }
                        }
                    }
                }
            }
        }
            // if you are already holding something, drop it. 
            else if (isHolding){
                detach();
                //clear the temps for next loop
                prop = null;
                propRB = null;
                throwingforce = throwingTemp;
            }

        }
        if (Input.GetKeyUp("mouse 0") && isHolding && !hand.barragePrep && !player.isBarraging ){
            
            detach();
            if (highorLow){
                propRB.AddForce((HighthrowingPoint.position - origin.transform.position ) * throwingforce, ForceMode.Impulse);
                //propRB.velocity = (HighthrowingPoint.position - origin.transform.position ) * throwingforce;
            }
            else{
                propRB.AddForce((LowthrowingPoint.position - origin.transform.position ) * throwingforce, ForceMode.Impulse);
                //propRB.velocity = (LowthrowingPoint.position - origin.transform.position ) * throwingforce;
            }
            //give it velocity in the direction of the throwing point to give it a slight upward angle
                
            // trigger animation
            hand.setisThrowing(true);
            //prepare to reset animation
            Invoke("setisThrowingFalse", .1f);
            throwingforce = throwingTemp;
            highorLow = true;
        }
        //throw
        if (Input.GetKey("mouse 0") && isHolding && !hand.barragePrep && !player.isBarraging ){
            if (throwingforce <= maxThrowingForce){
                isgrabCharging = true;
                throwingforce = throwingforce + chargeRate;
            }
            if (throwingforce > maxThrowingForce){
                isgrabCharging = false;
                highorLow = false;
            }
            //if you are holding something, throw it. 

        }


    }
}
