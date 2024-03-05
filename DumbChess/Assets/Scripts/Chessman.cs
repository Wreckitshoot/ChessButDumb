using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    //Positions
    private int xBoard = -1;
    private int yBoard = -1;

    private string player; //Keeps track of black and white player 

    public Sprite black_queen, black_knight, black_bishop, black_rook, black_pawn, black_king;
    public Sprite white_queen, white_knight, white_bishop, white_rook, white_pawn, white_king;

    public void Activate() //Brandon
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        SetCoords();

        switch(this.name) //Set the sprite for the piece
        {
            //Black
            case "black_queen": this.GetComponent<SpriteRenderer>().sprite = black_queen; break;
            case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king; break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; break;
            case "black_knight": this.GetComponent<SpriteRenderer>().sprite = black_knight; break;
            case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = black_bishop; break;
            case "black_pawn": this.GetComponent<SpriteRenderer>().sprite = black_queen; break;
            //White
            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; break;
            case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; break;
            case "white_knight": this.GetComponent<SpriteRenderer>().sprite = white_knight; break;
            case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = white_bishop; break;
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn; break;

        }

    }

    public void SetCoords() //Brandon
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }
    public int GetYBoard() {  
        return yBoard; 
    }
    public void SetXBoard(int x)
    {
        xBoard = x;
    }
    public void SetYBoard(int y)
    {
        yBoard = y;
    }


    private void OnMouseUp()
    {
        DestroyMovePlates();

        InitiateMovePlates();
    }


    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }

    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "black_queen":
            case "white_queen":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;
            case "black_knight":
            case "white_knight":
                LMovePlate();
                break;
            case "black_bishop":
            case "white_bishop":
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;
            case "black_king":
            case "white_king":
                SurroundMovePlate();
                break;
            case "black_rook":
            case "white_rook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "black_pawn":
                PawnMovePlate(xBoard, yBoard - 1 );
                break;
            case "white_pawn":
                PawnMovePlate(xBoard, yBoard + 1);
                break;
        }
    }

}
