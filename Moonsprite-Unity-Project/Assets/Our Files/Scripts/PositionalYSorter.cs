using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionalYSorter : MonoBehaviour
{
    [System.Serializable]
    public class SpriteRendererWithOffset
    {
        public SpriteRenderer spriteRenderer;
        public int offset = 0;
    }

    #region Parameters
    [Header("Select SpriteRenderers")]
    public List<SpriteRendererWithOffset> spriteRenderers = new List<SpriteRendererWithOffset>();

    [Header("Parameters")]
    public bool movable = false; [Tooltip("If it isn't movable, the sorting order will only be updated once (on start)")]
    [Space]
    public float sortingPointOffset = 0;
    public bool displayGizmos = false;

    [Header("Parameters")]
    public bool setSortingOrderButton = false;
    #endregion

    #region Variables
    public const float sortingOrderMultiply = -10000; //sorting orders are int numbers so the yPosition has to be multiplied to get enough granularity
    public const float gizmoRadius = 0.01f;
    #endregion

    // This draws debug visuals 
    void OnDrawGizmos()
    {
        if (displayGizmos == true)
        {
            Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + sortingPointOffset), gizmoRadius);
        }
    }

    // this gets triggered whenever the component is interacted with via us (not the player)
    // it executes while in edit mode
    void OnValidate() 
    {
        // this is a hacky cheap way of making a button
        if(setSortingOrderButton == true)
        {
            setSortingOrderButton = false;
            SetAllSpriteRendererSortingOrdersTo(CalculateSortingOrder(transform.position.y));
        }
    }

    void Start()
    {
        SetAllSpriteRendererSortingOrdersTo(CalculateSortingOrder(transform.position.y));
    }

    void Update()
    {
        if(movable == true)
        {
            SetAllSpriteRendererSortingOrdersTo(CalculateSortingOrder(transform.position.y));
        }
    }

    int CalculateSortingOrder(float yPosition)
    {
        return Mathf.RoundToInt((yPosition + sortingPointOffset) * sortingOrderMultiply);
    }

    void SetAllSpriteRendererSortingOrdersTo(int newSortingOrder)
    {
        foreach(SpriteRendererWithOffset spriteRendererWithOffset in spriteRenderers)
        {
            spriteRendererWithOffset.spriteRenderer.sortingOrder = CalculateSortingOrder(newSortingOrder) + spriteRendererWithOffset.offset;
        }
    }
}
