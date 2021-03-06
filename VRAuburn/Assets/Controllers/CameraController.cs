﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	Vector3[] pos;

	GameObject cam;
	GameObject slides;
	GameObject slideObject;
	
	RaycastHit rayHit;
	
	GameObject[] raises;
	GameObject[] rotates;
	GameObject[] fades;

	
	public Quaternion toAngle;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Game Start");

		cam = GameObject.Find("CardboardMain");
		slides = GameObject.Find("Slides");

		pos = new[] {new Vector3( 13, 15, -990 ),
			new Vector3 (13, 15, -470 )};
			
		cam.transform.position = pos[0];
		
		
		// Set Raises and Rotates
		raises = GameObject.FindGameObjectsWithTag("Raise");
		rotates = GameObject.FindGameObjectsWithTag("Rotate");
		fades = GameObject.FindGameObjectsWithTag("Fade");
		

	}
	
	// Update is called once per frame
	void Update () {
		/* if(Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Fire Clicked!");

		} */
	}
	
	public void moveToPos(int i){
		
		StartCoroutine(moveCam(i));
		displayPanels(i);
		
	}
	
	private IEnumerator moveCam(int i)
	{
		Debug.Log("Button Clicked!");
		
		while(Vector3.Distance(this.transform.position,pos[i]) >0.1f)
		{
			cam.transform.position = Vector3.Lerp(this.transform.position, pos[i],(float)0.2);
			yield return null;
		}
		
		Debug.Log("reached position"+i);
		

	}
	
	// Display panels for slide No i
	void displayPanels(int i)
	{
		
		if(i == 1)
		{
			Debug.Log("displaying panels 1");
			
			// slideObject = GameObject.Find("Slides/Slide1");
			
			
			// GameObject house = GameObject.Find("Slides/Slide1/HouseCollider");
			// rotateUp(house);
			
			
			foreach(GameObject raise in raises)
			{
				
				// GameObject tree = GameObject.Find("Slides/Slide1/TreeCollider");
				if(raise.transform.parent.gameObject.name == "Slide1")
				{
					raiseUp(raise);
				}

			}
			
			foreach(GameObject rotate in rotates)
			{
				if(rotate.transform.parent.gameObject.name == "Slide1")
				{
					rotateUp(rotate);
				}
			}
			
			foreach(GameObject fade in fades)
			{
				if(fade.transform.parent.gameObject.name == "Slide1")
				{
					Debug.Log("Fading!");
					// fade.GetComponent<Text>().CrossFadeAlpha(0f,1f,false);
					// fadeIn(fade);
				}
			}
			
			
		}
	}
	
	void fadeIn(GameObject obj)
	{
		StartCoroutine(fadingIn(obj,0f, 1f));
	}
	
	IEnumerator fadingIn(GameObject canvas, float endAlpha,float time)
	{
		Text t = canvas.GetComponent<Text>();
		while(t.color.a != endAlpha)
		{
			t.CrossFadeAlpha(endAlpha,time,false);
			yield return null;
		}
		Debug.Log("Fade done!");
	}
	
	/* IEnumerator fadingIn(GameObject obj, float endAlpha, float time)
	{

		Color startColor = obj.transform.GetComponent<Renderer>().material.color;
		float startAlpha = startColor.a;
		
		for(float t=0.0f; t<1.0f; t+= Time.deltaTime/time)
		{
			Color newColor = new Color(startColor.r,startColor.g,startColor.b, Mathf.Lerp(startAlpha,endAlpha,t));
			obj.transform.GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}
	} */
	
	void rotateUp(GameObject obj)
	{
		StartCoroutine(rotatingUp(obj));
	}
	
	
	IEnumerator rotatingUp(GameObject obj)
	{
		yield return new WaitForSeconds(0.6f);
		toAngle.eulerAngles = new Vector3((float)-90, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z);
		while(Mathf.Abs(obj.transform.rotation.eulerAngles.x + 90)>0.05)
		{
			obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, toAngle,(float)0.2);
			yield return null;
		}
		
	}
	
	void raiseUp(GameObject obj)
	{
		StartCoroutine(raisingUp(obj));
	}
	
	
	IEnumerator raisingUp(GameObject obj)
	{
		Vector3 v3 = new Vector3(obj.transform.position.x, 10f, obj.transform.position.z);
		
		Debug.Log("Position = ");
		Debug.Log(obj.transform.position);
		Debug.Log("Distance = ");
		Debug.Log(Vector3.Distance(obj.transform.position, v3));
		yield return new WaitForSeconds(0.6f);
		
		while(Mathf.Abs(Vector3.Distance(obj.transform.position, v3)) >0.01f)
		{
			obj.transform.position = Vector3.Lerp(obj.transform.position, v3,(float)0.2);
			yield return null;
		}
		Debug.Log("Final Distance = ");
		Debug.Log(Mathf.Abs(Vector3.Distance(obj.transform.position, v3)));
		Debug.Log("Reached Position!");
	}
}
