using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReturnedInventory", menuName = "Sctiptable/Inventory/Returned")]

public class SOReturned : SOInventories
{
    public List<RSlot> returnedSlots = new List<RSlot>();
    int sLimit = 1;
    public bool ReturnedAddBook(SOBook book)
    {
        foreach (RSlot slot in returnedSlots)
        {
            if (slot.rBooks == book)
            {
                //belirli aralýklarla türemeli yada ayrý bir kullanýcý paneli olarak oluþturularak buton eklenmeli
                // bookcase'e, returned panele ekleyeceðimiz bir buton sonucunda taþýnmalý
                if (slot.rBooks.canStackable)
                {
                    if (slot.rCount < sLimit)
                    {
                        slot.rCount++;
                        return true;
                    }

                }
            }
            else if (slot.rCount == 0)
            {
                slot.AddBookToSlot(book);
                return true;
            }
        }
        return false;
    }
    public void DeleteBook(int index)
    {
        returnedSlots[index].isFull = false;
        returnedSlots[index].rCount--;
        returnedSlots[index].rBooks = null;
    }
}
[System.Serializable]
public class RSlot
{
    public bool isFull;
    public int rCount;
    public SOBook rBooks;
    public void AddBookToSlot(SOBook book)
    {
        this.rBooks = book;
        if (rBooks.canStackable == false)
        {
            isFull = true;
        }
        rCount++;
    }
}
