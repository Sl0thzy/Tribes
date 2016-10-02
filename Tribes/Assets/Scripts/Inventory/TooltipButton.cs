using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class TooltipButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public int fontSizeStart = 20;
	public int fontSizeAdd = 2;
	private int fontSizeNew;
	private bool isInside = false;
	private Text text;

	public Action actionMethod;

	private void Start(){
		text = GetComponent<Text> ();
		fontSizeNew = fontSizeStart + fontSizeAdd;
	}

	private void Update(){
		if (Input.GetKeyDown (KeyCode.Mouse0) && isInside) {
			SetCallAction (actionMethod);
		}
	}

	public void SetCallAction(Action action){
		if (action != null) {
			action ();
		} else {
			Debug.Log ("Calling unassigned method");
		}
	}

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
		text.fontSize = fontSizeNew;
		isInside = false;
	}

	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		text.fontSize = fontSizeStart;
		isInside = false;
	}

	#endregion



}
