using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Inventory playerInventory;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public List<InventorySlots> inventorySlots = new List<InventorySlots>(36); // this list is limited, however the inventory space is not, work out how to fix that
                                                                               // public GameObject inventoryPanel;

    private void OnEnable()
    {

        Inventory.OnInventoryChange += DrawnInventory;

    }

    private void OnDisable()
    {

        Inventory.OnInventoryChange -= DrawnInventory;

    }

    void ResetInventory()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlots>(36);
    }

    void DrawnInventory(List<InventoryItem> inventory)
    {

        ResetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++)
        {

            CreateInventorySlot();

        }


        for (int x = 0; x < inventory.Count; x++)
        {

            inventorySlots[x].DrawSlot(inventory[x]);

        }


    }

    void CreateInventorySlot()
    {

        GameObject newSlot = Instantiate(slotPrefab);

        newSlot.transform.SetParent(transform, false);

        InventorySlots newSlotComponent = newSlot.GetComponent<InventorySlots>();

        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);

    }


    private void FixedUpdate()
    {
        inventoryItems = FindObjectOfType<Inventory>().GetListOfItems();
        DrawnInventory(inventoryItems);
    }


}

