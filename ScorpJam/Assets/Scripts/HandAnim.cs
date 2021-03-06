using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnim : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    [SerializeField]
    AudioSource putOnHatNoise;
    [SerializeField]
    GameObject hat;
    [SerializeField]
    public bool holdingHat;
    [SerializeField]
    AudioSource gunShot;
    [SerializeField]
    GameObject cowboy;
    [SerializeField]
    GameObject lite;
    [SerializeField]
    GameObject gun;
    MovementSpeedController speedController;
    [SerializeField]
    GameObject sphere;
    FPSMovingSphere player;
    [HideInInspector]
    bool flipflop = true;
    //bool flipflop2 = true;
    bool blocker = true;
    float charge;
    Animator animator;
    float playerSpeed;
    float playerSpeed2;
    float tempSpeed;
    float tempSpeed2;

    bool isOnGround;
    bool isOnSteep;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject impact;
    [SerializeField]

    [HideInInspector]
    public bool isOnGroundADJ;

    [SerializeField]
    [Tooltip("how long you need to be in the air before the 'onGround' bool triggers")]
    float OnGroundBuffer = .5f;
    float Groundstopwatch = 0;
    bool JumpPressed;
    Grab grab;

    bool endHatDialogue;
    bool UIblocked;
    // Start is called before the first frame update
    public void setEndHatDialogue(bool plug){
        endHatDialogue = plug;
    }
    public void setAnimEndHatDialogue(){
        animator.SetBool("endHatDialogue", true);
    }
    public bool getUIBlocked(){
        return UIblocked;
    }
    public void setUIblocked(bool plug){
        UIblocked = plug;
    }
    public bool getisThrowing(){
        return animator.GetBool("isThrowing");
    }
    public void setisHolding(bool plug){
        animator.SetBool("isHolding", plug);
    }
    public bool getisHolding(){
        return animator.GetBool("isHolding");
    }
    public void setisThrowing(bool plug){
        animator.SetBool("grabCharge", !plug);
        animator.SetBool("isThrowing", plug);
    }



    void BoolAdjuster(){
        isOnGround = player.OnGround;
        isOnSteep = player.OnSteep;
        if (!isOnGround && !JumpPressed){
            Groundstopwatch += Time.deltaTime;
            if (Groundstopwatch >= OnGroundBuffer){
                isOnGroundADJ = false;
            }
        }
        if (!isOnGround && JumpPressed){
            isOnGroundADJ = false;
        }
        if(isOnGround){
            Groundstopwatch = 0;
            isOnGroundADJ = true;
        }
    }
    void Start()
    {
        speedController = sphere.GetComponent<MovementSpeedController>();
        animator = GetComponent<Animator>();
        player = sphere.GetComponent<FPSMovingSphere>();
        grab = GetComponent<Grab>();
    }

    void openGate(){
        blocker = true;
    }
    void closeGate(){
        blocker = true;
    }

    void waveStartL(){
        blocker = false;
        flipflop = !flipflop;
        animator.SetBool("isPunchingLeft", true);
        Invoke("waveStop", .1f);
    }
    void waveStartR(){
        blocker = false;
        flipflop = !flipflop;
        animator.SetBool("isPunchingRight", true);
        Invoke("waveStop", .1f);

    }
    void waveStop(){
        
        animator.SetBool("isPunchingLeft", false);
        animator.SetBool("isPunchingRight", false);
        blocker = true;
       
    }

    void resetLite(){
        lite.SetActive(false);
    }
    void resetisShooting(){
        animator.SetBool("isShooting", false);
    }
    void Shoot(){
        gunShot.Play();
        lite.SetActive(true);
        Invoke("resetLite", .1f);
        animator.SetBool("isShooting", true);
        Invoke("resetisShooting", .2f);
        RaycastHit hit;
        if(Physics.Raycast(gun.transform.GetChild(0).transform.position, -this.transform.forward, out hit, 500, mask)){
            Debug.Log("hit something");
            Instantiate(impact, hit.point, Quaternion.identity);
            Debug.DrawRay(gun.transform.GetChild(0).transform.position, -this.transform.forward * 500, Color.green, 5f);
            if(hit.transform.gameObject.tag == "Explosive" ){
                hit.transform.gameObject.GetComponent<Shatter>().oneShot(0);
            }
            if(hit.transform.gameObject.tag == "DARKCOWBOY"){
                hit.transform.gameObject.GetComponent<followPlayer>().takeDamage(10);
                player.gameObject.GetComponent<PlayerStats>().dropGun();
            }
            else if(hit.transform.gameObject.GetComponent<Rigidbody>() != null){
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce((hit.transform.position - transform.position).normalized * 100, ForceMode.Impulse);
            }
        }
    }

    void showCowboyHat(){
        hat.gameObject.SetActive(true);
    }

    void hideCowboyHat(){
        //Debug.Log("REMOVED HAT");
        hat.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void putOnHat(){
        endHatDialogue = true;
        hideCowboyHat();
        setUIblocked(false);
        putOnHatNoise.Play();
        animator.SetBool("holdingHat", false);
        holdingHat = false;
        //animator.SetBool("endHatDialogue", true);
        Destroy(door.gameObject);
        //Invoke("resetEndHatDialogue", .1f);
    }
    // Update is called once per frame

    void resetEndHatDialogue(){
        //animator.SetBool("endHatDialogue", false);
    }
    void Update()
    {
        //if(endHatDialogue){
            //Debug.Log("Ended conversation with self");
        //    animator.SetBool("endHatDialogue", true);
        //    Invoke("resetEndHatDialogue", .1f);
       //     endHatDialogue = false;
        //    setUIblocked(false);
       // }
        //REMEMEBR TO TURN OFF UI BLOCKED (imma try to do in in the anim)
        if(holdingHat){
            Invoke("showCowboyHat", .1f);
            setUIblocked(true);
            animator.SetBool("holdingHat", true);
        }
        if(player.gameObject.GetComponent<PlayerStats>().hasGun){
            animator.SetLayerWeight(1, .37f);
            gun.SetActive(true);
        }
        else{
            animator.SetLayerWeight(1, 1f);
            gun.SetActive(false);
        }

        if(player.dancing){
            animator.SetBool("isDancing", true);
        }
        else{
            animator.SetBool("isDancing", false);
        }
        if(grab.isgrabCharging){
            animator.SetBool("grabCharge", true);
        }
        else if (!grab.isgrabCharging){
            animator.SetBool("grabCharge", false);
        }
        BoolAdjuster();
        bool JumpPressed = Input.GetKey("space");
        isOnGround = isOnGroundADJ;

        if(isOnGround){
            animator.SetBool("isOnGround", true);
        }
        else if (!isOnGround){
            animator.SetBool("isOnGround", false);
        }

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") ){
            animator.SetBool("isMoving", true);
        }
        else{
            animator.SetBool("isMoving", false);
        }
        if (Input.GetKey("left shift")){
            animator.SetBool("isSprinting", true);
        }
        else {
            animator.SetBool("isSprinting", false);
        }
        if (Input.GetKey("c")){
            animator.SetBool("walkPressed", true);
        }
        else {
            animator.SetBool("walkPressed", false);
        }

        playerSpeed = sphere.GetComponent<Rigidbody>().velocity.magnitude;
        if (playerSpeed < .001f){
            animator.SetFloat("Blend", 0f);
        }
        else{
            if(playerSpeed >= 10f){
                animator.SetFloat("Blend", 1f);
            }
            else {
                playerSpeed2 = playerSpeed / 10f;
                animator.SetFloat("Blend", playerSpeed2);

                if(playerSpeed >= 10f){
                    animator.SetFloat("walkBlend", 1f);
                }
                if (playerSpeed < .001f){
                    animator.SetFloat("walkBlend", 0f);
                }
                playerSpeed = playerSpeed / 5f;
                animator.SetFloat("walkBlend", playerSpeed);
            }
        }
        if ( Input.GetKeyDown("mouse 0") ){
            if(blocker && !grab.isHolding && !player.gameObject.GetComponent<PlayerStats>().hasGun && !UIblocked){
                if(flipflop){
                    Invoke("waveStartL", .1f);
                }
                else if (!flipflop){
                    Invoke("waveStartR", .1f);
                }
            }
            else if (player.gameObject.GetComponent<PlayerStats>().hasGun){
                Shoot();
            }
        }
    }
}
