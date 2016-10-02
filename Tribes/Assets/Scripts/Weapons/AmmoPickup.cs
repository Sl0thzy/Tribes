using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {

	public string weaponName = "Wep1";
	private GameObject weaponManager;
	private ShootingSys shootingSys;

	public int ammoAmount = 9;

	void Start(){
		weaponManager = GameObject.FindGameObjectWithTag ("WeaponManager");
	}

	public void Interact(){
		GameObject weaponFound = weaponManager.transform.FindChild(weaponName).gameObject;
		shootingSys = weaponFound.GetComponent<ShootingSys> ();
		shootingSys.reserveAmmo += ammoAmount;
		Destroy (gameObject);
	}
}
