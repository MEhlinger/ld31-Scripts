using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSanityGUI : MonoBehaviour 
{

	public Text text;
	public GameObject PC;
	private float sanVal;


	public void Update()
	{
		sanVal = PC.GetComponent<PlayerController>().sanity;
		text.text = "MIND : " + sanVal.ToString();
	}
}
