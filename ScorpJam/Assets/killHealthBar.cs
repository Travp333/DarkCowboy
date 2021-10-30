using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killHealthBar : MonoBehaviour
{
	public GameObject healthbar;
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		if (healthbar != null){
			healthbar.SetActive(false);
		}
	}
}
