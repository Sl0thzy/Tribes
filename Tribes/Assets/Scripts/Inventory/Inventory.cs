using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int slotAmmount = 30;
	public GameObject slotPrefab;
	public GameObject slotParent;
	public GameObject inventoryObject;

	private KeyCode inventoryKey = KeyCode.Tab;
	public bool isShown = false;

	public List<GameObject> slots = new List<GameObject> ();

	public GameObject itemPrefab;
	private PauseManager pauseManager;

	private ItemDB itemDB;
	private RigidbodyFirstPersonController fpsController;
	private float defaultMouseLookX = 2f;
	private float defaultMouseLookY = 2f;

	private Tooltip toolTip;

	private void Start(){
		CreateSlots (slotAmmount);
		itemDB = GameObject.FindGameObjectWithTag ("ItemDB").GetComponent<ItemDB> ();
		pauseManager = GameObject.FindGameObjectWithTag ("PauseManager").GetComponent<PauseManager> ();
		fpsController = GameObject.FindGameObjectWithTag ("Player").GetComponent<RigidbodyFirstPersonController> ();
		toolTip = GameObject.FindGameObjectWithTag ("Tooltip").GetComponent<Tooltip> ();

		AddItem (0);

	}

	private void Update(){
		if (Input.GetKeyDown (inventoryKey) && pauseManager.isPaused == false) {
			isShown = !isShown;
		}

		if (isShown) {
			toolTip.ToggleToolTip (false);
			inventoryObject.SetActive (true);
			fpsController.mouseLook.YSensitivity = 0;
			fpsController.mouseLook.XSensitivity = 0;
		} else if (!isShown) {
			inventoryObject.SetActive (false);
			fpsController.mouseLook.YSensitivity = defaultMouseLookY;
			fpsController.mouseLook.XSensitivity = defaultMouseLookX;
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			AddItem (0);
		}
	}

	private void CreateSlots(int slotAmmount){
		for (int i = 0; i < slotAmmount; i++) {
			slots.Add(Instantiate (slotPrefab));
			slots[i].transform.SetParent (slotParent.transform);
		}
	}

	public void AddItem(int id){
		if (itemDB == null) {
			itemDB = GameObject.FindGameObjectWithTag ("ItemDB").GetComponent<ItemDB> ();
		}
		Item itemAdd = itemDB.GetItemByID (id);

		for (int i = 0; i < slots.Count; i++) {
			if (slots [i].transform.childCount <= 0) {
				GameObject itemInstance = Instantiate (itemPrefab); // Create obj
				itemInstance.transform.SetParent (slots [i].transform);
				itemInstance.transform.localPosition = Vector2.zero; // Center Item
				itemPrefab.GetComponent<Image> ().sprite = itemAdd.itemSprite; // Add sprite
				break;
			}
		}
	}

}
