using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {

	private Transform playerTransform;
	private AdvancedAI advancedAI;

	private void Start(){
		advancedAI = GetComponentInParent<AdvancedAI> ();
	}

	private void OnTriggerEnter(Collider target){
		if (target.tag == "Player") {
			playerTransform = target.GetComponent<Transform> ();

			if (advancedAI.playerTransform == null) {
				advancedAI.playerTransform = playerTransform;
			}
		}
	}
}
