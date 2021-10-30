using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingCowboyCatcher : MonoBehaviour
{
    [SerializeField]
    GameObject finalCowboy;
    [SerializeField]
    GameObject finalGun;
    [SerializeField]
    Transform gunspawn;
    void spawnGun(){
        Instantiate(finalGun, gunspawn.transform.position, Quaternion.identity);
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "walkin"){
            Instantiate(finalCowboy, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Invoke("spawnGun", .5f);
            

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per fram
}
