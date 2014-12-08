using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Narration : MonoBehaviour {

	public Text narrative;
	public GameObject PC;

	private ArrayList narrations = new ArrayList();

	private string nextText;

	private float textTimer;
	private float textClearTimer;
	public float textTimerInterval;





	void Start()
	{
		CreateArray();
		textTimer = textTimerInterval / 2;
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
		narrations.Add("'There are things out there...'");
		narrations.Add("'The mailman is coming soon...'");
		narrations.Add("'I just need to make it until he arrives.'");
		narrations.Add("'What's happening?");
		narrations.Add("'Oh god...'");
		narrations.Add("'I can't handle this...");
		narrations.Add("'Not much longer now...'");
		narrations.Add("'If he can see them too...'");
		narrations.Add("'The mail should be here any minute now!'");
		narrations.Add("'He's coming!'");

	}

	void TimerDown()
	{
		textTimer --;
		if (textClearTimer <= 0)
		{
			 narrative.text = " ";
		}

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
			textClearTimer = textTimer / 2f;
		}
		else
		{
			narrative.text = "GAME OVER...";
		}
	}


}
