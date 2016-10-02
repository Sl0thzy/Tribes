using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemObj : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

	private Transform startParent;

	private CanvasGroup canvasGroup;

	private Tooltip tooltip;
	private TooltipButton toolTipButton1;
	private TooltipButton toolTipButton2;

	private bool inItem = false;

	private void Start(){
		startParent = transform.parent;
		canvasGroup = GetComponent<CanvasGroup> ();

		tooltip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
		toolTipButton1 = GameObject.FindGameObjectWithTag ("TooltipButton1").GetComponent<TooltipButton> ();
		toolTipButton2 = GameObject.FindGameObjectWithTag ("TooltipButton2").GetComponent<TooltipButton> ();
	}

	private void Update(){
		//toolTipButton1 = GameObject.FindGameObjectWithTag ("TooltipButton1").GetComponent<TooltipButton> ();
		if (Input.GetKeyDown (KeyCode.Mouse1) && inItem) {
			tooltip.ToggleToolTip (true, Input.mousePosition);
			toolTipButton1.actionMethod = DebugTest;
		}
	}

	private void DebugTest(){
		Debug.Log ("We passed methods and used our tooltip!");
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{

		transform.position = eventData.position;
		transform.SetParent(transform.parent.parent);

		//Debug.Log (GetItemChild.name);

		//Disable block raycast
		canvasGroup.blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{

		transform.position = eventData.position;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		GetSlotInfo ();

		canvasGroup.blocksRaycasts = true;
	}

	#endregion

	private void GetSlotInfo(){
		GameObject[] slots = GameObject.FindGameObjectsWithTag ("Slot");

		foreach (var slot in slots) {
			if (slot.GetComponent<SlotEffect> ().isSelected == true) {

				//check if item is already in slot
				if (slot.transform.childCount > 0) {
					ItemObj otherItem = slot.transform.GetChild (0).GetComponent<ItemObj> ();
					Transform otherItemParent = otherItem.startParent;
					otherItem.startParent = startParent;
					startParent = otherItemParent; 

					otherItem.transform.SetParent (otherItem.startParent);
					otherItem.transform.localPosition = Vector2.zero;
			
				} else {
					startParent = slot.transform;
				}
				break;
			}
		}

		transform.localPosition = Vector2.zero;
		canvasGroup.blocksRaycasts = true;
	}

	#region IPointerEnterHandler implementation
	public void OnPointerEnter (PointerEventData eventData)
	{
		inItem = true;
	}
	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		inItem = false;
	}

	#endregion
}
