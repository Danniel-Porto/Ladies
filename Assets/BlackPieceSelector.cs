﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPieceSelector : MonoBehaviour
{
    public Camera cam;
    public Material selectedMaterial;
    public Material unselectedMaterial;
    public Material softSelectMaterial;
    public static GameObject chosenPiece;
    public GameObject[] allPieces;
    GameObject selectedPiece;
    GameObject previousPiece;
    GameObject hoveredPiece;

    void Start()
    {

    }

    void Update()
    {
        ClearPieces();

        if (FieldManager.turn == 2)
        {
            PieceSelect();
            PieceHover();
        }
        else
        {
            //CleanBlacks();
        }
    }

    private void ClearPieces()
    {
        if (FieldManager.clearPieces == true)
        {
            if (selectedPiece != null)
            {
                selectedPiece.GetComponent<Renderer>().material = unselectedMaterial;
            }
            if (previousPiece != null)
            {
                previousPiece.GetComponent<Renderer>().material = unselectedMaterial;
            }
            chosenPiece = null;
            previousPiece = null;
            selectedPiece = null;

            allPieces = GameObject.FindGameObjectsWithTag("BlackPiece");
            foreach (GameObject piece in allPieces)
            {
                piece.GetComponent<Renderer>().material = unselectedMaterial;
            }

            FieldManager.clearPieces = false;
        }
    }

    /*private void CleanBlacks()
    {
        GameObject.FindWithTag("BlackPiece").GetComponent<Renderer>().material = unselectedMaterial;
    }*/

    private void PieceHover()
    {
        var mousePos = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mousePos, out hit, 100))
        {
            if (hit.collider.tag == "BlackPiece" & hit.collider.GetComponent<Renderer>().sharedMaterial == unselectedMaterial & hit.collider.gameObject != selectedPiece)
            {
                hoveredPiece = hit.collider.gameObject;
                hoveredPiece.GetComponent<Renderer>().material = softSelectMaterial;
            }
            else if (hit.collider.tag != "BlackPiece" & hit.collider.gameObject != selectedPiece & hoveredPiece != selectedPiece & hoveredPiece != null)
            {
                hoveredPiece.GetComponent<Renderer>().material = unselectedMaterial;
            }
        }
    }

    private void PieceSelect()
    {
        if (selectedPiece != null)
        {
            if (selectedPiece.GetComponent<Renderer>().sharedMaterial != selectedMaterial)
            {
                chosenPiece = null;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(mousePos, out hit, 100))
            {

                if (hit.collider.tag == "BlackPiece" & previousPiece != selectedPiece)
                {
                    previousPiece = selectedPiece;
                    selectedPiece = hit.collider.gameObject;
                    chosenPiece = selectedPiece;
                    selectedPiece.GetComponent<Renderer>().material = selectedMaterial;
                    previousPiece.GetComponent<Renderer>().material = unselectedMaterial;
                }
                else if (hit.collider.tag == "BlackPiece" & previousPiece == selectedPiece)
                {
                    previousPiece = null;
                    selectedPiece = hit.collider.gameObject;
                    chosenPiece = selectedPiece;
                    selectedPiece.GetComponent<Renderer>().material = selectedMaterial;
                }
            }

        }
    }
}