﻿using UnityEngine;
using System.Collections;

public class TreeSys : MonoBehaviour {

	public int health = 100;

	private void Update(){
			
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
