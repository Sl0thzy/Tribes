using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject deathCanvas;
	public Vector3 spawnPoint = Vector3.zero;

	public float hunger = 100f;
	public float thirst = 100f;
	public float health = 100f;

	public Image healthBar;
	public Image hungerBar;
	public Image thirstBar;

	public float hungerSpeedMult = 0.30f;
	public float thirstSpeedMult = 0.75f;
	public float healthSpeedMult = 0.4f;

	private bool isDying = false;

	private void Start(){
		deathCanvas.SetActive (false);
	}

	private void Update(){
		CheckDeath ();

		healthBar.fillAmount = health / 100;
		hungerBar.fillAmount = hunger / 100;
		thirstBar.fillAmount = thirst / 100;

		CheckStats ();
	}

	private void CheckDeath(){
		if (health <= 0){
			Die ();
		}
	}

	private void Die(){
		deathCanvas.SetActive (true);
	}

	public void Respawn(){
		deathCanvas.SetActive (false);
		transform.position = spawnPoint;
		hunger = 100f;
		thirst = 100f;
		health = 100f;
	}

	public void AddFood(float amnt){
		hunger += amnt;
	}

	public void addWater(float amnt){
		thirst += amnt;
	}

	public void AttackPlayer(float amount){
		health -= amount;
	}

	private void CheckStats(){
		if (hunger > 0) {
			hunger -= Time.deltaTime * hungerSpeedMult;
		}

		if (thirst > 0) {
			thirst -= Time.deltaTime * thirstSpeedMult;
		}

		if (hunger <= 0 || thirst <= 0) {
			isDying = true;
		} else {
			isDying = false;
		}

		if (isDying) {
			health -= Time.deltaTime * healthSpeedMult;
		}

		if (hunger > 100) {
			hunger = 100f;
		}

		if (thirst > 100) {
			thirst = 100f;
		}
	}
}
