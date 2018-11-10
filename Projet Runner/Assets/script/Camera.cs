using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject Player;
    private Vector3 CameraOffSet;
    private Quaternion rotation;
    public float cameraX = 0.0f;
    public float cameraY = 0.0f;
    public float cameraZ = 0.0f;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        CameraOffSet = new Vector3(cameraX, cameraY, cameraZ); // Permet de régler la distance par rapport au player, valeurs modifiables en dehors du script
        transform.eulerAngles = -GameObject.Find("couloir boite").transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
