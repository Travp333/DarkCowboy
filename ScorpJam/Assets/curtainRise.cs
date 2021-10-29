using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curtainRise : MonoBehaviour
{
    bool blocker = true;
    float timer;
    [SerializeField]
    float rate = .5f;
    bool gate = true;

    public void setBlocker(bool plug){
        blocker = plug;
    }
    void Update()
    {
        if(!blocker){
            if(timer < 17){
                timer += Time.deltaTime;
                transform.position = new Vector3(transform.position.x, transform.position.y + (rate * Time.deltaTime), transform.position.z);
            }
            if(timer > 17){
                timer += Time.deltaTime;
                if(gate){
                    Destroy(gameObject);
                    gate = false;
                }
            }
        }
        }
    }
