using LibraryInvantory.ScriptableUi;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SOBookcase BCInventory;
    public SOBorrowed BInventory;
    public SOReturned RInventory;
    public SOSearch SInventory;
    InventoryUIController inventoryUi;
    Timer timer;

    bool isSwapping;
    int tempIndex;
    BCSlot tempSlot;

    private void Start()
    {
        inventoryUi = gameObject.GetComponent<InventoryUIController>();
        timer = gameObject.GetComponent<Timer>();
        timer.OnTimeUp += BorrowedTime;

    }
    public void SwapBook(int index)
    {
        if (isSwapping == false)
        {
            tempIndex = index;
            tempSlot = BCInventory.bookcaseSlots[tempIndex];
            isSwapping = true;
        }
        else if (isSwapping == true)
        {//bookcaseSlots için deðil diðer slotslar içinde kullanýlmasýný kod tekrarý yapmadan nasýl saðlarsýn?
            BCInventory.bookcaseSlots[tempIndex] = BCInventory.bookcaseSlots[index];
            BCInventory.bookcaseSlots[index] = tempSlot;
            isSwapping = false;
        }
        inventoryUi.BookcaseUpdateUI();      

    }
    
    public void DeleteBookButton()
    {
        if (isSwapping == true)
        {
            BCInventory.DeleteBook(tempIndex);
            isSwapping = false;
        }
    }
    public void BorrowedAddBookButton(int index)
    {
        if (BCInventory.bookcaseSlots[index].bookCount > 0)
        {//buraya eklemen gereken þey slot eðer taþýndýysa countu düþür 
            if (isSwapping)
            {
                BCSlot selectedSlot = BCInventory.bookcaseSlots[index];
                BInventory.BorrowedAddBook(selectedSlot.books);
                BCInventory.bookcaseSlots[index].bookCount--;
                Debug.Log("Kitap taþýndý.");
                if (BCInventory.bookcaseSlots[index].bookCount == 0)
                {
                    BCInventory.DeleteBook(tempIndex);
                }
                inventoryUi.BookcaseUpdateUI();
                inventoryUi.BorrowedUpdateUI();

            }
        }
        else if (BCInventory.bookcaseSlots[index].bookCount == 0)
        {
            BCInventory.DeleteBook(tempIndex);

        }
        if (SInventory.searchSlots[index].sbookCount > 0)
        {
            SearchSlot selectedSlot = SInventory.searchSlots[index];
            BInventory.BorrowedAddBook(selectedSlot.sbooks);
            SInventory.searchSlots[index].sbookCount--;
            if (SInventory.searchSlots[index].sbookCount == 0)
            {
                SInventory.DeleteBook(tempIndex);
            }
        }
        inventoryUi.SearchUpdateUI();
        inventoryUi.BorrowedUpdateUI();

    }
    public void BorrowedTime()
    {
        for (int i = 0; i < BInventory.borrowedSlots.Count; i++)
        {
            if (BInventory.borrowedSlots[i].bCount > 0)
            {
                RInventory.ReturnedAddBook(BInventory.borrowedSlots[i].bBooks);
                BInventory.borrowedSlots[i].bCount--;
            }
            else if (BInventory.borrowedSlots[i].bCount == 0)
            {
                BCInventory.DeleteBook(tempIndex);
            }
        }

        inventoryUi.BorrowedUpdateUI();
        inventoryUi.ReturnedUpdateUI();
    }
    public void BookcaseAddBookButton(int index)
    {
        if (BInventory.borrowedSlots[index].bCount > 0)
        {
            if (isSwapping)
            {
                BSlot selectedSlots = BInventory.borrowedSlots[index];
                BCInventory.BookcaseAddBook(selectedSlots.bBooks);
                BInventory.borrowedSlots[index].bCount--;
            }

        }
        else if (BInventory.borrowedSlots[index].bCount == 0)
        {
            BInventory.DeleteBook(tempIndex);
        }
        inventoryUi.BorrowedUpdateUI();
        inventoryUi.ReturnedUpdateUI();
        if(RInventory.returnedSlots[index].rCount > 0)
        {
            if (isSwapping)
            {
                RSlot selectedSlot = RInventory.returnedSlots[index];
                BCInventory.BookcaseAddBook(selectedSlot.rBooks);
                RInventory.returnedSlots[index].rCount--;
            }
            
        }else if (RInventory.returnedSlots[index].rCount == 0)
        {
            RInventory.DeleteBook(tempIndex);
        }
    }
    public void SearchBooks(string searchName)
    {
        List<BCSlot> searchResults = BCInventory.SearchedBooks(searchName);
        foreach (SearchSlot searchSlot in SInventory.searchSlots)
        {
            if (!searchSlot.isFull && searchResults.Count > 0)
            {
                BCSlot result = searchResults[0];
                searchSlot.isFull = true;
                searchSlot.sbookCount = result.bookCount;
                searchSlot.sbooks = result.books;
            }
            
        }
        inventoryUi.SearchUpdateUI();
    }
 
}


