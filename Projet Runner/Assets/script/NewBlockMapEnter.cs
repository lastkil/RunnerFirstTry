using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlockMapEnter : MonoBehaviour {
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MapGeneration.RemoveMapAfterPassOf(transform.parent.name);
        }
    }
}
