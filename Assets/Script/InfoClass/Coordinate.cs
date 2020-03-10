using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : MonoBehaviour
{
    private int _x =0;
    private int _y =0;
    
    public int x
    {
        get
        {
            return _x;
        }

        set
        {
            _x = value;
        }
    }
    public int y
    {
        get
        {
            return _y;
        }

        set
        {
            _y = value;
        }
    }


    public bool CompareCoordinate(Coordinate coordinate)
    {
        if (coordinate.x == _x && coordinate.y == _y)
        {
            return true;
        }
        else return false;
    }
    public bool CompareCoordinate(int x, int y)
    {
        if (x == _x && y == _y)
        {
            return true;
        }
        else return false;
    }
}
