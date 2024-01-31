using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BookcaseInventory", menuName = "Sctiptable/Inventory/Bookcase")]
public class SOBookcase : SOInventories
{
    public List<BCSlot> bookcaseSlots = new List<BCSlot>();
    int stackLimit = 3;//ISBN s�k�nt� yaratabilir d�zenlenmeli.

    public void DeleteBook(int index)
    {
        bookcaseSlots[index].isFull = false;
        bookcaseSlots[index].bookCount = 0;
        bookcaseSlots[index].books = null;
    }
    

    public bool BookcaseAddBook(SOBook book) //ekleme i�lemi bu projede colliderla ilgili olmad��� i�in BorrowedSlot ile ili�kilendirmelisin.
    {// e�er kitap eklendiyse return true d�nmesi i�in void de�il bool
        foreach (BCSlot slot in bookcaseSlots)
        {
            if (slot.books == book)
            {
                if (slot.books.canStackable)
                {
                    if (slot.bookCount < stackLimit)
                    {
                        slot.bookCount++;
                        if (slot.bookCount >= stackLimit)
                        {
                            slot.isFull = true;
                        }
                        else if (slot.bookCount <= stackLimit)
                        {
                            slot.isFull = false;
                        }
                        return true;
                    }
                }
            }
            else if (slot.bookCount == 0)
            {
                slot.AddBookToSlot(book);
                return true;
            }
        }
        return false;
    }
    public List<BCSlot> SearchedBooks(string searchName)
    {
        List<BCSlot> searchResults = new List<BCSlot>();

        foreach (BCSlot slot in bookcaseSlots)
        {
            if (slot.books != null && slot.books.bookName.ToLower().Contains(searchName.ToLower()))
            {
                searchResults.Add(slot);
            }
        }
        return searchResults;
    }
}
[System.Serializable]
public class BCSlot
{
    public bool isFull;
    public int bookCount;
    public SOBook books;
    public void AddBookToSlot(SOBook book) //sadece borrowed ile ili�kilendiremezsin ��nk� returned edilen kitaplar dolmam�� slotlara eklenmeli
    {
        this.books = book;
        if (books.canStackable == false)
        {
            isFull = true;
        }
        bookCount++;

    }
}


