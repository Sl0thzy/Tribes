using UnityEngine;
using System.Collections;

public class FoodItem : MonoBehaviour {

	private Player player;
	public float foodAmountAdd = 25f;
	public enum FoodType {Food, Water };
	public FoodType foodType = new FoodType();

	public void DestroyObject(){
		Destroy (gameObject);
	}
}
