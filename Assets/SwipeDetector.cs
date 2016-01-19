﻿using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour 
{
	
	public float minSwipeDistY;
	
	public float minSwipeDistX;
	
	private Vector2 startPos;
	
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
						Debug.Log ("ok");
						//DebugText.ok="up swipe";
						//Jump ();
						
						else if (swipeValue < 0)//down swipe
						Debug.Log ("ok");
						//DebugText.ok="down swipe";
							//Shrink ();
							
				}
				
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				DebugText.ok="Hor: "+swipeDistHorizontal.ToString();
				if (swipeDistHorizontal > minSwipeDistX) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					
					if (swipeValue > 0)//right swipe

						Debug.Log ("ok");
						//DebugText.ok="right swipe";
						//MoveRight ();
						
						else if (swipeValue < 0)//left swipe
						Debug.Log ("ok");
						//DebugText.ok="left swipe";
							//MoveLeft ();
							
				}
				break;
			}
		}
	}
}