using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolSounds : MonoBehaviour
{
    int range;
    int tempRange = 50;
    [SerializeField]
    public AudioSource[] polSound;
    // Start is called before the first frame update
    public void playRandomPolSound(){
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
