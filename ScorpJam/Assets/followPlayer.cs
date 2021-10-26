using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField]
    float boostSpeed;
    float tempSpeed;
    Animator anim;
    [SerializeField]
    AudioSource[] clips;
    bool gate = false;
    [SerializeField]
    float range;
    [SerializeField]
    GameObject impact;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject gunorigin;
    [SerializeField]
    Light lite;
    [SerializeField]
    enum PHASE{Phase1, Phase2, Phase3, Phase4};


    void playEagleNoise(){
        clips[3].Play();
    }
    void playDrawNoise(){
        clips[2].Play();
    }
    void playGunNoise(){
        clips[1].Play();
    }
    void playDingNoise(){
        clips[0].Play();
    }

    void resetShoot(){
        anim.SetBool("Shoot", false);
        
    }

    void resetSpeed(){
        agent.speed = tempSpeed;
        agent.isStopped = false;
    }
    void openGate(){
        gate = true;
    }
    void killLite(){
        lite.GetComponent<Light>().enabled = false;
    }

    void SHOOT(){
        lite.GetComponent<Light>().enabled = true;
        Invoke("killLite", .1f);
        RaycastHit hit;
        if(Physics.Raycast(gunorigin.transform.position, this.transform.forward, out hit, range, mask)){
            Instantiate(impact, hit.point, Quaternion.identity);
            if(hit.transform.gameObject.tag == "Breakable" || hit.transform.gameObject.tag == "Explosive" ){
                hit.transform.gameObject.GetComponent<Shatter>().oneShot(0);
            }
            if(hit.transform.gameObject.tag == "Player"){
                player.GetComponent<PlayerStats>().hp -= 10;
            }
        }
    }

    
    // Start is called before the first frame update
    void Start()
    { 
        Invoke("openGate", 5f);
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        tempSpeed = agent.speed;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        if(agent.remainingDistance > 20){
            Debug.Log("Getting SpeedBoost!");
            agent.speed = boostSpeed;
        }
        else if (agent.remainingDistance < 20){
            Debug.Log("resetting to default");
            agent.speed = tempSpeed;
        }
        if(agent.velocity.magnitude == 0 && gate){
            agent.isStopped = true;
            anim.SetBool("Shoot", true);
            Invoke("resetShoot", .1f);
            agent.speed = 0;
            gate = false;
            Invoke("openGate", 5f);
            
        }

        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        anim.SetFloat("velocity", agent.velocity.magnitude / boostSpeed);

    }
}
