using UnityEngine;
using System.Collections;

public class SlidesController : MonoBehaviour {


	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
/* 	// Display panels for slide No i
	void displayPanels(int i)
	{
		if(i == 1)
		{
			GameObject house = GameObject.Find("Slide1/HouseCollider");
			rotateUp(house);
		}
	}
	
	void rotateUp(GameObject obj)
	{
		StartCoroutine(rotating(obj));
	}
	
	
	IEnumerator rotatingUp(GameObject obj)
	{
		while(Mathf.Abs(obj.transform.rotation.eulerAngles.x + 90)>0.05)
		{
			obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation.eulerAngles.x, 90,(float)0.2);
			yield return null;
		}
		
	} */
}
