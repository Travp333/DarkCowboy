using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopItems 
{
	public enum coinType { coinA, coinB, coinC, coinD, coinE, coinF, coinG, coinH };
	
	public struct Item
	{
		RawImage icon;
		Text name;
		int cost;
		coinType costCoin;
	}
	public Item[] inventory;
}
