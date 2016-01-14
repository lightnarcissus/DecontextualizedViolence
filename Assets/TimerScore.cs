using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScore : MonoBehaviour {
		
	public Text timerText;
	public float timer=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		timerText.text = timer.ToString ("F2");

	
	}
}
