using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour
{
	public GameObject emptyRoom;
	//public GameObject cornerRoom;
	//public GameObject wallRoom;
	public int width;
	public int length;


	void Awake ()
	{
		float emptyRoomWidth = emptyRoom.renderer.bounds.size.x;
		float emptyRoomLength = emptyRoom.renderer.bounds.size.z;
		//float cornerRoomWidth = cornerRoom.renderer.bounds.size.x;
		//float cornerRoomLength = cornerRoom.renderer.bounds.size.z;
		//float wallRoomWidth = wallRoom.renderer.bounds.size.x;
		//float wallRoomLength = wallRoom.renderer.bounds.size.z;


		for (int x = 0; x < width; x++)
		{
			for (int z = 0; z < length; z++)
			{
				Instantiate(emptyRoom, new Vector3( x * emptyRoomWidth, 0, z * emptyRoomLength), Quaternion.identity);
			}
		}
	}
}
