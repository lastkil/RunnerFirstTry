using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove1 : MonoBehaviour {

    public float _speed;
    public float _scoreStep;

    private float _ajoutscore;

    // Use this for initialization
    void Start () {
        _ajoutscore = _scoreStep;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 vector = new Vector3();
        vector.y = 0;
        vector.x = 0;
        vector.z = 1;
        transform.Translate(vector * _speed * Time.deltaTime, Space.World);
    }

    void FixedUpdate()
    {
        if(Time.time > _ajoutscore)
        {
            _ajoutscore = Time.time + _scoreStep;
            Scoring.MoveScore();
        }
    }
}
