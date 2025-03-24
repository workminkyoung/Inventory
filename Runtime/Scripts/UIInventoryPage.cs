using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventorySlot _itemPrefab;

    [SerializeField]
    private RectTransform _contentPanel;

    [SerializeField]
    private List<UIInventorySlot> _inventorySlots = new List<UIInventorySlot>();

    public void InitializeInventoryUI(int inventorySize)
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
}
