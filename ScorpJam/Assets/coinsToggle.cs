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
        if ( i == 6){
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
