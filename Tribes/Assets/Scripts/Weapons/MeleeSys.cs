using UnityEngine;
using System.Collections;

public class MeleeSys : MonoBehaviour {

	public int minDmg = 25;
	public int maxDmg = 50;
	public float weaponRange = 3.5f;
	public Camera FPSCamera;

	private TreeSys treeHealth;
	private BasicAI basicAI;
	private AdvancedAI advancedAI;

	private void Update(){
			
		Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
		RaycastHit hitInfo;

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (Physics.Raycast (ray, out hitInfo, weaponRange)) {
				if (hitInfo.collider.tag == "Tree") {

					treeHealth = hitInfo.collider.GetComponentInParent<TreeSys> ();
					AttackTree ();
				} else if (hitInfo.collider.tag == "Enemy") {
					basicAI = hitInfo.collider.GetComponent<BasicAI> ();
					advancedAI = hitInfo.collider.GetComponent<AdvancedAI> ();
					AttackEnemy ();
				}
			} 
		}
	}

	private void AttackTree(){
		Debug.Log ("Hit Tree " + "TreeHP:" + treeHealth.health);
		int dmg = Random.Range (minDmg, maxDmg);
		treeHealth.health -= dmg;
	}

	private void AttackEnemy(){
		int dmg = Random.Range (minDmg, maxDmg);
		// basicAI.health -= dmg;
		advancedAI.health -= dmg;
	}

}
