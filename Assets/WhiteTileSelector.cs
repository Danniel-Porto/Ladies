using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteTileSelector : MonoBehaviour
{

    public Camera cam;
    public Material avaliableMaterial;
    public Material softSelectMaterial;
    public Material unselectedMaterial;
    public GameObject chosenTile;
    GameObject previousPiece;
    GameObject hoveredPiece;

    void Start()
    {

    }

    void Update()
    {
        TileHover();
    }

    private void TileHover()
    {
        var mousePos = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mousePos, out hit, 100))
        {
            if (Input.GetMouseButtonDown(0) & hoveredPiece == hit.collider.gameObject & hit.collider.tag == "Tile")
            {
                chosenTile = hoveredPiece;
            }
                if (hit.collider.tag == "Tile" & hit.collider.GetComponent<Renderer>().sharedMaterial == avaliableMaterial)
            {
                hoveredPiece = hit.collider.gameObject;
                hoveredPiece.GetComponent<Renderer>().material = softSelectMaterial;
            }
            else if (hit.collider.tag == "Tile" & hoveredPiece != null  & hit.collider.GetComponent<Renderer>().sharedMaterial != avaliableMaterial)
            {
                hoveredPiece.GetComponent<Renderer>().material = avaliableMaterial;
            }
        }
    }
}
