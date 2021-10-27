using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsToggle : MonoBehaviour
{
    [SerializeField]
    GameObject[] coins;
    // Start is called before the first frame update

    public void toggleCoin(int i, bool plug){
        coins[i].gameObject.SetActive(plug);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
