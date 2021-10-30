using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    enum ItemType
    {
        Hammer,
        Saw
    }

    [SerializeField] private ItemType itemType;
}
