using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.transform.GetComponent<PlayerStats>().die();
        }
    }
}
