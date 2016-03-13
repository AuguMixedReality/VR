using UnityEngine;
using System.Collections;

public class MLK1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")){
			transform.Translate(new Vector3(0f,0f,-10f));
		}
	}
}
