using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Item
{
	public Shop.coinType ItemType;
	[Tooltip("If the coin type is set to a coin this image is ignored")]
	public Texture2D icon;
	
	[TextArea(1, 10)]
	public string name;

	public int quantity;
	public int cost;
	
	public Shop.coinType costCoin;
}
