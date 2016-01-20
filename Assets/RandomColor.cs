using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RandomColor : MonoBehaviour {

	public Color[] randColors;
	private float speed=1f;
	private GameObject targetSprite;
	private int healthLeft=3;
	public GameObject bloodText;
	public GameObject bloodCol;
	public GameObject canvas;
	private GameObject tempObj;
	private GameObject tempText;
	// Use this for initialization
	void Start () {

		GetComponent<Renderer>().material.color=randColors[Random.Range(0,7)];
		targetSprite=GameObject.Find ("TargetSprite");
		canvas = GameObject.Find ("BloodContainer");
		InvokeRepeating ("CheckSize", 0.1f, 0.2f);
		if (Random.value > 0.5f)
			gameObject.layer = 9;
	}
	
	// Update is called once per frame
	void Update () {

//		for (var i = 0; i < Input.touchCount; ++i) {
//			if (Input.GetTouch(i).phase == TouchPhase.Began)
//			{
//				this.ApplyDamage();
//			}
//			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
//				// Get movement of the finger since last frame
//				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//				
//				// Move object across XY plane
//				transform.position=new Vector3(touchDeltaPosition.x,touchDeltaPosition.y,0f);
//			}
//		}
	
	}

	void ApplyDamage()
	{
		//Debug.Log("hi");
		GetComponent<Renderer>().material.color=randColors[Random.Range(0,7)];
//		targetSprite.transform.position = new Vector3 (transform.position.x,transform.position.y,targetSprite.transform.position.z);
		tempObj=Instantiate (bloodCol,new Vector3(transform.position.x,transform.position.y,-1.85f),Quaternion.identity) as GameObject;
		tempText=Instantiate (bloodText,Camera.main.WorldToScreenPoint(transform.position+new Vector3(Random.Range (0.01f,-0.01f),Random.Range (-0.02f,-0.02f),0f)),Quaternion.identity) as GameObject;
		tempText.transform.parent=canvas.transform;
		Vector3 scaleFactor = transform.localScale / 0.3f;
		//Debug.Log (scaleFactor);
		tempText.GetComponent<Text> ().fontSize = Mathf.FloorToInt((120f -(30f* healthLeft)));
		transform.localScale += new Vector3 (0.3f, 0.3f, 0.3f);
		tempObj.GetComponent<AdjustText>().bloodText=tempText;
		tempObj.GetComponent<AdjustText>().MoveText();

		BackgroundChanger.colorChanger += 0.5f;

		healthLeft--;
		if (healthLeft < 0) {
			SpawnCubes.currentCubes--;
			Destroy(this.gameObject); 

		}
	}

	public void CheckSize()
	{
		if (transform.localScale.x > 8f) {
			Debug.Log ("hi");
			StateManager.gameOver=true;
			StateManager.change=true;
		}
	}

	void OnMouseDown()
	{
		//Debug.Log ("hi my name is" + gameObject.name);
		this.ApplyDamage();

	}

	void OnMouseDrag()
	{
//		Vector3 touchDeltaPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		
//		// Move object across XY plane
//		transform.position=new Vector3(touchDeltaPosition.x,touchDeltaPosition.y,0f);
//		this.ApplyDamage();
	}

}
