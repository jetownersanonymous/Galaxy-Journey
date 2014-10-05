using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour
{
	// the answer to life, the universe, and everything.
	//public int seed = 42;
	public GameObject emptyRoom;
	public GameObject cornerRoom;
	public GameObject wallRoom;
	public int width;
	public int length;


	void Awake ()
	{
		// sets the seed.
		//Random.seed = seed;

		// Figure out the sizes of our rooms!
		float emptyRoomWidth = emptyRoom.renderer.bounds.size.x;
		float emptyRoomLength = emptyRoom.renderer.bounds.size.z;
		float cornerRoomWidth = cornerRoom.renderer.bounds.size.x;
		float cornerRoomLength = cornerRoom.renderer.bounds.size.z;
		float wallRoomWidth = wallRoom.renderer.bounds.size.x;
		float wallRoomLength = wallRoom.renderer.bounds.size.z;
		Object current;


		// Fill the corners
		current = Instantiate( cornerRoom, new Vector3 ( cornerRoomWidth * width, 0 , 0), Quaternion.Euler ( new Vector3( 0, 270, 0 ) ) );
		current.name = "1";
		current = Instantiate( cornerRoom, new Vector3 ( 0, 0, 0 ), Quaternion.Euler ( new Vector3( 0, 0, 0 ) ) );
		current.name = "2";
		current = Instantiate( cornerRoom, new Vector3 ( 0, 0 , cornerRoomLength * length), Quaternion.Euler ( new Vector3( 0, 90, 0 ) ) );
		current.name = "3";
		current = Instantiate( cornerRoom, new Vector3 ( cornerRoomWidth * width, 0 , cornerRoomLength * length), Quaternion.Euler ( new Vector3( 0, 180, 0 ) ) );
		current.name = "4";



		for (int x = 1; x <= width-1; x++)
		{
			current = Instantiate( wallRoom, new Vector3 (wallRoomWidth * x, 0, 0), Quaternion.Euler (new Vector3( 0, 270, 0)));
			current.name = "bottomwall";
			current = Instantiate( wallRoom, new Vector3 (wallRoomWidth * x, 0, wallRoomLength * length), Quaternion.Euler (new Vector3( 0, 90, 0)));
			current.name = "topwall";
			
			for (int z = 1; z <= length-1; z++)
			{
				current = Instantiate( emptyRoom, new Vector3( x * emptyRoomWidth, 0, z * emptyRoomLength), Quaternion.identity );
				current.name = "x"+x+"z"+z;
			}
		}
		for (int z = 1; z <= length-1; z++)
		{
		current = Instantiate( wallRoom, new Vector3 (0, 0, wallRoomLength * z), Quaternion.Euler (new Vector3( 0, 0, 0)));
		current.name = "leftwall";
		current = Instantiate( wallRoom, new Vector3 (width * wallRoomWidth, 0, wallRoomLength * z), Quaternion.Euler (new Vector3( 0, 180, 0)));
		current.name = "rightwall";
		}

	}
}
