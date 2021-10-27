using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("True for withdraw false for deposit")]
    bool withDraworDeposit;
    // Start is called before the first frame update
    public void interact(){
        if(withDraworDeposit){
            gameObject.transform.parent.gameObject.GetComponent<Bank>().withdraw();
        }
        else{
            gameObject.transform.parent.gameObject.GetComponent<Bank>().deposit();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
