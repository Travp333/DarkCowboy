using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopNPC : MonoBehaviour
{
    
    public ShopItems shopItems= default;

    public void TriggerVendor()
    {
        FindObjectOfType<DialogueManager>().StartVendor(shopItems);
        Debug.Log("Vendor Trigger");
        
    }
}
