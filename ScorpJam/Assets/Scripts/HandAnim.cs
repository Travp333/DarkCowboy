using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnim : MonoBehaviour
{
    MovementSpeedController speedController;
    [SerializeField]
    GameObject sphere;
    FPSMovingSphere player;
    [HideInInspector]
    bool flipflop = true;
    bool flipflop2 = true;
    bool blocker = true;
    float charge;
    Animator animator;
    float playerSpeed;
    float playerSpeed2;
    float tempSpeed;
    float tempSpeed2;

    bool isOnGround;
    bool isOnSteep;

    [HideInInspector]
    public bool isOnGroundADJ;

    [SerializeField]
    [Tooltip("how long you need to be in the air before the 'onGround' bool triggers")]
    float OnGroundBuffer = .5f;
    float Groundstopwatch = 0;
    bool JumpPressed;
    Grab grab;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
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
            if(playerSpeed >= 15f){
                animator.SetFloat("Blend", 1f);
            }
            else {
                playerSpeed2 = playerSpeed / 15f;
                animator.SetFloat("Blend", playerSpeed2);

                if(playerSpeed >= 10f){
                    animator.SetFloat("walkBlend", 1f);
                }
                if (playerSpeed < .001f){
                    animator.SetFloat("walkBlend", 0f);
                }
                playerSpeed = playerSpeed / 10f;
                animator.SetFloat("walkBlend", playerSpeed);
            }
        }
        if ( Input.GetKeyDown("mouse 0") ){
            if(blocker && !grab.isHolding){
                if(flipflop){
                    Invoke("waveStartL", .1f);
                }
                else if (!flipflop){
                    Invoke("waveStartR", .1f);
                }
            }
        }
    }
}
