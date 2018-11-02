using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public GameObject _piece;
    public Transform _transform;
    public int _limitSpawn;

    private int _nbSpawn;
    private BoxCollider _Collider;
    private Transform _positionToSpawn;


    void Start()
    {
        _Collider = _piece.GetComponent<BoxCollider>();
        _Collider.size = new Vector3(0, 0, _Collider.size.z);
        _positionToSpawn = transform;
    }

    // Update is called once per frame
    public void FixedUpdate () {
		if(_nbSpawn < _limitSpawn)
        {
            SpawnPiece();
        }
	}
    
    private void SpawnPiece()
    {
        _nbSpawn++;
        GameObject piece = (GameObject)Instantiate(_piece, _positionToSpawn.position, Quaternion.identity);
        _positionToSpawn.position += _Collider.size;
    }
}
