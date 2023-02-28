using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : Collectible
{
    public override void Collect()
    {
        Debug.Log("Item Collected");
    }
    

   
}
