using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects; 
using System.Collections;

public class PauseManager : MonoBehaviour {

	public GameObject pauseCanvas;
	public KeyCode pauseKey = KeyCode.Escape;
	private Blur blur;  

	public bool isPaused = false;
	private Inventory inventory;

	private void Start(){
		
		// pauseCanvas.SetActive (false);
		isPaused = false;

		blur = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Blur> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
	}

	private void Update(){

		if (Input.GetKeyDown (pauseKey)) {
			isPaused = !isPaused;

			if (isPaused) {
				CursorManager.ShowUnlockCursor ();
				inventory.isShown = false;
			}

			if (!isPaused) {
				CursorManager.HideLockCursor ();
				inventory.isShown = false;
			}
		}
			
		if (isPaused) {
			Time.timeScale = 0.0f;
			pauseCanvas.SetActive (true);
			blur.enabled = true;
		} else if (!isPaused) {
			Time.timeScale = 1.0f;
			pauseCanvas.SetActive (false);
			blur.enabled = false;
		}
	}

	public void ResumeGame(){
		isPaused = false;
	}

	public void ExitGame(){
		Application.Quit ();
		Debug.Log ("Exiting...");
	}
}
