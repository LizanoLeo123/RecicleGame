using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Can")]
public class CanObject : ItemObject
{
    public void Awake(){
        type = ItemType.Can;
    }   
}