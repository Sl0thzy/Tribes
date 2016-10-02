using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDB : MonoBehaviour {

	public List<Item> items = new List<Item>();

	private void Start(){
		ItemDatabaseSetup ();
	}

	private void CreateItems(){
		items.Add (new Item ("Wep1", "A weapon", "Glock_Item", 0));
	}

	private void ItemDatabaseSetup(){
		items.Add (new Item ("Wep1", "A weapon", "Glock_Item", 0));
		items.Add (new Item ("Apple", "A fruit", "Glock_Item", 1));
	}

	public Item GetItemByID(int id){
		foreach (Item itm in items) {
			if (itm.itemID == id) {
				return itm;
			}
		}
		return null;
		Debug.LogError ("Can't find item by current ID");
	}
}
