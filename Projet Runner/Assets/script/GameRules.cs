using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {


    public float _VitesseStep;
    public float _VitesseToAdd;
    public float _vitesseMax = 2.5f;
    
    private float _ajoutVitesse;
    private static float SpeedBeforePause;

    // Use this for initialization
    void Start ()
    {
        _ajoutVitesse = _VitesseStep;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > _ajoutVitesse && Time.timeScale < _vitesseMax)
        {
            Time.timeScale += _VitesseToAdd;
           _ajoutVitesse = Time.time + _VitesseStep;
        }
    }

    public static void Pause()
    {
        SpeedBeforePause = Time.timeScale;
        Time.timeScale = 0;
    }
    public static void Play()
    {
        Time.timeScale = SpeedBeforePause;
    }
}
