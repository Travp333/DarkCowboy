using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableSurface : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    FPSMovingSphere sphere;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
           sphere.setCanClimb(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            sphere.setCanClimb(false);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sphere = player.GetComponent<FPSMovingSphere>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
