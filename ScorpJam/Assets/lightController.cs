using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    GameObject light1;
    GameObject light2;
    // Start is called before the first frame update
    void Start()
    {
        light1 = transform.GetChild(0).gameObject;
        light2 = transform.GetChild(1).gameObject;
    }

    public void lightSwap(){
        light1.gameObject.SetActive(true);
        light2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
