using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorbappear : MonoBehaviour
{
    GameObject slideJam;
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
    public GameObject player;
    PlayerStats stats;
    GameObject cowboy;
    GameObject gun;
    GameObject swapManager;


    void Start() {
        slideJam = GameObject.FindGameObjectsWithTag("slideJam")[0];
        curtains = GameObject.FindGameObjectsWithTag("Curtains")[0];
        swapManager = GameObject.FindGameObjectsWithTag("swapManager")[0];
        stats = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>();
    }

    void slideJamma(){
        if(slideJam != null){
            slideJam.GetComponent<jamSlide>().movespeedSet();
        }
        else{
            slideJam = GameObject.FindGameObjectsWithTag("slideJam")[0];
            slideJamma();
        }
    }
    
    void statsBlocker(){
        stats.crowdBlocker = false;
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
                //player = GameObject.FindGameObjectsWithTag("Player")[0];
                //if(player != null){
                //    player.GetComponent<ZoneWarp>().forceWarp();
                //}
                //cowboy = GameObject.FindWithTag("DARKCOWBOY").gameObject;
                //if(cowboy != null){
                //    cowboy.gameObject.GetComponent<ZoneWarp>().forceWarp();
               // }
               // gun = GameObject.FindGameObjectsWithTag("thisonespecificgun")[0];
               // if (gun.gameObject != null)
               // {
              //      gun.gameObject.GetComponent<ZoneWarp>().forceWarp();
              //  }
              //  this.gameObject.GetComponent<ZoneWarp>().forceWarp();
                swapManager.GetComponent<worldSwapManager>().swap();
                GetComponent<Rigidbody>().isKinematic=(false);
                this.gameObject.layer = 13;
                gate2 = false;
                Invoke("statsBlocker", .1f);
                Invoke("slideJamma", 10f);
                
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

