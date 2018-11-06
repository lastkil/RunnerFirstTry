using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text _TxtScore;

    private static int score;

	// Use this for initialization
	void Start () {
        score = 0;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        _TxtScore.text = string.Format("Scores : {0}", score);
    }

    public static void PieceCapture()
    {
        score += 100;
    }
    public static void MoveScore()
    {
        score += 10;
    }
}
