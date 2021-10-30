using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Item
{
	[SerializeField]
	public Shop.coinType ItemType;
	[Tooltip("If the coin type is set to a coin this image is ignored")]
	[SerializeField]
	public Texture2D icon;
	
	[TextArea(1, 10)]
	[SerializeField]
	public string name;
	[SerializeField]

	public int quantity;
	[SerializeField]
	public int cost;
	[SerializeField]
	
	public Shop.coinType costCoin;
}
