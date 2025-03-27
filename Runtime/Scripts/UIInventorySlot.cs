using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// �κ��丮 ����: Ư�� �����۰� ������ ����
/// </summary>
[System.Serializable]
public class UIInventorySlot : MonoBehaviour, IDropHandler
{
    private UIInventoryItem _currentItem;
    private int _quantity;

    public UIInventoryItem Item
    { 
        get { return _currentItem; } 
        set { _currentItem = value; } 
    }

    public UIInventorySlot(UIInventoryItem item, int quantity)
    {
        this._currentItem = item;
        this._quantity = quantity;
    }


    public void OnDrop(PointerEventData eventData)
    {
        UIInventoryItem item = eventData.pointerDrag.GetComponent<UIInventoryItem>();

        if (item != null)
        {
            // ������ ��� ������ �������� �߰�
            if (transform.childCount == 0)
            {
                item.transform.SetParent(transform);
                item.transform.localPosition = Vector3.zero;
            }
            else
            {
                // �̹� �������� ������ ���� �����۰� ��ü�� ���� ���� (�߰� ���� �ʿ�)
            }
        }
    }

    /// <summary>
    /// ������ �߰� �� �ִ� ���� �ʰ� ���� Ȯ��
    /// </summary>
    //public bool CanAddMore(int amount) => (quantity + amount) <= item.maxStack;


    public bool IsEmpty()
    {
        return _currentItem == null;
    }

    public void RemoveItem()
    {
        _currentItem = null;
    }

}
