using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BorrowedInventory", menuName = "Sctiptable/Inventory/Borrowed")]
public class SOBorrowed : SOInventories
{
    public List<BSlot> borrowedSlots = new List<BSlot>();
    int stackL = 2;
    
    public bool BorrowedAddBook(SOBook book) 
    {
        foreach (BSlot slot in borrowedSlots)
        {
            if (slot.bBooks == book)
            {
                if (slot.bBooks.canStackable)
                {
                    if (slot.bCount < stackL)
                    {
                        slot.bCount++;
                        return true;
                    }
                    
                }
            }
            else if (slot.bCount == 0)
            {
                slot.AddBookToSlot(book);
                return true;
            }
        }
        return false;
    }
    public void DeleteBook(int index)
    {
        borrowedSlots[index].isFull = false;
        borrowedSlots[index].bCount = 0;
        borrowedSlots[index].bBooks = null;
    }
}
[System.Serializable]
public class BSlot
{
    
    public bool isFull;
    public int bCount;  // Bir kiþi ayný kitaptan alýrsa ayrý bir geri getirme kontrolu uygulanmalý.
    public SOBook bBooks;
    public void AddBookToSlot(SOBook bBook)
    {
        this.bBooks = bBook;
        if (bBooks.canStackable == false)
        {
            isFull = true;
        }
        bCount++;
    }
}

