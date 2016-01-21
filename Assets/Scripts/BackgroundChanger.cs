using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class BackgroundChanger : MonoBehaviour {

	public AudioSource music;
	public static float colorChanger = 1f;
	public float difficultyLevel=0.5f;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
		//GetComponent<Camera>().backgroundColor=new Color (Mathf.Sin (Time.time), Mathf.Cos (Time.time * 1.5f), Mathf.Sin (Time.time * 2f), 8f - (Time.time % 1f));
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		//Debug.Log (Mathf.PingPong (Time.time, 3));
	//	GetComponent<Camera>().backgroundColor=new Color (Mathf.Sin (Time.time), 0f,0f,1f);
		GetComponent<Camera> ().backgroundColor = new Color (colorChanger, colorChanger, colorChanger);
		GetComponent<VignetteAndChromaticAberration> ().blur = (1f-colorChanger);
		GetComponent<VignetteAndChromaticAberration> ().blurSpread = (1f-colorChanger);
		GetComponent<VignetteAndChromaticAberration> ().chromaticAberration = (1f-colorChanger) * 7f;
		colorChanger -= Time.deltaTime*difficultyLevel;

		if(colorChanger>1f)
			colorChanger=1f;


		if (colorChanger < 0.01f) {
			gameObject.GetComponent<StateManager>().GameOver();
		}
	}


}
