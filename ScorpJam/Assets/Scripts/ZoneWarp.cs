using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWarp : MonoBehaviour
{
    [SerializeField]
    float warpOffset;
    bool flipflop = true;

    public void forceWarp(){

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + warpOffset );
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - warpOffset );
            }

}
