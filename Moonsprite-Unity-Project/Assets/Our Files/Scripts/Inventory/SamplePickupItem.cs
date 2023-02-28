using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePickupItem : Collectible
{
    public static event HandleItemPickup OnItemCollected;

    public delegate void HandleItemPickup(ItemData itemData);

    public ItemData sampleItemData;

    //void Add(ItemData itemData)



    public override void Collect()
    {
       // Debug.Log("Sample Item Collected");
        Destroy(gameObject);
        OnItemCollected?.Invoke(sampleItemData);
    }
}
