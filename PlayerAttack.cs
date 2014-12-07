using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private float attackTimer;
	private bool canAttack;
	private Vector3 oldPos;

	public bool attacking;

	void Start() 
	{
		canAttack = true;
		attackTimer = 70;
	}


	void Update()
	{
		if (attacking)
		{
			transform.position = oldPos;
			attacking = false;
		}

		attackTimer --;

		if  (attackTimer <= 0)
		{
			attackTimer = 70;
			canAttack = true;
		}

		if ((Input.GetKeyDown (KeyCode.LeftShift)) && (canAttack))
		{
			attacking = true;
			oldPos = transform.position;
			transform.position += new Vector3(-0.05f, 0.0f, 0.0f);
			canAttack = false;
		}
		else if ((Input.GetKeyDown (KeyCode.RightShift)) && (canAttack))
		{
			attacking = true;
			oldPos = transform.position;
			transform.position += new Vector3(0.05f, 0.0f, 0.0f);
			canAttack = false;
		}
	}
}
