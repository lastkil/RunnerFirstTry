using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {


    public float _VitesseStep;
    public float _VitesseToAdd;
    
    private float _ajoutVitesse;

    // Use this for initialization
    void Start ()
    {
        _ajoutVitesse = _VitesseStep;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > _ajoutVitesse)
        {
            Time.timeScale += _VitesseToAdd;
           _ajoutVitesse = Time.time + _VitesseStep;
        }
    }
}
