using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour {


	public GameObject free;

    private int _firstI, _firstJ, _lastI, _lastJ;

    public void createRoom (int width, int height, Vector2 first)
	{
		_firstI = (int)first.x;
		_firstJ = (int)first.y;
		_lastI = _firstI + width;
		_lastJ = _firstJ + height;
		for (int i = _firstI; i < _lastI; i++) {
			for (int j = _firstJ; j < _lastJ; j++) {
				Instantiate (free,new Vector3 (i,j,-1),Quaternion.identity);
			}
		}
	}
}
