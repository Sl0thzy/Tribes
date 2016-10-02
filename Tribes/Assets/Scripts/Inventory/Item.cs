using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

	public string itemName;
	public string itemDescription;
	public int itemID;
	public Sprite itemSprite;
	public string itemSpriteName;

	public Item(string name, string description, string spriteName, int id){
		itemName = name;
		itemDescription = description;
		itemID = id;
		itemSpriteName = spriteName; 
		itemSprite = Resources.Load<Sprite> ("ItemIcons/" + spriteName);
	}

	public Item(){

	}

}
