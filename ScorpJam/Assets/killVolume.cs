using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.transform.root.gameObject.tag == "Player"){
            other.gameObject.transform.root.transform.GetComponent<PlayerStats>().die();
        }
    }
}
