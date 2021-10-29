using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeCowboy : MonoBehaviour
{
    [SerializeField]
    GameObject cowboy;
    public bool gate = true;
    // Start is called before the first frame update
    public void triggered(Collider other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "DARKCOWBOY"){
            if(gate){
                followPlayer follow = cowboy.GetComponent<followPlayer>();
                if(follow.isDead){
                    follow.enableNavAgent();
            }
            Debug.Log("RESETTING BOSS PHASE");
            follow.resetPhase();
            gate = false;
            }
        }
    }
}
