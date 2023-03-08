using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=DUDmsFmKw8E&list=PL4PNgDjMajPN51E5WzEi7cXzJ16BCHZXl&index=14 
    //this should give me sme ideas how to continue

    public InventorySlots slotPrefab, slotPrefab1, slotPrefab2, slotPrefab3, slotPrefab4;
    public Inventory playerInventory;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public List<InventorySlots> inventorySlots = new List<InventorySlots>();

    public int selectedSlot;


    public void NextSlot()
    {

        selectedSlot = selectedSlot + 1;

    }

    public void PreviousSlot()
    {

        selectedSlot = selectedSlot - 1;

    }
    void DrawnInventory()
    {



            slotPrefab.DrawSlot(inventoryItems[selectedSlot]);

        


    }
}
