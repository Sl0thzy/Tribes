using UnityEngine;
using System.Collections;

public class PhysShootSys : MonoBehaviour {

	//private Player player;
	public float force;
	public float maxForce;
	public float forceIncr;

	private Camera camera;
	public GameObject projectile;

	public int ammo;
	private bool canShoot = true;

	public float dmg;


	private void Start(){
		force = 0;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		//maxForce = 5;
		// ammo = 12;
	}

	private void Update(){
		if(projectile != null){
			Debug.Log (canShoot);
		if (canShoot) {
				if (Input.GetKey (KeyCode.Mouse0)  && ammo > 0) {
					if (force < maxForce) {
						force += forceIncr;
					}
				}
					
				if(Input.GetKeyUp(KeyCode.Mouse0) && force > 0){
					Debug.Log ("Fire");
					GameObject proj = Instantiate(projectile, transform.position,Quaternion.identity) as GameObject;
					proj.transform.localRotation = Quaternion.Euler (90, 0, 0);	
					proj.GetComponent<Rigidbody>().AddForce(transform.forward * force);
					
					force = 0;
					ammo -=1;
				}
			}
		}
		}
	}
