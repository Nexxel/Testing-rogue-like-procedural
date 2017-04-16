using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour {


	public GameObject[] elements;

    private GameObject roomController;
    private int _firstI, _firstJ, _lastI, _lastJ;

    private bool[,] occupied;
    private Gamecontroller aux;

    public void createRoom (int width, int height, Vector2 first)
	{
        occupied = Gamecontroller.occupiedPositions;
        aux = GetComponent<Gamecontroller>();
		_firstI = (int)first.x;
		_firstJ = (int)first.y;
		_lastI = _firstI + width;
		_lastJ = _firstJ + height;
        bool ok = true;
        int i = _firstI;
		while(ok && i< _lastI) {
            int j = _firstJ;
			while (ok && j < _lastJ) {
                if(occupied[i-aux.initialI,j-aux.initialJ])
                {
				    
                    ok = false;
                }
                j++;
			}
            i++;
		}
        if (!ok)
        {
            roomController = null;
        }else
        {
            roomController = new GameObject();
            roomController.name = "Room\tInit: " + _firstI;
            for (int x = _firstI; x < _lastI; x++)
            {
                for (int y = _firstJ; y < _lastJ; y++)
                {
                    GameObject newRoom = Instantiate(elements[Random.Range(0, elements.Length)], new Vector3(i, j, 0), Quaternion.identity);
                    newRoom.transform.SetParent(roomController.transform);
                }
            }
           
            for (int x = _firstI-1; x < _lastI+1; x++)
            {
                for(int y = _firstJ-1; y < _lastJ+1; y++)
                {
                    occupied[x-aux.initialI,y-aux.initialJ] = true;
                }
            }
        }
	}

    public int getFirstI()
    {
        return _firstI;
    }

    public int getLastI()
    {
        return _lastI;
    }

    public int getFirstJ()
    {
        return _firstJ;
    }

    public int getLastJ()
    {
        return _lastJ;
    }

    public GameObject getRoomController()
    {
        return roomController;
    }
}
