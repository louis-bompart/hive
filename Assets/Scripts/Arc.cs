using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arc
{
    public List<Room> roomI;
    public List<Room> roomJ;
    public Arc() { }
    public Arc(List<Room> i, List<Room> j) { roomI = i; roomJ = j; }
    public Arc GetReverseArc()
    {
        return new Arc(roomJ, roomI);
    }
}

