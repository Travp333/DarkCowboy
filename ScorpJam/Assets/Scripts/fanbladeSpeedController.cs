using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanbladeSpeedController : MonoBehaviour
{
    Animator anim;
    AccelerationZone zone;
    [SerializeField]
    float bladeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        zone = transform.GetChild(0).GetComponent<AccelerationZone>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("bladeSpeed", bladeSpeed);
    }
}
