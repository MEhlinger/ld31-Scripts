using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Narration : MonoBehaviour {

	public Text narrative;
	public GameObject PC;

	private ArrayList narrations = new ArrayList();

	private string nextText;

	private float textTimer;
	public float textTimerInterval;





	void Start()
	{
		CreateArray();
		textTimer = textTimerInterval;
	}

	void Update()
	{
		TimerDown();

	}




	void CreateArray()
	{
		narrations.Add("A/D or Arrowkeys To Move");
		narrations.Add("Space to Interact");
		narrations.Add("Hold Q to run...");
		narrations.Add("... at the cost of BODY");
		narrations.Add("LShift and RShift to attack...");

		narrations.Add("'What was that??'");
		narrations.Add("'Why would I ever go outside?'");
		narrations.Add("'Strange...those sounds...'");

		narrations.Add("'I'm not crazy.");
		narrations.Add("'I just get it... I know what's out there...");
		narrations.Add("'Oh god...'");

	}

	void TimerDown()
	{
		textTimer --;

		if (textTimer <= 0)
		{
			textTimer = textTimerInterval;
			DisplayNarration();
			if (nextText == "LShift and RShift to attack...") // nextText is actually last text
			{
				textTimerInterval *= 4;
			}  
			
		}
	}

	void DisplayNarration()
	{
		if (narrations.Count > 0)
		{
			nextText = narrations[0].ToString();
			narrations.RemoveAt(0);
			narrative.text = nextText;
		}
		else
		{
			narrative.text = "GAME OVER...";
		}
	}


}
