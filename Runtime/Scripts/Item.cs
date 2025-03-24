using UnityEngine;

/// <summary>
/// �⺻ ������ Ŭ����
/// </summary>
[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStack;

    public Item(string name, Sprite icon, int maxStack = 1)
    {
        this.itemName = name;
        this.icon = icon;
        this.maxStack = maxStack;
    }
}