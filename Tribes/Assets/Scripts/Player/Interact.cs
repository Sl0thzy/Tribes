using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	public Camera FPSCamera;
	public float interactRange = 3.5f;
	private FoodItem foodItem;
	private Player player;

	private Inventory inventory;

	private void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
	}

	private void Update(){

		Ray ray = FPSCamera.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2));
		RaycastHit hitInfo;

		if (Input.GetKeyDown (KeyCode.E)) {
			if (Physics.Raycast (ray, out hitInfo, interactRange)) {
				if (hitInfo.collider.tag == ("FoodItem")) {
					foodItem = hitInfo.collider.GetComponent<FoodItem> ();
					if (foodItem.foodType == FoodItem.FoodType.Food) {
						//player.AddFood (foodItem.foodAmountAdd);
						inventory.AddItem(1);
						// Destroy (foodItem);
						foodItem.DestroyObject ();
					} else if (foodItem.foodType == FoodItem.FoodType.Water) {
						player.addWater (foodItem.foodAmountAdd);
						// Destroy (foodItem);
						foodItem.DestroyObject ();
					}
				} else if (hitInfo.collider.tag == ("WeaponPickup")) {
					WeaponPickup weaponPickup = hitInfo.collider.GetComponent<WeaponPickup> ();
					weaponPickup.Interact ();
				} else if (hitInfo.collider.tag == ("AmmoPickup")) {
					AmmoPickup ammoPickup = hitInfo.collider.GetComponent<AmmoPickup> ();
					ammoPickup.Interact ();
					Debug.Log ("Ammo Pickup");
				}
			}
		}
	}
}
