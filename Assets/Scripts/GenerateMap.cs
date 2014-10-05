using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour
{
	// the answer to life, the universe, and everything.
	public int seed = 42;
	public int minRooms = 2;
	public GameObject emptyRoom;
	int currentRoom;
//	public GameObject cornerRoom;
//	public GameObject wallRoom;
//	public GameObject deadEnd;
//	public GameObject hallRoom;
//	public int width;
//	public int length;

	void Awake ()
	{
		// set the seed
		Random.seed = seed;

		// initialize location
		transform.position = new Vector3( 0, 0, 0 );

		// Min ## rooms is 2.
		if ( minRooms < 2 ) { minRooms = 2; }
	}

	void Update ()
	{
		// define our variables!

		// Figure out the sizes of our rooms! Assume all modules are the same width/length.
		float roomWidth = emptyRoom.renderer.bounds.size.x;
		float roomLength = emptyRoom.renderer.bounds.size.z;

		//We need this raycast to find out if the space we want to place our new room is occupied or not.
		RaycastHit hit;
		Ray anyoneHome;

		// current object for renaming and moving around.
		Object current;

		/* Example Room 
		// Fill the corners
		current = Instantiate( cornerRoom, new Vector3 ( roomWidth * width, 0 , 0), Quaternion.Euler ( new Vector3( 0, 270, 0 ) ) );
		current.name = "1";
		current = Instantiate( cornerRoom, new Vector3 ( 0, 0, 0 ), Quaternion.Euler ( new Vector3( 0, 0, 0 ) ) );
		current.name = "2";
		current = Instantiate( cornerRoom, new Vector3 ( 0, 0 , roomLength * length), Quaternion.Euler ( new Vector3( 0, 90, 0 ) ) );
		current.name = "3";
		current = Instantiate( cornerRoom, new Vector3 ( roomWidth * width, 0 , roomLength * length), Quaternion.Euler ( new Vector3( 0, 180, 0 ) ) );
		current.name = "4";



		for (int x = 1; x <= width-1; x++)
		{
			current = Instantiate( wallRoom, new Vector3 (roomWidth * x, 0, 0), Quaternion.Euler (new Vector3( 0, 270, 0)));
			current.name = "bottomwall";
			current = Instantiate( wallRoom, new Vector3 (roomWidth * x, 0, roomLength * length), Quaternion.Euler (new Vector3( 0, 90, 0)));
			current.name = "topwall";
			
			for (int z = 1; z <= length-1; z++)
			{
				current = Instantiate( emptyRoom, new Vector3( x * roomWidth, 0, z * roomLength), Quaternion.identity );
				current.name = "x"+x+"z"+z;
			}
		}
		for (int z = 1; z <= length-1; z++)
		{
		current = Instantiate( wallRoom, new Vector3 (0, 0, roomLength * z), Quaternion.Euler (new Vector3( 0, 0, 0)));
		current.name = "leftwall";
		current = Instantiate( wallRoom, new Vector3 (width * roomWidth, 0, roomLength * z), Quaternion.Euler (new Vector3( 0, 180, 0)));
		current.name = "rightwall";
		} */


		if ( currentRoom < minRooms )
		{
			// We're gonna look down to see if there's a room there.
			anyoneHome = new Ray( new Vector3 ( transform.position.x , transform.position.y + 1, transform.position.z ), Vector3.down );

			// check if something is already here!
			if ( ! Physics.Raycast ( anyoneHome, out hit ) ) 
			{
				// Nothing was hit, so we can put in a new room.
				current = Instantiate ( emptyRoom, transform.position, Quaternion.identity);
				current.name = "Room #"+currentRoom;
				currentRoom += 1;
			}

			// Where to next?

			switch( Random.Range ( 0, 3 ) )
			{
			case 0:
				// north
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + roomLength);

				break;
			case 1:
				// east
				transform.position = new Vector3(transform.position.x + roomWidth, transform.position.y, transform.position.z);

				break;
			case 2:
				// south
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - roomLength);

				break;
			case 3:
				// west
				transform.position = new Vector3(transform.position.x - roomWidth, transform.position.y, transform.position.z);

				break;
			}
		
		if ( currentRoom == minRooms )
			{
				// Kill the generator.
				Destroy(this);
			}

		}
	}


}
