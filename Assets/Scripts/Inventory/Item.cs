using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string Label;
    public Sprite Sprite;
    public Sprite IconSprite;
    public int Price;
    public int MaxNumber;
}
