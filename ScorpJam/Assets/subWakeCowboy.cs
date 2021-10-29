using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subWakeCowboy : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        this.transform.parent.GetComponent<wakeCowboy>().triggered(other);
    }
    // Start is called before the first frame update
}
