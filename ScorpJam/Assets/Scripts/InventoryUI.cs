using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    PlayerStats stats;
    [SerializeField]
    public GameObject[] values;//ui elements
    int[] vals;
    
    void Start()
    {
        vals = new int[values.Length];
    }

    
    void Update()
    {
        for (int i = 0; i < values.Length; i++) {
            vals[0] = stats.coinA;
            vals[1] = stats.coinB;
            vals[2] = stats.coinC;
            vals[3] = stats.coinD;
            vals[4] = stats.coinE;
            vals[5] = stats.coinF;
            vals[6] = stats.coinG;
            vals[7] = stats.coinH;
            values[i].GetComponent<Text>().text ="x"+vals[i].ToString();
        }
       
    }
}
