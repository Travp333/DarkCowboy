using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Item
{
	
	public Texture icon;
	
	[TextArea(1, 10)]
	public string name;
	
	public int cost;
	
	public Shop.coinType costCoin;
}
