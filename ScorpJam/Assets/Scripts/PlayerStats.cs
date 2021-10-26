using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{  
    public float hunger = 100;
    public float hp = 100;
    [SerializeField, Min(0)]
    public int coinA,coinB,coinC,coinD,coinE,coinF,coinG,coinH;
    [SerializeField]
    AudioSource[] painSounds;
    int range;

    public void takeDamage(int amount){
        if(hp - amount <=0){
            //dead
            hp = 0;
        }
        else{
            hp-=amount;
            range = Random.Range(1, 6);
            painSounds[range].Play();
        }
    }
    

}
