using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustText : MonoBehaviour {

	public GameObject bloodText;
	public float movementScale=1f;
	private Rigidbody rBody;
	private float rotateBody=0f;
	private Vector3 pos;

	private bool couldBeSwipe=false;
	private Vector2 startPos;

	public float minSwipeDistY;
	
	public float minSwipeDistX;

	public float swipeForce=10f;

	
	public static float swipeDir;
	// Use this for initialization
	void Start () {
		rotateBody = Random.Range (0f, 360f);
		rBody = GetComponent<Rigidbody> ();
		InvokeRepeating ("MoveText", 0.01f, 0.1f);
		InvokeRepeating ("CheckPosition", 1f, 1f);

	
	}
	

	
	void FixedUpdate()
	{
		//#if UNITY_ANDROID
		if (Input.touchCount > 0) 
			
		{
			
			Touch touch = Input.touches[0];
			
			
			
			switch (touch.phase) 
				
			{
				
			case TouchPhase.Began:
				
				startPos = touch.position;
				
				break;
				
				
				
			case TouchPhase.Ended:
				
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				DebugText.ok="Vertical: "+swipeDistVertical.ToString();
				if (swipeDistVertical > minSwipeDistY) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					
					if (swipeValue > 0)//up swipe
						rBody.AddForce(Vector3.up * swipeForce);
					//DebugText.ok="up swipe";
					//Jump ();
					
					else if (swipeValue < 0)//down swipe
						rBody.AddForce(Vector3.down * swipeForce);
						//Debug.Log ("ok");
					//DebugText.ok="down swipe";
					//Shrink ();
					
				}
				
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				DebugText.ok="Vertical: "+swipeDistVertical.ToString() + " \n" + "Hor: "+swipeDistHorizontal.ToString();
				if (swipeDistHorizontal > minSwipeDistX) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					
					if (swipeValue > 0)//right swipe
						rBody.AddForce(Vector3.right * swipeForce);
						//Debug.Log ("ok");
					//DebugText.ok="right swipe";
					//MoveRight ();
					
					else if (swipeValue < 0)//left swipe
						rBody.AddForce(Vector3.left * swipeForce);
						//Debug.Log ("ok");
					//DebugText.ok="left swipe";
					//MoveLeft ();
					
				}
				break;
			}
		}

		pos = transform.position;
		pos.y = Vector3.Dot(Input.gyro.gravity, Vector3.up) * movementScale;
		rBody.AddForce(Input.acceleration);
		//Input.touches.
	
	}

	public void MoveText()
	{
		if(bloodText!=null)
		{
			bloodText.transform.position = Camera.main.WorldToScreenPoint (transform.position);
			bloodText.transform.eulerAngles=new Vector3(0f,0f,rotateBody);
			bloodText.GetComponent<Text>().color=new Color(GetComponent<BloodType>().bloodStickiness,0f,0f);
		}

		gameObject.GetComponent<BoxCollider> ().size = new Vector3 (bloodText.GetComponent<Text> ().fontSize / 80f * 2.84f, bloodText.GetComponent<Text> ().fontSize / 80f * 0.608f);
	}

	public void CheckPosition()
	{
		if ((transform.position.x > 2.3f || transform.position.x < -2.3f) || (transform.position.y > 5.52f || transform.position.y < -3.52f)) {
			//Debug.Log ("destroying");
			Destroy(bloodText);
			Destroy(gameObject);

		}
	}


	void OnMouseDown()
	{
		Debug.Log ("NICE");
	}
}
