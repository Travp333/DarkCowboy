using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSwapManager : MonoBehaviour
{
    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject swapTo;
    // Start is called before the first frame update
    public void swap(){
        start.gameObject.SetActive(false);
        swapTo.gameObject.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
