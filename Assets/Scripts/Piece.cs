﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : Square
{
    private string side;
    private bool king = false;
    private List<Move> moves = new List<Move>();
    private int priority = 0;

    public string getSide()
    {
        return side;
    }
    public void setSide(string side)
    {
        this.side = side;
    }
    public bool getKing()
    {
        return king;
    }
    public void promote()
    {
        king = true;
        gameObject.transform.Find("crown").gameObject.SetActive(true);
    }
    public void select(bool select)
    {
        gameObject.transform.Find("selected").gameObject.SetActive(select);
    }

    public List<Move> getMoves()
    {
        return moves;
    }
    public void addMove(Move move)
    {
        int prio = move.GetPriority();
        if (prio > priority) //Force capture
        {
            moves.Clear();
            priority = prio;
        }
        if (prio >= priority) 
            moves.Add(move);
    }
    public void clearMoves()
    {
        moves.Clear();
        priority = 0;
    }
    public int getMovesNum()
    {
        return moves.Count;
    }


}
