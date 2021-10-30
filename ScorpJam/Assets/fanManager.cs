using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] fans;  
    [SerializeField]
    AudioSource sound;
    public void killFans(){
        foreach (GameObject G in fans){
            G.GetComponent<fanbladeSpeedController>().bladeSpeed = 0f;
            G.transform.GetChild(0).gameObject.SetActive(false);
            G.transform.GetChild(0).gameObject.SetActive(false);
            sound.Stop();

        }
    }
}
