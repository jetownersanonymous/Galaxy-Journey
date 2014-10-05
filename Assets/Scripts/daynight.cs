using UnityEngine;
using System.Collections;

public class daynight : MonoBehaviour 
{
	public float speed = 1.0f;

	// Update is called once per frame
	void Update () 
	{
	
		transform.Rotate (new Vector3 ( Time.deltaTime * speed, 0, 0));


	}
}
