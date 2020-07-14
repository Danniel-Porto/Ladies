using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour {

    public int x;
    public int y;
    public int status;
    public Material defaultMaterial;
    public GameObject piece;

    void OnTriggerEnter(Collider collider)
    {
        piece = collider.gameObject;
    }

    void OnTriggerExit(Collider collider)
    {
        piece = null;
    }

    void Update()
    {
        if (piece != null)
        {
            if (piece.tag == "WhitePiece")
            {
                status = 1;
            }
            if (piece.tag == "BlackPiece")
            {
                status = 2;
            }
        }
        if (piece == null)
        {
            status = 0;
        }
    }

}
