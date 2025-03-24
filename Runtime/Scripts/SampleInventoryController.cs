using UnityEngine;

public class SampleInventoryController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage _inventoryPage;

    private void Start()
    {
        //_inventoryPage.InitializeInventoryUI(20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(_inventoryPage.isActiveAndEnabled == false)
            {
                _inventoryPage.SetActiveInventory(true);
            }
            else
            {
                _inventoryPage.SetActiveInventory(false);
            }
        }
    }
}
