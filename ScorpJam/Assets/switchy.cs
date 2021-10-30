using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchy : MonoBehaviour
{
    [SerializeField]
    GameObject fanManager;
    public void interact(){
        fanManager.GetComponent<fanManager>().killFans();
    }

}
