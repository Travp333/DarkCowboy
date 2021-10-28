using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorbappear : MonoBehaviour
{
    [SerializeField]
    public GameObject scorbs;
    [SerializeField]
    Transform[] scorbSpawns;
    float timer;
    [SerializeField]
    float rate = .5f;
    [SerializeField]
    float SpinSpeed;
    bool gate = true;
    bool gate2 = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 17){
            timer += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + (rate * Time.deltaTime), transform.position.z);
            this.transform.Rotate(0, SpinSpeed * Time.deltaTime, 0);
        }
        if(timer > 17){
            timer += Time.deltaTime;
            if(gate2){
                GetComponent<Rigidbody>().isKinematic=(false);
                this.gameObject.layer = 13;
                gate2 = false;
            }
        }
        if(timer > 65){
            //if(gate){
                foreach(Transform t in scorbSpawns){
                    Instantiate(scorbs, t.transform.position, Quaternion.identity);
              //  } 
              //  gate = false;
            }
        }
        

        }
    }

