using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPhaseUI : MonoBehaviour
{
    [SerializeField]
    public RawImage PhaseTexture;
    [SerializeField]
    public Texture[] phase;
    [SerializeField]
    public GameObject cowboy;
    followPlayer.PHASE currentPhase;
    
    // Start is called before the first frame update
    void Start()
    {
        currentPhase = cowboy.GetComponent<followPlayer>().bossPhase;
        PhaseTexture = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPhase = cowboy.GetComponent<followPlayer>().bossPhase;
        PhaseTexture.texture = phase[(int)currentPhase];
    }
}
