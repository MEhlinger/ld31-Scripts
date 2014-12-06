using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateHealthGUI : MonoBehaviour 
{

	public Text text;
	public GameObject PC;
	private float hpVal;


	public void Update()
	{
		hpVal = PC.GetComponent<PlayerController>().health;
		text.text = "BODY : " + hpVal.ToString();
	}
}

