using UnityEngine;
using System.Collections;

public class cube2sphere : MonoBehaviour 
{
	public float radius = 5.0f;

	void Start () 
	{
		
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		
		for (var i=0; i<vertices.Length; i++) 
		{
			
			vertices[i] = vertices[i].normalized*radius;
			
		}
		
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
		mesh.RecalculateBounds ();
		
	}

}
