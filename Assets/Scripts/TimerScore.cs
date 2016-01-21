using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScore : MonoBehaviour {
		
	public GameObject mainCam;
	public GameObject bloodManager;
	public Text timerText;
	public Text levelText;
	public string[] levelNames;
	public int level = 1;
	public float timer=0f;
	public static float bestTimer=0f;
	private bool zoomOut=false;
	private float zoomTimer=0f;
	private float tempVal=0f;
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


		if (zoomOut) {
			zoomTimer+=Time.deltaTime;
			mainCam.GetComponent<Camera> ().orthographicSize = Mathf.Lerp (tempVal,tempVal+5f,zoomTimer);
			if(zoomTimer>1f)
			{
				zoomTimer=0f;
				zoomOut=false;
			}

		}
	}

	public void UpdateLevel()
	{
		level++;
		levelText.text= levelNames [level-1];
		tempVal=mainCam.GetComponent<Camera> ().orthographicSize;
		zoomOut = true;
		bloodManager.GetComponent<BloodManager> ().UpdateBlood (level);
	}

	IEnumerator ZoomOut()
	{
		float temp = mainCam.GetComponent<Camera> ().orthographicSize;
		for (float i=0f; i<5f; i+=0.01f) {
			mainCam.GetComponent<Camera> ().orthographicSize = Mathf.Lerp (temp,temp+5f,i/5f);
			Debug.Log (mainCam.GetComponent<Camera> ().orthographicSize);
		}
		yield return null;
	}
}
