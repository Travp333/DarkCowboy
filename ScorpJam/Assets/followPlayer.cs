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

    //Phase1, default, low draw speed low accuracy
    //Phase 2, Higher draw speed, low accuracy
    //Phase 3, High Draw Speed High Accuracy
    //Phace 4, Highest DrawSpeed and fire rate, high accuracy. "FAN THE HAMMER"
    public enum PHASE{Phase1, Phase2, Phase3, Phase4};

    public PHASE bossPhase;

    RaycastHit hit;
    PlayerStats stats;
    [SerializeField]
    public GameObject safeSpace;
    bool takingDamage;
    float timer = 30f;
    bool vulnerable;
    
    Vector3 destination;
    Vector3 backup;
    private float elapsed = 0.0f;

    public void resetPhase(){
        bossPhase = PHASE.Phase1;
    }
    public void pauseAI(){
        agent.isStopped = true;
    }
    public void resumeAI(){
        agent.isStopped = false;
    }

    private NavMeshPath path;
    void playRandomPainNoise(){
        clips[Random.Range(4, 8)].Play();
    }
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
    void resetQuickShoot(){
        anim.SetBool("QuickShoot", false);  
    }

    void resetHammerFan(){
        anim.SetBool("HammerFan", false);  
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
    void resetTakingDamage(){
        anim.SetBool("TakingDamage", false);
    }
    void otherResetTakingDamage(){
        takingDamage = false;
    }

    public void cowboyDamage(){
        if(vulnerable){
            takingDamage = true;
            anim.SetBool("TakingDamage", true);
            Invoke("resetTakingDamage", .1f);
            Invoke("otherResetTakingDamage", 5f);
            timer = 0f;
            playRandomPainNoise();
        }
    }

    void SHOOT(){
        //Debug.Log(bossPhase);
        if (bossPhase == PHASE.Phase1 || bossPhase == PHASE.Phase2){
            //Debug.Log("FIRED A LOW ACCURACY SHOT");
            lite.GetComponent<Light>().enabled = true;
            Invoke("killLite", .1f);
            if(Physics.Raycast(gunorigin.transform.position, this.transform.forward, out hit, range, mask)){
                Instantiate(impact, hit.point, Quaternion.identity);
                if(hit.transform.gameObject.tag == "Breakable" || hit.transform.gameObject.tag == "Explosive" ){
                    hit.transform.gameObject.GetComponent<Shatter>().oneShot(0);
                }
                if(hit.transform.gameObject.tag == "Player"){
                    player.GetComponent<PlayerStats>().takeDamage(10);
                }
            }
        }
        if(bossPhase == PHASE.Phase4 || bossPhase == PHASE.Phase3){
            //Debug.Log("FIRED A HIGH ACCURACY SHOT");
            lite.GetComponent<Light>().enabled = true;
            Invoke("killLite", .1f);
            if(Physics.Raycast(gunorigin.transform.position, (player.transform.GetChild(2).position - gunorigin.transform.position), out hit, range, mask)){
                Instantiate(impact, hit.point, Quaternion.identity);
                if(hit.transform.gameObject.tag == "Breakable" || hit.transform.gameObject.tag == "Explosive" ){
                    hit.transform.gameObject.GetComponent<Shatter>().oneShot(0);
                }
                if(hit.transform.gameObject.tag == "Player"){
                    player.GetComponent<PlayerStats>().takeDamage(10);
                }
        }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    { 
        elapsed = 0.0f;
        path = new NavMeshPath();
        Invoke("openGate", 5f);
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        tempSpeed = agent.speed;
        stats = player.GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Update the way to the goal every second.
        if(!takingDamage && stats.location == false){
            elapsed += Time.deltaTime;
            if (elapsed > 1.0f)
            {
                elapsed -= 1.0f;
                NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, path);
            }
            agent.SetDestination(path.corners[path.corners.Length - 1]);
        }
        else if(takingDamage){
            //Debug.Log("Retreating!" + agent.hasPath);
            agent.SetDestination(safeSpace.transform.position);
            agent.stoppingDistance = 5;
            agent.isStopped = false;
        }
        else if(stats.location == true){
            agent.isStopped = true;
        }
        if(timer < 30){
            timer += Time.deltaTime;
            vulnerable = false;
        }
        else if(timer >= 30){
            timer = 30f;
            vulnerable = true;
        }
        


        if(stats.trickOrTreated == 0){
            bossPhase = PHASE.Phase1;
        }
        if(stats.trickOrTreated == 1){
            bossPhase = PHASE.Phase2;
        }
        if(stats.trickOrTreated == 3){
            bossPhase = PHASE.Phase3;
        }
        if(stats.trickOrTreated == 4){
            bossPhase = PHASE.Phase4;
        }
        if(agent.remainingDistance > 20){
            agent.speed = boostSpeed;
        }
        else if (agent.remainingDistance < 20){
            agent.speed = tempSpeed;
        }
        if(gate && agent.remainingDistance < 150 && !takingDamage && !player.GetComponent<PlayerStats>().inSafeZone){
            if(Physics.Raycast(this.transform.position, (player.transform.position-this.transform.position), out hit, range, mask)){
                if (hit.transform.gameObject.tag=="Player"){
                    if(bossPhase == PHASE.Phase1){
                        agent.isStopped = true;
                        anim.SetBool("Shoot", true);
                        Invoke("resetShoot", .1f);
                        agent.speed = 0;
                        gate = false;
                        Invoke("openGate", 5f);
                    }
                    else if (bossPhase == PHASE.Phase2 || bossPhase == PHASE.Phase3){
                        agent.isStopped = true;
                        anim.SetBool("QuickShoot", true);
                        Invoke("resetQuickShoot", .1f);
                        agent.speed = 0;
                        gate = false;
                        Invoke("openGate", 5f);
                    }
                    else if (bossPhase == PHASE.Phase4){
                        agent.isStopped = true;
                        anim.SetBool("HammerFan", true);
                        Invoke("resetHammerFan", .1f);
                        agent.speed = 0;
                        gate = false;
                        Invoke("openGate", 5f);
                    }
                }
            }
        }

        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        anim.SetFloat("velocity", agent.velocity.magnitude / boostSpeed);

    }
}
