using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon; // 아이템 아이콘 이미지

    public void AddItem(Sprite itemIcon)
    {
        icon.sprite = itemIcon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}