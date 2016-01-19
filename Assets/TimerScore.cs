using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScore : MonoBehaviour {
		
	public Text timerText;
	public Text levelText;
	public string[] levelNames;
	private int level = 0;
	public float timer=0f;
	public static float bestTimer=0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateLevel", 10f, 10f);
		levelText.text = levelNames [level];
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!StateManager.gameOver) {
			timer += Time.deltaTime;
			timerText.text = timer.ToString ("F2");	
		}

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel (0);
	}

	public void UpdateLevel()
	{
		level++;
		levelText.text= levelNames [level];
	}
}
