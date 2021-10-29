using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnZone : MonoBehaviour
{
    [SerializeField]
    GameObject point;
    void OnTriggerEnter(Collider other) {
        other.gameObject.transform.root.transform.position = point.transform.position;
    }

}
