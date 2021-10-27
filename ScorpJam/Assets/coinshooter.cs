using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinshooter : MonoBehaviour
{

    [SerializeField]
    GameObject[] coins;
    int range;
    [SerializeField]
    GameObject player;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= .5f){
            GameObject clone;
            range = Random.Range(1, coins.Length);
            clone = Instantiate(coins[range], this.transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce((player.transform.position - this.transform.position)+ this.transform.up * 50f, ForceMode.Impulse);
            timer = 0;
        }
        else if (timer < 1){
            timer += Time.deltaTime;
        }
        
    }
}
