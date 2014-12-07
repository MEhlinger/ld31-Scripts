using UnityEngine;
using System.Collections;

public class FoodEat : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		rigidbody2D.AddForce(new Vector2(0.0f, 150.0f));
	}
}
