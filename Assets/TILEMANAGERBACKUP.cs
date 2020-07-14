using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TILEMANAGERBACKUP : MonoBehaviour
{
    public Camera cam;
    GameObject whitePiece;
    GameObject blackPiece;
    public Material avaliable;
    public Material blackTile;
    public int wx, wy, bx, by;
    Vector3 offset = new Vector3(0, 0.35f, 0);
    static public int turn;
    GameObject[] previous = new GameObject[4];
    GameObject previousPiece = null;

    //NOTA!!!!!! verifique as coordenadas de recuo das damas, ta tudo errado!!!!

    void Start()
    {
        turn = 1;
    }


    void Update()
    {
        SelectedPieceInfo();
        WhiteSetAllowedMovesDefaultRules();
        BlackSetAllowedMovesDefaultRules();
    }

    private void BlackSetAllowedMovesDefaultRules()
    {
        int x = wx;
        int y = wy;

        var mousePos = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (blackPiece != null & turn == 2)
        {
            if (previousPiece != blackPiece)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (previous[i] != null)
                    {
                        previous[i].GetComponent<Renderer>().material = blackTile;
                    }
                }
            }
            previousPiece = blackPiece;

            //If ladies only
            if (blackPiece.GetComponent<PiecePosition>().isLady == true)
            {
                if (x < 8 & y < 8) //avanço superior
                {
                    print("avanco superior permitido");
                    if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 2 & x < 7 & y < 7 & TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y + 2].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 2, y + 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;
                        }
                    }
                    else if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y + 1].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 1, y + 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco superior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;
                        }
                    }
                }


                if (x < 8 & y > 1) //avanço inferior
                {
                    print("avanco inferior permitido");
                    if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 2 & x < 7 & y > 2 & TileManager.field[x + 2, y - 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y - 2].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 2, y - 1];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;
                        }
                    }
                    else if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y - 1].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 1, y - 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco inferior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;
                        }
                    }
                }

                if (x < 8 & y < 8) //recuo superior
                {
                    print("avanco superior permitido");
                    if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 2 & x < 7 & y < 7 & TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y + 2].GetComponent<Renderer>().material = avaliable;
                        previous[2] = TileManager.field[x + 2, y + 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;

                        }
                    }
                    else if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y + 1].GetComponent<Renderer>().material = avaliable;
                        previous[2] = TileManager.field[x + 1, y + 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco superior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;
                        }
                    }
                }


                if (x < 8 & y > 1) //recuo inferior
                {
                    print("avanco inferior permitido");
                    if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 2 & x < 7 & y > 2 & TileManager.field[x + 2, y - 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y - 2].GetComponent<Renderer>().material = avaliable;
                        previous[3] = TileManager.field[x + 2, y - 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;
                        }
                    }
                    else if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y - 1].GetComponent<Renderer>().material = avaliable;
                        previous[3] = TileManager.field[x + 1, y - 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco inferior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 1;
                        }
                    }
                }



            }
            //If not ladies
            else
            {
                if (x < 8 & y < 8) //avanço superior
                {
                    print("avanco superior permitido");
                    if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 2 & x < 7 & y < 7) //comer peça preta
                    {
                        TileManager.field[x + 2, y + 2].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 2, y + 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 1;
                        }
                    }
                    else if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y + 1].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 1, y + 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco superior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 1;
                        }
                    }
                }


                if (x < 8 & y > 1) //avanço inferior
                {
                    print("avanco inferior permitido");
                    if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 2 & x < 7 & y > 2) //comer peça preta
                    {
                        TileManager.field[x + 2, y - 2].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 2, y - 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 1;
                        }
                    }
                    else if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y - 1].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 1, y - 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco inferior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(blackPiece, TileManager.field[x + 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 1;
                        }
                    }
                }
            }
        }

        if (blackPiece == null & turn == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (previous[i] != null)
                {
                    previous[i].GetComponent<Renderer>().material = blackTile;
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
        {
            if (previousPiece != whitePiece)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (previous[i] != null)
                    {
                        previous[i].GetComponent<Renderer>().material = blackTile;
                    }
                }
            }
            previousPiece = whitePiece;

            //If ladies only
            if (whitePiece.GetComponent<PiecePosition>().isLady == true)
            {
                if (x < 8 & y < 8) //avanço superior
                {
                    print("avanco superior permitido");
                    if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 2 & x < 7 & y < 7 & TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y + 2].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 2, y + 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;
                        }
                    }
                    else if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y + 1].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 1, y + 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco superior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;
                        }
                    }
                }


                if (x < 8 & y > 1) //avanço inferior
                {
                    print("avanco inferior permitido");
                    if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 2 & x < 7 & y > 2 & TileManager.field[x + 2, y - 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y - 2].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 2, y - 1];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;
                        }
                    }
                    else if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y - 1].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 1, y - 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco inferior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;
                        }
                    }
                }

                if (x < 8 & y < 8) //recuo superior
                {
                    print("avanco superior permitido");
                    if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 2 & x < 7 & y < 7 & TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y + 2].GetComponent<Renderer>().material = avaliable;
                        previous[2] = TileManager.field[x + 2, y + 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;

                        }
                    }
                    else if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y + 1].GetComponent<Renderer>().material = avaliable;
                        previous[2] = TileManager.field[x + 1, y + 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco superior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;
                        }
                    }
                }


                if (x < 8 & y > 1) //recuo inferior
                {
                    print("avanco inferior permitido");
                    if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 2 & x < 7 & y > 2 & TileManager.field[x + 2, y - 2].GetComponent<TileInfo>().status == 0) //comer peça preta
                    {
                        TileManager.field[x + 2, y - 2].GetComponent<Renderer>().material = avaliable;
                        previous[3] = TileManager.field[x + 2, y - 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;
                        }
                    }
                    else if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y - 1].GetComponent<Renderer>().material = avaliable;
                        previous[3] = TileManager.field[x + 1, y - 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco inferior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            TileManager.field[x + 2, y + 2].GetComponent<TileInfo>().piece.GetComponent<PiecePosition>().isLady = true;
                            turn = 2;
                        }
                    }
                }



            }
            //If not ladies
            else
            {
                if (x < 8 & y < 8) //avanço superior
                {
                    print("avanco superior permitido");
                    if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 2 & x < 7 & y < 7) //comer peça preta
                    {
                        TileManager.field[x + 2, y + 2].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 2, y + 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y + 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 2, y + 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 2;
                        }
                    }
                    else if (TileManager.field[x + 1, y + 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y + 1].GetComponent<Renderer>().material = avaliable;
                        previous[0] = TileManager.field[x + 1, y + 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco superior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y + 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 1, y + 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 2;
                        }
                    }
                }


                if (x < 8 & y > 1) //avanço inferior
                {
                    print("avanco inferior permitido");
                    if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 2 & x < 7 & y > 2) //comer peça preta
                    {
                        TileManager.field[x + 2, y - 2].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 2, y - 2];

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 2, y - 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().piece);
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 2, y - 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 2;
                        }
                    }
                    else if (TileManager.field[x + 1, y - 1].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + 1, y - 1].GetComponent<Renderer>().material = avaliable;
                        previous[1] = TileManager.field[x + 1, y - 1];
                        print(TileManager.field[x + 1, y - 1]);
                        print("possivel mover avanco inferior");

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + 1, y - 1] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(whitePiece, TileManager.field[x + 1, y - 1].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            turn = 2;
                        }
                    }
                }
            }
        }

        if (whitePiece == null & turn == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (previous[i] != null)
                {
                    previous[i].GetComponent<Renderer>().material = blackTile;
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
        }
        else if (WhitePieceSelector.chosenPiece == null)
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
