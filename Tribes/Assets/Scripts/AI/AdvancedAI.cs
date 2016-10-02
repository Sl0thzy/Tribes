using UnityEngine;
using System.Collections;

public class AdvancedAI : MonoBehaviour {

	private NavMeshAgent agent;
	public Transform playerTransform;
	public Transform playerTransDist;
	private Player player;
	public bool isChasing = false;

	public float thinkTimer = 5f;
	private float thinkTimerMin = 5f;
	private float thinkTimerMax = 15;
	public float randomUnityCircRad = 7f;
	private float randMoveMin = 3f;
	private float randMoveMax = 11f;

	public int health = 100;
	public float viewRange = 100f;
	public float attackRange = 15f;
	public bool isAttacking = false;
	public float attackTimer = 1f;
	private float attackTimeStart;
	public float distToPlayer;
	public float attackDist = 5f;
	public float minDamage = 3f;
	public float maxDamage = 40f;

	public Ray ray;
	public RaycastHit hitInfo;


	private void Start(){
		
		agent = GetComponent<NavMeshAgent> ();
		thinkTimer = Random.Range (thinkTimerMin, thinkTimerMax);
		randomUnityCircRad = Random.Range (randMoveMin, randMoveMax);
		playerTransDist = GameObject.FindGameObjectWithTag ("Player").transform;
		player = playerTransDist.GetComponent<Player> ();

		ray = new Ray (transform.position, transform.forward);

		attackTimeStart = attackTimer;

	}

	private void Update(){
		CheckHealth ();

		distToPlayer = Vector3.Distance (transform.position, playerTransDist.position);

		Ray ray = new Ray (transform.position, transform.forward);
		// RaycastHit hitInfo;

		CheckForPlayer ();
			
		if (isChasing && !isAttacking ) {
			agent.SetDestination (playerTransform.position);
		}

		Debug.DrawRay(ray.origin, ray.direction * viewRange, Color.red);

		//Attack Thinking
		if (distToPlayer <= attackDist && isChasing) {
			isAttacking = true;
		}

		if (isAttacking) {
			attackTimer -= Time.deltaTime;
			isChasing = false;
			agent.SetDestination (transform.position); //Clear Dest
		}

		if (attackTimer <= 0) {
			Attack ();
			attackTimer = attackTimeStart;
			isAttacking = false;
			CheckForPlayer ();
		}

		if (Physics.Raycast (ray, out hitInfo, attackRange)) {

		}

		thinkTimer -= Time.deltaTime; 
		if (thinkTimer <= 0) {
			Think ();
			thinkTimer = Random.Range (thinkTimerMin, thinkTimerMax);
			randomUnityCircRad = Random.Range (randMoveMin, randMoveMax);
		}
	}

	public void TakeDamage(int dmg){
		health -= dmg;

		if (playerTransform != null) {
			isChasing = true; 
		}
	}

	private void CheckHealth(){
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	private void Think(){

		if (!isChasing) {
			Vector3 newPos = transform.position + new Vector3 (Random.insideUnitCircle.x * randomUnityCircRad, transform.position.y, Random.insideUnitCircle.y * randomUnityCircRad);
			agent.SetDestination (newPos);
		}

	}

	private void Attack(){
		
		float damage = Random.Range (minDamage, maxDamage);
		RaycastHit hitInfo;
		Debug.Log ("bam1");
		if (Physics.Raycast (ray, out hitInfo, attackRange)) {
			Debug.Log ("bam2");
			Debug.Log (hitInfo.collider.tag.ToString());
			if(hitInfo.collider.tag == "Player"){
				Debug.Log ("bam3");
				player.AttackPlayer (damage);
			}
		}
	}

	private void CheckForPlayer(){
		if(Physics.Raycast(ray, out hitInfo, viewRange)){
			if (hitInfo.collider.tag == "Player") {
				if (!isChasing && !isAttacking) {
					isChasing = true;

					if (playerTransform == null) {
						playerTransform = hitInfo.collider.GetComponent<Transform> ();
					}
				}
			}
		}
	}
}
