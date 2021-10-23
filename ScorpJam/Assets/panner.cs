using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panner : MonoBehaviour
{
    MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        rend.materials[1].mainTextureOffset = new Vector2(0f, 5f * Time.time);
    }
}
