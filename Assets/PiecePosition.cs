using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePosition : MonoBehaviour {

    public GameObject tile;
    public bool isLady;

    void OnTriggerEnter(Collider collider)
    {
        tile = collider.gameObject;
    }
}
