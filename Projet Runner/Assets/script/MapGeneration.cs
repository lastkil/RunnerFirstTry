using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public GameObject _piece;
    public GameObject _couloir;
    public Transform _transform;
    public int _limitSpawn;
    public List<GameObject> _pieces;
    public List<GameObject> _couloirs;
    public int _maxCouiloirConsecutif;
    public int _pieceSpawnChanceOn100; //valeur de spawn sur 100

    private BoxCollider _PieceCollider;
    private BoxCollider _CouloirCollider;
    private Transform _positionToSpawn;
    private int _CouloirConsecutif;
    private bool _LastSpawnIsCouloir = false;
    private int numberOfItemSpawn;

    private static int _nbSpawn;
    private static Dictionary<string, GameObject> CreatedBlocMap;
    private static string CurrentMap;
    private static string previousMap;


    void Start()
    {
        _PieceCollider = _piece.GetComponent<BoxCollider>();
        _PieceCollider.size = new Vector3(0, 0, _PieceCollider.size.z);

        _CouloirCollider = _couloir.GetComponent<BoxCollider>();
        _CouloirCollider.size = new Vector3(0, 0, _CouloirCollider.size.z);

        _positionToSpawn = transform;

        CreatedBlocMap = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    public void FixedUpdate () {
		if(_nbSpawn < _limitSpawn)
        {
            if(!_LastSpawnIsCouloir)
            {
                SpawnCouloir();
            }
            else if(_CouloirConsecutif < _maxCouiloirConsecutif)
            {
                SelectSpawnItem();
            }
            else
            {
                SpawnPiece();
            }
        }
	}

    public static void RemoveMapAfterPassOf(string mapInstance)
    {
        if (previousMap != null && CreatedBlocMap.ContainsKey(previousMap))
        {
            Destroy(CreatedBlocMap[previousMap]);
            _nbSpawn--;
        }
        if(CurrentMap != null)
        {
            previousMap = CurrentMap;
        }
        CurrentMap = mapInstance;
    }
    
    private void SpawnPiece()
    {
        SpawnGameObject(_pieces, _PieceCollider.size);
        _LastSpawnIsCouloir = false;
        _CouloirConsecutif = 0;
    }
    private void SpawnCouloir()
    {
        SpawnGameObject(_couloirs, _CouloirCollider.size);
        _LastSpawnIsCouloir = true;
        _CouloirConsecutif++;
    }
    private void SpawnGameObject(List<GameObject> gameObjects, Vector3 GameobjectSize)
    {
        _nbSpawn++;
        int index = Random.Range(0, gameObjects.Count);
        GameObject piece = (GameObject)Instantiate(gameObjects[index], _positionToSpawn.position, Quaternion.identity);
        piece.name = numberOfItemSpawn.ToString();
        CreatedBlocMap.Add(numberOfItemSpawn.ToString(), piece);

        numberOfItemSpawn++;
        _positionToSpawn.position += GameobjectSize;
    }

    private void SelectSpawnItem()
    {
        int RandomValue = Random.Range(0, 99);
        if (_pieceSpawnChanceOn100 > RandomValue)
        {
            SpawnPiece();
        }
        else
        {
            SpawnCouloir();
        }
    }
}
