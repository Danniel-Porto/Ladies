using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour {

    public Camera cam;
    GameObject whitePiece;
    GameObject blackPiece;
    public GameObject DefaultWhitePiece, DefaultBlackPiece;
    public Material avaliable, blackDefault, whiteDefault;
    public int wx, wy, bx, by;
    Vector3 offset = new Vector3(0, 0.35f, 0);
    static public int turn;
    GameObject previousPiece = null;
    public static GameObject[] allTiles;
    public static bool clearPieces;



    void Start () {
        turn = 1;
	}
	
	
	void Update () {
        SelectedPieceInfo();
        if(turn == 1)
        {
            LadiesRules.ladiesRules(whitePiece, cam, 2, DefaultWhitePiece, avaliable, wx, wy, +1, +1);
            LadiesRules.ladiesRules(whitePiece, cam, 2, DefaultWhitePiece, avaliable, wx, wy, +1, -1);
        }
        if (turn == 2)
        {
            LadiesRules.ladiesRules(blackPiece, cam, 1, DefaultBlackPiece, avaliable, bx, by, -1, +1);
            LadiesRules.ladiesRules(blackPiece, cam, 1, DefaultBlackPiece, avaliable, bx, by, -1, -1);
        }
    }

    private void ClearAllTiles()
    {
        if (turn == 1 & whitePiece != previousPiece)
        {
            Clear();
            previousPiece = whitePiece;
        }
        if (turn == 1 & whitePiece == null)
        {
            Clear();
        }


    }

    public static void Clear()
    {
        allTiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in allTiles)
        {
            tile.GetComponent<Renderer>().material = tile.GetComponent<TileInfo>().defaultMaterial;
        }
    }

    private void BlackSetAllowedMovesDefaultRules()
    {
        int x = bx;
        int y = by;

        var mousePos = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (blackPiece != null & turn == 2)
        {
            Clear();
            {
                if (x > 1 & y < 8) //avanço superior
                {
                    if (TileManager.field[x - 1, y + 1].GetComponent<TileInfo>().status == 1 & x > 2 & y < 7)
                    {
                        if (TileManager.field[x - 2, y + 2].GetComponent<TileInfo>().status == 0)
                        {
                            TileManager.field[x - 2, y + 2].GetComponent<Renderer>().material = avaliable;

                            if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x - 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                            {
                                Destroy(TileManager.field[x - 1, y + 1].GetComponent<TileInfo>().piece);
                                Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                                GameObject.Instantiate(DefaultBlackPiece, TileManager.field[x - 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                                turn = 1;
                                Clear();
                                clearPieces = true;
                            }
                        }
                    }
                    else if (TileManager.field[x - 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x - 1, y + 1].GetComponent<Renderer>().material = avaliable;

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x - 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(DefaultBlackPiece, TileManager.field[x - 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 1;
                            Clear();
                            clearPieces = true;
                        }
                    }
                }


                if (x > 1 & y > 1) //avanço inferior
                {
                    if (TileManager.field[x - 1, y - 1].GetComponent<TileInfo>().status == 1 & x > 2 & y > 2)
                    {
                        if (TileManager.field[x - 2, y - 2].GetComponent<TileInfo>().status == 0)
                        {
                            TileManager.field[x - 2, y - 2].GetComponent<Renderer>().material = avaliable;

                            if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x - 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                            {
                                Destroy(TileManager.field[x - 1, y - 1].GetComponent<TileInfo>().piece);
                                Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                                GameObject.Instantiate(DefaultBlackPiece, TileManager.field[x - 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                                turn = 1;
                                Clear();
                                clearPieces = true;
                            }
                        }
                    }
                    else if (TileManager.field[x - 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x - 1, y - 1].GetComponent<Renderer>().material = avaliable;

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x - 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(DefaultBlackPiece, TileManager.field[x - 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 1;
                            Clear();
                            clearPieces = true;
                        }
                    }
                }
            }
        }
    }

    private void WhiteSetAllowedMovesDefaultRules()
    {
        int x = wx;
        int y = wy;

        var mousePos = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (whitePiece != null & turn == 1)
            Clear();
        {
            //If ladies only
            /*
            if (whitePiece.GetComponent<PiecePosition>().isLady == true & whitePiece != null)
            {

            }
            //If not ladies
            else */
            {
                if (x < 8 & y < 8) //avanço superior
                {
                    if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 2 & x < 7 & y < 7)
                    {
                        if (TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().status == 0)
                        {
                            TileManager.field[x + 2, y + 2].GetComponent<Renderer>().material = avaliable;

                            if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                            {
                                Destroy(TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().piece);
                                Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                                GameObject.Instantiate(DefaultWhitePiece, TileManager.field[x + 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                                turn = 2;
                                Clear();
                                clearPieces = true;
                            }
                        }
                    }
                    else if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y + 1].GetComponent<Renderer>().material = avaliable;

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(DefaultWhitePiece, TileManager.field[x + 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 2;
                            Clear();
                            clearPieces = true;
                        }
                    }
                }

                if (x < 8 & y > 1) //avanço inferior
                {
                    if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 2 & x < 7 & y > 2)
                    {
                        if (TileManager.field[x + 2, y - 2].GetComponent<TileInfo>().status == 0)
                        {
                            TileManager.field[x + 2, y - 2].GetComponent<Renderer>().material = avaliable;

                            if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                            {
                                Destroy(TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().piece);
                                Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                                GameObject.Instantiate(DefaultWhitePiece, TileManager.field[x + 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                                turn = 2;
                                Clear();
                                clearPieces = true;
                            }
                        }
                    }
                    else if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y - 1].GetComponent<Renderer>().material = avaliable;
                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {

                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(DefaultWhitePiece, TileManager.field[x + 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 2;
                            Clear();
                            clearPieces = true;
                        }
                    }
                }
            }
        } 
    }

    private void SelectedPieceInfo()
    {
        if (WhitePieceSelector.chosenPiece != null)
        {
            whitePiece = WhitePieceSelector.chosenPiece;
            wx = whitePiece.GetComponent<PiecePosition>().tile.GetComponent<TileInfo>().x;
            wy = whitePiece.GetComponent<PiecePosition>().tile.GetComponent<TileInfo>().y;
        } else if (WhitePieceSelector.chosenPiece == null)
        {
            wx = wy = 0;
        }

        if (BlackPieceSelector.chosenPiece != null)
        {
            blackPiece = BlackPieceSelector.chosenPiece;
            bx = blackPiece.GetComponent<PiecePosition>().tile.GetComponent<TileInfo>().x;
            by = blackPiece.GetComponent<PiecePosition>().tile.GetComponent<TileInfo>().y;
        }
        else if (BlackPieceSelector.chosenPiece == null)
        {
            bx = by = 0;
        }

    }
}
