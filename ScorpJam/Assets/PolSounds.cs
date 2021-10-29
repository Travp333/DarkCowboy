using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolSounds : MonoBehaviour
{
    [SerializeField]
    bool audienceMember = true;
    Animator anim;
    [SerializeField]
    public AudioSource[] cheerSounds;
    int range;
    int tempRange = 50;
    [SerializeField]
    public AudioSource[] polSound;
    float timer = 500;
    float timeRange;

    float timeRange2;
    float timer2 = 500;

    [SerializeField]
    bool shouldPlayNoise;

    PlayerStats stats;
    // Start is called before the first frame update
    void Start() {
        stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    public void playRandomPolSound(){
        if(shouldPlayNoise){
            range = Random.Range(1, 9);
            if(range != tempRange){
                polSound[range].Play();
                tempRange = range;
            }
            else {
                playRandomPolSound();
            }
        }
    }

    void wakeUP(){
        stats.crowdBlocker = false;
    }

    public void playRandomCheerSound(){
        range = Random.Range(0, (cheerSounds.Length - 1));
        if(range != tempRange){
            //Debug.Log(range);
            cheerSounds[range].Play();
            tempRange = range;
        }
        else {
            playRandomCheerSound();
        }
    }
    public void whichAnim(){
        float range = Random.Range(0, 4);
        if(range == 0){
        anim.SetBool("isDancing", true);
        anim.SetBool("isClapping", false);
        anim.SetBool("isFlipping", false);
        anim.SetBool("isCheering", false);
        }
        if(range == 1){
        anim.SetBool("isClapping", true); 
        anim.SetBool("isDancing", false);
        anim.SetBool("isFlipping", false);
        anim.SetBool("isCheering", false);
        }
        if(range == 2){
        anim.SetBool("isFlipping", true);
        anim.SetBool("isDancing", false);
        anim.SetBool("isClapping", false);
        anim.SetBool("isCheering", false);
        }
        if(range == 3){
        anim.SetBool("isCheering", true);
        anim.SetBool("isDancing", false);
        anim.SetBool("isClapping", false);
        anim.SetBool("isFlipping", false);
        }

    }


    void Update(){
        if(!stats.crowdBlocker && audienceMember){
            timeRange = Random.Range(1,10);
            if (timer > timeRange){
                timer = 0;
                playRandomCheerSound();
                
            }
            else{
                timer += Time.deltaTime;
            }
            timeRange2 = Random.Range(5,10);
            if (timer2 > timeRange2){
                whichAnim();
                timer2 = 0;
            }
            else{
                timer2 += Time.deltaTime;
            }
        }
    }


}
