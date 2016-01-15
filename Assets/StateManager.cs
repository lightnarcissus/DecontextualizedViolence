using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StateManager : MonoBehaviour {

	public GameObject gameOverPanel;
	public GameObject scoreKeeper;
	public float bestScore=0f;
	public static bool gameOver=false;

	// Use this for initialization
	void Start () {

		gameOverPanel.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver) {

			if(Input.GetMouseButtonDown(0))
			{
				gameOver=false;
				ResetStatics();
				Application.LoadLevel (1);
			}
		}
	
	}

	public void GameOver()
	{

		gameOver = true;
		gameOverPanel.SetActive (true);
		gameOverPanel.transform.GetChild (0).gameObject.GetComponent<Text> ().text = "Last: "+scoreKeeper.GetComponent<TimerScore> ().timer.ToString ("F2");
		if (scoreKeeper.GetComponent<TimerScore> ().timer > TimerScore.bestTimer) {
			TimerScore.bestTimer=scoreKeeper.GetComponent<TimerScore> ().timer;
		}
		gameOverPanel.transform.GetChild (1).gameObject.GetComponent<Text> ().text = "Best: "+ TimerScore.bestTimer.ToString ("F2");
	}

	public void ResetStatics()
	{
		BackgroundChanger.colorChanger = 1f;
		scoreKeeper.GetComponent<TimerScore> ().timer = 0f;
		SpawnCubes.currentCubes = 0;

	}
}
