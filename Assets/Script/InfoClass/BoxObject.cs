using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Waepon
{
    public Sprite WaeponSprite;
    public int MaxDamage;
    public int MinDamage;
    public List<Coordinate> range;
    
}
[System.Serializable]
public struct Item
{
    public Sprite ItemSprite;

}