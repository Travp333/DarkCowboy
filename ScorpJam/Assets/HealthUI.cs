using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
    
{

    [SerializeField]
    public PlayerStats stats;
    [SerializeField]
    public Slider HealthBar;
    [SerializeField]
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = stats.hp / stats.maxHp;
        hpText.text = stats.hp.ToString() + "/" + stats.maxHp.ToString();
        
    }
}
