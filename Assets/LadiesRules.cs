using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadiesRules : MonoBehaviour {

    static Vector3 offset = new Vector3(0, 0.35f, 0);

    public static void ladiesRules(GameObject piece, Camera cam, int turn, GameObject instance, Material avaliable, int x, int y, int dx, int dy)
    {
        var mousePos = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (piece != null)
        {
            FieldManager.Clear();
            {
                if (TileManager.field[x + dx, y + dy] == GameObject.FindGameObjectWithTag("Tile"))
                {
                    if (TileManager.field[x + dx, y + dy].GetComponent<TileInfo>().status == 1 & TileManager.field[x + dx * 2, y + dy * 2] == GameObject.FindGameObjectWithTag("Tile"))
                    {
                        if (TileManager.field[x + dx * 2, y + dy * 2].GetComponent<TileInfo>().status == 0)
                        {
                            TileManager.field[x + dx * 2, y + dy * 2].GetComponent<Renderer>().material = avaliable;

                            if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + dx * 2, y + dy * 2] == hit.collider.gameObject & hit.collider.tag == "Tile")
                            {
                                Destroy(TileManager.field[x + dx, y + dy].GetComponent<TileInfo>().piece);
                                Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                                GameObject.Instantiate(instance, TileManager.field[x + dx * 2, y + dy * 2].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                                FieldManager.turn = turn;
                                FieldManager.Clear();
                                FieldManager.clearPieces = true;
                            }
                        }
                    }
                    else if (TileManager.field[x + dx, y + dy].GetComponent<TileInfo>().status == 0) //tile livre
                    {
                        TileManager.field[x + dx, y + dy].GetComponent<Renderer>().material = avaliable;

                        if (Physics.Raycast(mousePos, out hit, 100) & Input.GetMouseButtonDown(0) & TileManager.field[x + dx, y + dy] == hit.collider.gameObject & hit.collider.tag == "Tile")
                        {
                            Destroy(TileManager.field[x, y].GetComponent<TileInfo>().piece);
                            GameObject.Instantiate(instance, TileManager.field[x + dx, y + dy].transform.position + offset, TileManager.field[1, 1].transform.rotation);
                            FieldManager.turn = turn;
                            FieldManager.Clear();
                            FieldManager.clearPieces = true;
                        }
                    }
                }
            }
        }
    }
}
