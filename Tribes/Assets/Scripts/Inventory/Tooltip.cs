using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

	public Vector2 offset;

	public GameObject toolTipObject;

//	public Text button1;
//	public Image backgroundImage;
//	public Text button2;

	private void Start(){
		// ToggleToolTip (false, Vector2.zero);
		//ToggleToolTip(false);

	}

	private void LateUpdate(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			ToggleToolTip (false);
		}
	}

	public void ToggleToolTip(bool enabled, Vector2 position){
		if (enabled) {
		//	toolTipObject.SetActive (true);
			transform.localScale = Vector3.one;
		//	backgroundImage.enabled = true;
		//	button1.enabled = true;
		//	button2.enabled = true;
		} else if (!enabled) {
		//	toolTipObject.SetActive (false);
			transform.localScale = Vector3.zero;
		//	backgroundImage.enabled = false;
		//	button1.enabled = false;
		//	button2.enabled = false;
		}

		transform.position = position + offset;
	}

	public void ToggleToolTip(bool enabled){
		if (enabled) {
			toolTipObject.SetActive (true);
		//	backgroundImage.enabled = true;
		//	button1.enabled = true;
		//	button2.enabled = true;
		} else if (!enabled) {
			toolTipObject.SetActive (false);
		//	backgroundImage.enabled = false;
		//	button1.enabled = false;
		//	button2.enabled = false;
		}

		transform.position = Vector2.zero;
	}

}
