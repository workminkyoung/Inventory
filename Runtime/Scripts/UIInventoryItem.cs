using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIInventoryItem : DraggableItem
{
    [SerializeField]
    private Item _item;
    [SerializeField]
    private Image _itemImage;
    [SerializeField]
    private TextMeshProUGUI _itemText;

    public Item Item => _item;

    protected override void MoveToSlot(UIInventorySlot newSlot)
    {
        base.MoveToSlot(newSlot);

        newSlot.Item = this; // 새로운 슬롯에 아이템 등록
    }
}
