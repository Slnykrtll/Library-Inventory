using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SearchInventory",menuName ="Scriptable/Inventory/SearchBook")]
public class SOSearch : SOInventories
{
    public List<SearchSlot> searchSlots = new List<SearchSlot>();
    public bool SearchAddBook(SOBook book) 
    {
        foreach (SearchSlot slot in searchSlots)
        {
            if (slot.sbooks == book)
            {
                if (slot.sbooks.canStackable)
                {
                    if (slot.sbookCount < 1)
                    {
                        slot.sbookCount++;
                        if (slot.sbookCount >= 1)
                        {
                            slot.isFull = true;
                        }
                        return true;
                    }
                }
            }
            else if (slot.sbookCount == 0)
            {
                slot.AddBookToSlot(book);
                return true;
            }
        }
        return false;
    }
    public void DeleteBook(int index)
    {
        searchSlots[index].isFull = false;
        searchSlots[index].sbookCount = 0;
        searchSlots[index].sbooks = null;
    }
}
[System.Serializable]
public class SearchSlot
{
    public bool isFull;
    public int sbookCount;
    public SOBook sbooks;

    public void AddBookToSlot(SOBook books) 
    {
        this.sbooks = books;
        if (sbooks.canStackable == false)
        {
            isFull = true;
        }
        sbookCount++;
    }
}
