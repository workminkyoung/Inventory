using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventorySlot _itemPrefab;

    [SerializeField]
    private RectTransform _contentPanel;

    [SerializeField]
    private List<UIInventorySlot> _inventorySlots = new List<UIInventorySlot>();

    [SerializeField]
    private UIInventorySlot _selectedSlot;

    public void InitializeInventoryUI(int inventorySize = 32)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UIInventorySlot slot = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity, _contentPanel);
            _inventorySlots.Add(slot);
        }
    }

    public void SetActiveInventory(bool state)
    {
        gameObject.SetActive(state);
    }

    public void DropItem()
    {
        if (_selectedSlot == null)
        {
            Debug.Log("No item selected to drop!");
            return;
        }

        DropItemToMap(_selectedSlot.Item, Vector3.zero);
        _selectedSlot.RemoveItem();
        _selectedSlot = null;
    }

    public void DropItemToMap(UIInventoryItem item, Vector3 dropPos)
    {
        // TODO
        // 캐릭터 기준으로 인스턴싱
        // 드롭될 아이템 프리팹 만들기
    }
}