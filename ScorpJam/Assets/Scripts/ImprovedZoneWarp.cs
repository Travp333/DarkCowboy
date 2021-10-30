using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedZoneWarp : MonoBehaviour
{
    GameObject dummy;
    [SerializeField]
    float warpOffset;

    public void forceShift(){
        transform.position = dummy.transform.position;
    }

    void Update()
    {

        //dummy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - warpOffset);

        dummy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + warpOffset);
    }
}