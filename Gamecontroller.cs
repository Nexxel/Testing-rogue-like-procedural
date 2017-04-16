using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroller : MonoBehaviour {
	public int initialI = 0;
	public int initialJ = 0;
	public int lastI = 40;
	public int lastJ = 40;
    [Range(1, 10)]
    public int tries = 1;
    [Range(1, 20)]
    public int numRooms = 1;
	public GameObject wall;

    public static bool[ , ] occupiedPositions; //False -> Not ocuppied

    private GameObject wallController;
	private Rooms[] rooms;

	// Use this for initialization
	void Start () {
        occupiedPositions = new bool[lastI - initialI+1, lastJ - initialJ+1];
        wallController = new GameObject();
        wallController.name = "Wall";
        rooms = new Rooms[numRooms];
        for (int i = initialI; i <= lastI; i++) {
			for (int j = initialJ; j <= lastJ; j++) {
                if(i == initialI || i == lastI || j == initialJ || j == lastJ)
                {
				    GameObject newWall = Instantiate (wall,new Vector2 (i,j),Quaternion.identity);
                    newWall.transform.SetParent(wallController.transform);
                    occupiedPositions[i-initialI,j-initialJ] = true;
                }
			}
		}
        for(int i = 0; i<numRooms; i++)
        {
		    Vector2 init = new Vector2(Random.Range (initialI+1,lastI-1),Random.Range (initialJ+1,lastJ-1));
            Rooms newR = GetComponent<Rooms>();
		    newR.createRoom ((int)Random.Range (2,lastI-init.x),(int)Random.Range (2,lastJ-init.y),init);
            int counter = 0;
            while (newR.getRoomController() == null && counter<tries)
            {
                init = new Vector2(Random.Range(initialI + 1, lastI - 1), Random.Range(initialJ + 1, lastJ - 1));
                newR.createRoom((int)Random.Range(2, lastI - init.x), (int)Random.Range(2, lastJ - init.y), init);
                counter++;
            }
            rooms.SetValue(newR, i);
        }
	}

    public Rooms[] getRooms()
    {
        return rooms;
    } 
}
