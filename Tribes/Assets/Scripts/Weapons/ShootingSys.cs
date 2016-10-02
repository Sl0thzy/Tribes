using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootingSys : MonoBehaviour {

	public float weaponRange = 500f;
	public Camera FPSCamera;
	private AdvancedAI enemy;

	public int minDmg = 15;
	public int maxDmg = 25;

	public int clip = 7;
	public int maxClip = 7;
	public int reserveAmmo = 28;
	public bool clipEmpty;
	public Text ammoText;

	public PauseManager pauseManager;

	void Start(){
		Camera FPSCamera = GetComponent<Camera>();
		clipEmpty = false;
	}

	private void Update () {
		Ray ray = FPSCamera.ScreenPointToRay (new Vector2 (Screen.width / 2, Screen.height / 2));
		RaycastHit hitInfo;

		if (Input.GetKeyDown (KeyCode.Mouse0) && !pauseManager.isPaused && !clipEmpty) {
			clip -= 1; 

			if (Physics.Raycast (ray, out hitInfo, weaponRange)) {
				if (hitInfo.collider.tag == "Enemy") {
					enemy = hitInfo.collider.GetComponent<AdvancedAI> ();
					enemy.TakeDamage (Damage());
					Debug.Log ("Hit");
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.R) && clip != maxClip && reserveAmmo != 0) {
			int totalAmmo = clip + reserveAmmo;
			if (totalAmmo <= maxClip) {
				clip = totalAmmo;
				reserveAmmo = 0;
			} else {
				int shots = maxClip - clip;
				clip = 8;
				reserveAmmo -= shots;
			}
		}

		if (clip <= 0) {
			clipEmpty = true;
		} else {
			clipEmpty = false;
		}

		ammoText.text = ("Ammo: " + clip + "/" + reserveAmmo);
	}

	private int Damage(){
		return Random.Range (minDmg, maxDmg);
	}
}

