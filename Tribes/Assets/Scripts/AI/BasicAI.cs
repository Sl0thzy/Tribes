using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

	private NavMeshAgent agent;
	private Transform playerTransform;
	private bool isChasing = false;

	public int health = 100;

	private void Start(){
		agent = GetComponent<NavMeshAgent> ();
	}

	private void Update(){

		if (isChasing) {
			agent.SetDestination (playerTransform.position);
		}

		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	private void OnTriggerEnter(Collider target){
		if (target.tag == "Player") {
			playerTransform = target.transform; 
			isChasing = true;
		}
	}

	public void TakeDamage(int dmg){
		health -= dmg;
		Debug.Log ("Hit Enemy " + "EnemyHP:" + health);
	}
}
