
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    
    public GameObject pieceWhite;
    public GameObject pieceBlack;
    public static GameObject[,] field = new GameObject[11, 11];
    Vector3 offset = new Vector3(0, 0.35f, 0);


	void Start () {

        SetFieldTiles();
        DefaultRulesSpawn();

    }

    void Update () {
		
	}



    private void DefaultRulesSpawn()
    {
        GameObject.Instantiate(pieceWhite, field[1, 1].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[1, 3].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[1, 5].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[1, 7].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[2, 2].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[2, 4].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[2, 6].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[2, 8].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[3, 1].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[3, 3].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[3, 5].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceWhite, field[3, 7].transform.position + offset, field[1, 1].transform.rotation);
        field[1, 1].GetComponent<TileInfo>().status = 1;
        field[1, 3].GetComponent<TileInfo>().status = 1;
        field[1, 5].GetComponent<TileInfo>().status = 1;
        field[1, 7].GetComponent<TileInfo>().status = 1;
        field[2, 2].GetComponent<TileInfo>().status = 1;
        field[2, 4].GetComponent<TileInfo>().status = 1;
        field[2, 6].GetComponent<TileInfo>().status = 1;
        field[2, 8].GetComponent<TileInfo>().status = 1;
        field[3, 1].GetComponent<TileInfo>().status = 1;
        field[3, 3].GetComponent<TileInfo>().status = 1;
        field[3, 5].GetComponent<TileInfo>().status = 1;
        field[3, 7].GetComponent<TileInfo>().status = 1;

        GameObject.Instantiate(pieceBlack, field[6, 2].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[6, 4].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[6, 6].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[6, 8].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[7, 1].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[7, 3].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[7, 5].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[7, 7].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[8, 2].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[8, 4].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[8, 6].transform.position + offset, field[1, 1].transform.rotation);
        GameObject.Instantiate(pieceBlack, field[8, 8].transform.position + offset, field[1, 1].transform.rotation);
        field[6, 2].GetComponent<TileInfo>().status = 2;
        field[6, 4].GetComponent<TileInfo>().status = 2;
        field[6, 6].GetComponent<TileInfo>().status = 2;
        field[6, 8].GetComponent<TileInfo>().status = 2;
        field[7, 1].GetComponent<TileInfo>().status = 2;
        field[7, 3].GetComponent<TileInfo>().status = 2;
        field[7, 5].GetComponent<TileInfo>().status = 2;
        field[7, 7].GetComponent<TileInfo>().status = 2;
        field[8, 2].GetComponent<TileInfo>().status = 2;
        field[8, 4].GetComponent<TileInfo>().status = 2;
        field[8, 6].GetComponent<TileInfo>().status = 2;
        field[8, 8].GetComponent<TileInfo>().status = 2;

    }
    
    private void SetFieldTiles()
    {
        field[1, 1] = GameObject.Find("Cube A1");
        field[1, 2] = GameObject.Find("Cube A2");
        field[1, 3] = GameObject.Find("Cube A3");
        field[1, 4] = GameObject.Find("Cube A4");
        field[1, 5] = GameObject.Find("Cube A5");
        field[1, 6] = GameObject.Find("Cube A6");
        field[1, 7] = GameObject.Find("Cube A7");
        field[1, 8] = GameObject.Find("Cube A8");


        field[2, 1] = GameObject.Find("Cube B1");
        field[2, 2] = GameObject.Find("Cube B2");
        field[2, 3] = GameObject.Find("Cube B3");
        field[2, 4] = GameObject.Find("Cube B4");
        field[2, 5] = GameObject.Find("Cube B5");
        field[2, 6] = GameObject.Find("Cube B6");
        field[2, 7] = GameObject.Find("Cube B7");
        field[2, 8] = GameObject.Find("Cube B8");

        field[3, 1] = GameObject.Find("Cube C1");
        field[3, 2] = GameObject.Find("Cube C2");
        field[3, 3] = GameObject.Find("Cube C3");
        field[3, 4] = GameObject.Find("Cube C4");
        field[3, 5] = GameObject.Find("Cube C5");
        field[3, 6] = GameObject.Find("Cube C6");
        field[3, 7] = GameObject.Find("Cube C7");
        field[3, 8] = GameObject.Find("Cube C8");

        field[4, 1] = GameObject.Find("Cube D1");
        field[4, 2] = GameObject.Find("Cube D2");
        field[4, 3] = GameObject.Find("Cube D3");
        field[4, 4] = GameObject.Find("Cube D4");
        field[4, 5] = GameObject.Find("Cube D5");
        field[4, 6] = GameObject.Find("Cube D6");
        field[4, 7] = GameObject.Find("Cube D7");
        field[4, 8] = GameObject.Find("Cube D8");

        field[5, 1] = GameObject.Find("Cube E1");
        field[5, 2] = GameObject.Find("Cube E2");
        field[5, 3] = GameObject.Find("Cube E3");
        field[5, 4] = GameObject.Find("Cube E4");
        field[5, 5] = GameObject.Find("Cube E5");
        field[5, 6] = GameObject.Find("Cube E6");
        field[5, 7] = GameObject.Find("Cube E7");
        field[5, 8] = GameObject.Find("Cube E8");

        field[6, 1] = GameObject.Find("Cube F1");
        field[6, 2] = GameObject.Find("Cube F2");
        field[6, 3] = GameObject.Find("Cube F3");
        field[6, 4] = GameObject.Find("Cube F4");
        field[6, 5] = GameObject.Find("Cube F5");
        field[6, 6] = GameObject.Find("Cube F6");
        field[6, 7] = GameObject.Find("Cube F7");
        field[6, 8] = GameObject.Find("Cube F8");

        field[7, 1] = GameObject.Find("Cube G1");
        field[7, 2] = GameObject.Find("Cube G2");
        field[7, 3] = GameObject.Find("Cube G3");
        field[7, 4] = GameObject.Find("Cube G4");
        field[7, 5] = GameObject.Find("Cube G5");
        field[7, 6] = GameObject.Find("Cube G6");
        field[7, 7] = GameObject.Find("Cube G7");
        field[7, 8] = GameObject.Find("Cube G8");

        field[8, 1] = GameObject.Find("Cube H1");
        field[8, 2] = GameObject.Find("Cube H2");
        field[8, 3] = GameObject.Find("Cube H3");
        field[8, 4] = GameObject.Find("Cube H4");
        field[8, 5] = GameObject.Find("Cube H5");
        field[8, 6] = GameObject.Find("Cube H6");
        field[8, 7] = GameObject.Find("Cube H7");
        field[8, 8] = GameObject.Find("Cube H8");



        /*field[1, 1].tile = GameObject.Find("A1");
        field[1, 2].tile = GameObject.Find("A2");
        field[1, 3].tile = GameObject.Find("A3");
        field[1, 4].tile = GameObject.Find("A4");
        field[1, 5].tile = GameObject.Find("A5");
        field[1, 6].tile = GameObject.Find("A6");
        field[1, 7].tile = GameObject.Find("A7");
        field[1, 8].tile = GameObject.Find("A8");
        field[2, 1].tile = GameObject.Find("B1");
        field[2, 2].tile = GameObject.Find("B2");
        field[2, 3].tile = GameObject.Find("B3");
        field[2, 4].tile = GameObject.Find("B4");
        field[2, 5].tile = GameObject.Find("B5");
        field[2, 6].tile = GameObject.Find("B6");
        field[2, 7].tile = GameObject.Find("B7");
        field[2, 8].tile = GameObject.Find("B8");
        field[3, 1].tile = GameObject.Find("C1");
        field[3, 2].tile = GameObject.Find("C2");
        field[3, 3].tile = GameObject.Find("C3");
        field[3, 4].tile = GameObject.Find("C4");
        field[3, 5].tile = GameObject.Find("C5");
        field[3, 6].tile = GameObject.Find("C6");
        field[3, 7].tile = GameObject.Find("C7");
        field[3, 8].tile = GameObject.Find("C8");
        field[4, 1].tile = GameObject.Find("D1");
        field[4, 2].tile = GameObject.Find("D2");
        field[4, 3].tile = GameObject.Find("D3");
        field[4, 4].tile = GameObject.Find("D4");
        field[4, 5].tile = GameObject.Find("D5");
        field[4, 6].tile = GameObject.Find("D6");
        field[4, 7].tile = GameObject.Find("D7");
        field[4, 8].tile = GameObject.Find("D8");
        field[5, 1].tile = GameObject.Find("E1");
        field[5, 2].tile = GameObject.Find("E2");
        field[5, 3].tile = GameObject.Find("E3");
        field[5, 4].tile = GameObject.Find("E4");
        field[5, 5].tile = GameObject.Find("E5");
        field[5, 6].tile = GameObject.Find("E6");
        field[5, 7].tile = GameObject.Find("E7");
        field[5, 8].tile = GameObject.Find("E8");
        field[6, 1].tile = GameObject.Find("F1");
        field[6, 2].tile = GameObject.Find("F2");
        field[6, 3].tile = GameObject.Find("F3");
        field[6, 4].tile = GameObject.Find("F4");
        field[6, 5].tile = GameObject.Find("F5");
        field[6, 6].tile = GameObject.Find("F6");
        field[6, 7].tile = GameObject.Find("F7");
        field[6, 8].tile = GameObject.Find("F8");
        field[7, 1].tile = GameObject.Find("G1");
        field[7, 2].tile = GameObject.Find("G2");
        field[7, 3].tile = GameObject.Find("G3");
        field[7, 4].tile = GameObject.Find("G4");
        field[7, 5].tile = GameObject.Find("G5");
        field[7, 6].tile = GameObject.Find("G6");
        field[7, 7].tile = GameObject.Find("G7");
        field[7, 8].tile = GameObject.Find("G8");
        field[8, 1].tile = GameObject.Find("H1");
        field[8, 2].tile = GameObject.Find("H2");
        field[8, 3].tile = GameObject.Find("H3");
        field[8, 4].tile = GameObject.Find("H4");
        field[8, 5].tile = GameObject.Find("H5");
        field[8, 6].tile = GameObject.Find("H6");
        field[8, 7].tile = GameObject.Find("H7");
        field[8, 8].tile = GameObject.Find("H8");*/
    } 
}
