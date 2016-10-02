using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SlotEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private Outline outline; 

	public bool isSelected = false;

	private void Start(){
		outline = GetComponent<Outline> ();
		outline.enabled = false;
	}

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
		outline.enabled = true;
		isSelected = true;
	}

	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		outline.enabled = false;
		isSelected = false;
	}

	#endregion

}
