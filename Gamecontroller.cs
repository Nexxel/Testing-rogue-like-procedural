using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroller : MonoBehaviour {
	public int initialI = 0;
	public int initialJ = 0;
	public int lastI = 40;
	public int lastJ = 40;
    [Range(0, 5)]
    public int numRooms;
	public GameObject wall;

	private Rooms[] rooms;

	// Use this for initialization
	void Start () {
        rooms = new Rooms[numRooms];
		for (int i = initialI; i < lastI; i++) {
			for (int j = initialJ; j < lastJ; j++) {
				Instantiate (wall,new Vector2 (i,j),Quaternion.identity);
			}
		}
		Vector2 init = new Vector2(Random.Range (initialI+1,lastI-1),Random.Range (initialJ+1,lastJ-1));
        Rooms newR = GetComponent<Rooms>();
		newR.createRoom ((int)Random.Range (1,lastI-init.x),(int)Random.Range (1,lastJ-init.y),init);
        rooms.SetValue(newR, 0);
	}
}
