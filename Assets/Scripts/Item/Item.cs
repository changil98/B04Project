using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{  
    public Sprite image;       // ������ �̹���
    public string description; // ������ ����

    public Item(Sprite sprite, string des)
    {
        image = sprite;
        description = des;
    }

}