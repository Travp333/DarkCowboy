using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stillShittin : MonoBehaviour
{
    [SerializeField]
    AudioSource fart;
    [SerializeField]
    AudioSource shittin;
    public bool fartBlock;
    public bool shittinBlock = true;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            if(!fartBlock){
                playFart();
                fartBlock = true;
            }
            if(!shittinBlock){
                playShittin();
                shittinBlock = true;
            }
            
        }
    }
    void playFart(){
        fart.Play();
    }
    void playShittin(){
        shittin.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
