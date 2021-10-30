using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsToggle : MonoBehaviour
{
    [SerializeField]
    GameObject[] coins;
    GameObject player;
    // Start is called before the first frame update

    public void toggleCoin(int i, bool plug){
        coins[i].gameObject.SetActive(plug);
        if(i == 0){
            Debug.Log("nuitmares");
            player.GetComponent<PlayerStats>().nightmares();
        }
        else if(i == 1){
            Debug.Log("hal;l;po");
            player.GetComponent<PlayerStats>().playHallo();
        }
        else if(i == 2){
            Debug.Log("LOUDO");
            player.GetComponent<PlayerStats>().playLoudo();
        }
        else if(i == 3){
            Debug.Log("glass");
            player.GetComponent<PlayerStats>().glassBreak();
        }
        else if (i == 6){
            player.GetComponent<PlayerStats>().playWetFood();
        }
        else player.GetComponent<PlayerStats>().playgetCoin();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
