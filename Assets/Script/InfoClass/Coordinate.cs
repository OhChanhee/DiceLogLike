using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Coordinate
{
    public int x;
    public int y;
    
    public Coordinate(int x,int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Coordinate operator *(Coordinate a,Coordinate b)
    {
        return new Coordinate(a.x * b.x, a.y * b.y);
    }
    public static Coordinate operator +(Coordinate a, Coordinate b)
    {
        return new Coordinate(a.x + b.x, a.y + b.y);
    }
    public static Coordinate operator -(Coordinate p1, Coordinate p2)
    {
        return new Coordinate(p1.x - p2.x, p1.y - p2.y);
    }
    public static bool operator ==(Coordinate a, Coordinate b)
    {
        return a.x == b.x && a.y == b.y;
    }
    public static bool operator !=(Coordinate a, Coordinate b)
    {
        return !(a == b);
    }

    public Coordinate Reverse()
    {
        return new Coordinate(y, x);
    }
    public override bool Equals(object obj)
    {
        if (obj is Coordinate)
        {
            Coordinate p = (Coordinate)obj;
            return x == p.x && y == p.y;
        }
        return false;
    }
    public bool Equals(Coordinate p)
    {
        return x == p.x && y == p.y;
    }
    public override int GetHashCode()
    {
        return x ^ y;
    }

    public override string ToString()
    {
        return string.Format("({0},{1})", x, y);
    }
}
 

