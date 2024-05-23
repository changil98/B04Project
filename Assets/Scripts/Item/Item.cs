using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{  
    public Sprite image;       // 아이템 이미지
    public string description; // 아이템 설명

    public Item(Sprite sprite, string des)
    {
        image = sprite;
        description = des;
    }

}