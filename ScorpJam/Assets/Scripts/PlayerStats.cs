using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{  
    public float hunger = 100;
    public float hp = 100;
    [SerializeField, Min(0)]
    int coinA,coinB,coinC,coinD,coinE;

}
