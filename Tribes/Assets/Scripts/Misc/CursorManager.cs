using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

	private PauseManager pauseManager;
	private Inventory inventory;

	// Use this for initialization
	private void Start () {
		pauseManager = GameObject.FindGameObjectWithTag ("PauseManager").GetComponent<PauseManager> ();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	private void Update () {
		if (pauseManager.isPaused == true || inventory.isShown == true) {
			ShowUnlockCursor ();
		}else

		if (pauseManager.isPaused == false || inventory.isShown == false) {
			HideLockCursor ();
		}
		/*
		if (inventory.isShown == true) {
			ShowUnlockCursor ();
		}

		if (inventory.isShown == false) {
			HideLockCursor ();
		}
		*/
	}
	public static void HideLockCursor(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public static void ShowUnlockCursor(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
