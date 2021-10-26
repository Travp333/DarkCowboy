using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    [Tooltip("True = treatee, false = trader")]
    bool treateeOrTrader;
    [SerializeField]
    public enum coinType{coinA, coinB, coinC, coinD, coinE, coinF, coinG, coinH};
    public coinType selling;

    [SerializeField]
    public enum tradeType{coinA, coinB, coinC, coinD, coinE, coinF, coinG, coinH};
    public coinType buying;
    [HideInInspector]
    public float cooldown;
    [SerializeField]
    [Tooltip("basically this traders going trade rate")]
    public int takeAmount, giveAmount;
    AudioSource textNoise=default;

    public bool getTreatOrTrater(){
        return treateeOrTrader;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        textNoise = GetComponent<AudioSource>();
    }

    public void playTextSound(){
        textNoise.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if( cooldown > 0){
            cooldown -= UnityEngine.Time.deltaTime; 
        }
        if (cooldown <= 0){
            cooldown = 0;
        }
    }
}
