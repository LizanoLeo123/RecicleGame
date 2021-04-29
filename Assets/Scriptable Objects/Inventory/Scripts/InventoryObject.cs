using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public int money = 0;

    public List<InventorySlot> Container = new List<InventorySlot>();
    public int capcaity = 20;
    public int totalAmount = 0;

    public void addItem(ItemObject _item, int _amount)
    {
        if (this.capcaity < (this.totalAmount + _amount))
        {
            return;
        }

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                this.totalAmount += _amount;
                Container[i].addAmount(_amount);
                return;
            }
        }
        this.totalAmount += _amount;
        Container.Add(new InventorySlot(_item, _amount));

    }

    public void moveItem(InventorySlot _item1, InventorySlot _item2)
    {
        InventorySlot tmp = new InventorySlot(_item2.item, _item2.amount);
        _item2.updateSlot(_item1.item, _item1.amount);
        _item1.updateSlot(tmp.item, tmp.amount);
    }

    public void removeItem(ItemObject _item)
    {
        for (int i = 0; i < this.Container.Count; i++)
        {
            if(this.Container[i].item == _item){
                this.totalAmount -= this.Container[i].amount;
                this.Container.RemoveAt(i);
                return;
            }

        }
    }

    public void changeCapacity(int _newCapacity){
        if(this.capcaity < _newCapacity)
            this.capcaity = _newCapacity;
    }
    public bool hasSapce(int _amount){
        if (this.capcaity < (this.totalAmount + _amount))
            return false;
        else
            return true;
    }

    [ContextMenu("Clear")]
    public void clear()
    {
        this.Container = new List<InventorySlot>();
        this.totalAmount = 0;
    }

}

[System.Serializable]
public class InventorySlot 
{
    public ItemObject item;
    public int amount;

    public InventorySlot()
    {
        this.item = null;
        this.amount = 0;
    }

    public InventorySlot(ItemObject _item, int _amount)
    {
        this.item = _item;
        this.amount = _amount;
    }
    
    public void updateSlot(ItemObject _item, int _amount)
    {
        this.item = _item;
        this.amount = _amount;
    }

    public void addAmount(int _value){
        this.amount += _value;
    }
}