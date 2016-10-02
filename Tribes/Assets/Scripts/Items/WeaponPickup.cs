using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

	public string weaponName = "Wep1";
	public string pickupName = "Wep1";

	private GameObject weaponManager;

	private void Start(){
		weaponManager = GameObject.FindGameObjectWithTag ("WeaponManager");
	}

	public void Interact(){
		GameObject weaponFound = weaponManager.transform.FindChild (weaponName).gameObject;
		weaponFound.SetActive (true);
		Debug.Log ("Weapon = " + weaponName);
	}

}
