using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class ArrowSys : MonoBehaviour {

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		transform.LookAt (transform.position + rb.velocity);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (transform.position + rb.velocity);
	}
}
