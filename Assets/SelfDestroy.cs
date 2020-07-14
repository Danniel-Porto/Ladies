using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {
    public Camera cam;
    public Material selectedMaterial;
    public Material unselectedMaterial;
    Renderer pieceRenderer;
    bool selected = false;

    void Start () {
        pieceRenderer = GetComponent<Renderer>();
	}
	
	void Update () {
        Select();
	}

    private void Select()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (Physics.Raycast(mousePos, out hit, 100))
            {
                
                if (hit.collider.tag == "Piece" & selected == false)
                {
                    pieceRenderer.material = selectedMaterial;
                    selected = true;
                } else if (hit.collider.tag == "Piece")
                {
                    pieceRenderer.material = unselectedMaterial;
                    selected = false;
                }
            }

        }
    }
}
