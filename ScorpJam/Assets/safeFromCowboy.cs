using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeFromCowboy : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    // Start is called before the first frame update    
    void OnTriggerEnter(Collider other) {
        player.GetComponent<PlayerStats>().inSafeZone = true;
    }
    void OnTriggerExit(Collider other) {
        player.GetComponent<PlayerStats>().inSafeZone = false;
    }
}
