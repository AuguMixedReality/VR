using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Vector3[] pos;

	GameObject cam;

	// Use this for initialization
	void Start () {
		Debug.Log("Game Start");
//		camPositions[0] = (13,15,-1000);

		cam = GameObject.Find("Cardboard Main");

		pos = new[] {new Vector3( 13, 11, -950 ),
			new Vector3 (13, 11, -450 )};
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Fire Clicked!");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit;

			if(Physics.Raycast(ray, out rayHit)){
				Debug.Log(rayHit.transform.name);
				if(rayHit.transform.name == "Enter Tour"){
					Debug.Log("Enter Tour hit!");
					cam.transform.position = Vector3.Lerp(this.transform.position, pos[1],(float)0.2);
				}

			}
		}


	}
}
