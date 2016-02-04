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
	public GameObject cubes;
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
		tempObj.transform.parent = transform.parent.GetComponent<CubeManager> ().bloodManager.transform;
		transform.parent.GetComponent<CubeManager> ().bloodManager.GetComponent<BloodManager> ().AddBlood (tempObj);
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
			if(gameObject.tag=="Sphere")
			{
				for(int i=0;i<5;i++)
				{
					GameObject tempCube=Instantiate(cubes,transform.position-new Vector3(Random.Range (-1f,1f),Random.Range(-1f,1f),0),Quaternion.identity) as GameObject;
					SpawnCubes.currentCubes++;
					tempCube.transform.parent=transform.parent;
				//	tempCube.GetComponent<Rigidbody>().AddExplosionForce(2f,transform.position,1.5f);
				}
			}
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
