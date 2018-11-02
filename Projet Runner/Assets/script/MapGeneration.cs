using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public GameObject _piece;
    public Transform _transform;
    public int _limitSpawn;

    private int _nbSpawn;

    // Update is called once per frame
    public void Update () {
		if(_nbSpawn < _limitSpawn)
        {
            SpawnPiece();
        }
	}
    
    private void SpawnPiece()
    {
        GameObject piece = (GameObject)Instantiate(_piece, _transform);
        _nbSpawn++;
    }
}
