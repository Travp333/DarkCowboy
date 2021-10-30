using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jamSlide : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    // Start is called before the first frame update

    public void movespeedSet(){
        agent.speed = .5f;
    }
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, path);
            if(path.corners.Length > 1 ){
            agent.SetDestination(path.corners[path.corners.Length - 1]);
            }
            else {
                return;
            }
        }
         
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime); 
    }
}
