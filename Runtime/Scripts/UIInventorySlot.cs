using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// �κ��丮 ����: Ư�� �����۰� ������ ����
/// </summary>
[System.Serializable]
public class UIInventorySlot : MonoBehaviour, IDropHandler
{
    private DraggableItem currentItem;
    public int quantity;

    public UIInventorySlot(DraggableItem item, int quantity)
    {
        this.currentItem = item;
        this.quantity = quantity;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem item = eventData.pointerDrag.GetComponent<DraggableItem>();

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
        return currentItem == null;
    }

    public void SetItem(DraggableItem item)
    {
        currentItem = item;
    }

    public void RemoveItem()
    {
        currentItem = null;
    }

}
