using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorbappear : MonoBehaviour
{
    float timer;
    [SerializeField]
    float rate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 15){
            timer += Time.deltaTime;
            transform.Translate(transform.position.x, transform.position.y * rate * Time.deltaTime, transform.position.z);
        }
        if(timer > 15){
            GetComponent<Rigidbody>().isKinematic=(false);
        }
    }
}
