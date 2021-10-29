using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorbappear : MonoBehaviour
{
    GameObject slideJam;
    GameObject lightManager;
    GameObject curtains;
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

    [SerializeField]
    float curtainsOffset;
    PlayerStats stats;

    void Start() {
        slideJam = GameObject.FindWithTag("slideJam");
        lightManager = GameObject.FindWithTag("lightmanager");
        curtains = GameObject.FindWithTag("Curtains");
        stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }
    
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
        if(timer < 17){
            timer += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + (rate * Time.deltaTime), transform.position.z);
            curtains.transform.position = new Vector3(curtains.transform.position.x, curtains.transform.position.y + (curtainsOffset * rate * Time.deltaTime), curtains.transform.position.z);
            this.transform.Rotate(0, SpinSpeed * Time.deltaTime, 0);
        }
        if(timer > 17){
            timer += Time.deltaTime;
            if(gate2){
                GetComponent<Rigidbody>().isKinematic=(false);
                this.gameObject.layer = 13;
                gate2 = false;
                Destroy(curtains);
                stats.crowdBlocker = false;
                lightManager.GetComponent<lightController>().lightSwap();
                slideJam.GetComponent<jamSlide>().movespeedSet();
            }
        }
        if(timer > 65){
            if(gate){
                foreach(Transform t in scorbSpawns){
                    Instantiate(scorbs, t.transform.position, Quaternion.identity);
                } 
                gate = false;
            }
        }
        

        }
    }

