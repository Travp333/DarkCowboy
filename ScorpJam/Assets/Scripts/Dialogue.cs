using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
	[SerializeField]
	public string name;

	[TextArea(3,10)]
	[SerializeField]
	public string[] sentences; 
}
