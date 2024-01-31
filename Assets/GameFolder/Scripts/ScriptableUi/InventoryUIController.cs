using System.Collections.Generic;
using UnityEngine;
namespace LibraryInvantory.ScriptableUi
{
    public class InventoryUIController : MonoBehaviour
    {
        public List<SlotUi> bCList = new List<SlotUi>();//bookcase
        public List<SlotUi> bList = new List<SlotUi>();//borrewed
        public List<SlotUi> rList = new List<SlotUi>();//returned
        public List<SlotUi> sList = new List<SlotUi>();//arama sonuçlarý listesi
        public SOInventories inventories;
        Inventory userInventory;

        private void Start()
        {
            userInventory = gameObject.GetComponent<Inventory>();
           
            BookcaseUpdateUI();
            BorrowedUpdateUI();
            ReturnedUpdateUI();
        }
        public void BookcaseUpdateUI()
        {
            for (int i = 0; i < bCList.Count; i++)
            {
                if (userInventory.BCInventory.bookcaseSlots[i].bookCount > 0)
                {
                    bCList[i].bookNameText.gameObject.SetActive(true);
                    bCList[i].bookImage.gameObject.SetActive(true);
                    bCList[i].bookImage.sprite = userInventory.BCInventory.bookcaseSlots[i].books.bookIcon;
                    bCList[i].bookNameText.text = userInventory.BCInventory.bookcaseSlots[i].books.bookName;
                    if (userInventory.BCInventory.bookcaseSlots[i].books.canStackable == true)
                    {
                        bCList[i].bookCountText.gameObject.SetActive(true);
                        bCList[i].bookCountText.text = userInventory.BCInventory.bookcaseSlots[i].bookCount.ToString();
                    }
                    else
                    {
                        bCList[i].bookCountText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    bCList[i].bookImage.sprite = null;
                    bCList[i].bookCountText.gameObject.SetActive(false);
                    bCList[i].bookNameText.gameObject.SetActive(false);
                }

            }

        }
        public void BorrowedUpdateUI()
        {
            for (int i = 0; i < bList.Count; i++)
            {
                if (userInventory.BInventory.borrowedSlots[i].bCount > 0)
                {
                    bList[i].bookImage.gameObject.SetActive(true);
                    bList[i].bookNameText.gameObject.SetActive(true);
                    bList[i].bookImage.sprite = userInventory.BInventory.borrowedSlots[i].bBooks.bookIcon;
                    bList[i].bookNameText.text = userInventory.BInventory.borrowedSlots[i].bBooks.bookName;
                    if (userInventory.BCInventory.bookcaseSlots[i].books == true)
                    {

                        bList[i].bookCountText.text = userInventory.BInventory.borrowedSlots[i].bCount.ToString();
                        bList[i].bookCountText.gameObject.SetActive(true);
                    }
                    else
                    {
                        bList[i].bookCountText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    bList[i].bookImage.sprite = null;
                    bList[i].bookCountText.gameObject.SetActive(false);
                    bList[i].bookNameText.gameObject.SetActive(false);
                }

            }
        }
        public void ReturnedUpdateUI()
        {
            for (int i = 0; i < rList.Count; i++)
            {
                if (userInventory.RInventory.returnedSlots[i].rCount > 0)
                {
                    rList[i].bookImage.gameObject.SetActive(true);
                    rList[i].bookNameText.gameObject.SetActive(true);
                    rList[i].bookImage.sprite = userInventory.RInventory.returnedSlots[i].rBooks.bookIcon;
                    rList[i].bookNameText.text = userInventory.RInventory.returnedSlots[i].rBooks.bookName;
                    if (userInventory.RInventory.returnedSlots[i].rBooks.canStackable == true)
                    {
                        rList[i].bookCountText.text = userInventory.RInventory.returnedSlots[i].rCount.ToString();
                        rList[i].bookCountText.gameObject.SetActive(true);
                    }
                    else
                    {
                        rList[i].bookCountText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    rList[i].bookImage.sprite = null;
                    rList[i].bookCountText.gameObject.SetActive(false);
                    rList[i].bookNameText.gameObject.SetActive(false);
                }

            }

        }
        public void SearchUpdateUI()
        {
            for (int i = 0; i < sList.Count; i++)
            {
                if (userInventory.SInventory.searchSlots[i].sbookCount > 0)
                {
                    sList[i].bookImage.gameObject.SetActive(true);
                    sList[i].bookNameText.gameObject.SetActive(true);
                    sList[i].bookImage.sprite = userInventory.SInventory.searchSlots[i].sbooks.bookIcon;
                    sList[i].bookNameText.text = userInventory.SInventory.searchSlots[i].sbooks.bookName;

                    if (userInventory.SInventory.searchSlots[i].sbooks.canStackable == true)
                    {
                        sList[i].bookCountText.gameObject.SetActive(true);
                        sList[i].bookCountText.text = userInventory.SInventory.searchSlots[i].sbookCount.ToString();
                    }
                    else
                    {
                        sList[i].bookCountText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    sList[i].bookImage.sprite = null;
                    sList[i].bookCountText.gameObject.SetActive(false);
                    sList[i].bookNameText.gameObject.SetActive(false);
                }

            }
        }
        public void BookcaseBookInfo(int i)
        {
            if (userInventory.BCInventory.bookcaseSlots[i].bookCount > 0)
            {
                bCList[i].bookInfoNameText.text = userInventory.BCInventory.bookcaseSlots[i].books.bookName;
                bCList[i].bookInfoCountText.text = userInventory.BCInventory.bookcaseSlots[i].bookCount.ToString();
                bCList[i].bookInfoAuthorText.text = userInventory.BCInventory.bookcaseSlots[i].books.bookAuthor;
                bCList[i].bookInfoPublishetText.text = userInventory.BCInventory.bookcaseSlots[i].books.bookPublisher;
                bCList[i].bookInfoImage.sprite = userInventory.BCInventory.bookcaseSlots[i].books.bookIcon;
                bCList[i].ISBNInfoText.text = userInventory.BCInventory.bookcaseSlots[i].books.bookIsbn.ToString();

            }
        }
        public void BorrowedBookInfo(int i)
        {
            if (userInventory.BInventory.borrowedSlots[i].bCount > 0)
            {
                bList[i].bookInfoNameText.text = userInventory.BInventory.borrowedSlots[i].bBooks.bookName;
                bList[i].bookInfoCountText.text = userInventory.BInventory.borrowedSlots[i].bCount.ToString();
                bList[i].bookInfoAuthorText.text = userInventory.BInventory.borrowedSlots[i].bBooks.bookAuthor;
                bList[i].bookInfoPublishetText.text = userInventory.BInventory.borrowedSlots[i].bBooks.bookPublisher;
                bList[i].bookInfoImage.sprite = userInventory.BInventory.borrowedSlots[i].bBooks.bookIcon;
                bList[i].ISBNInfoText.text = userInventory.BInventory.borrowedSlots[i].bBooks.bookIsbn.ToString();
            }
        }
        public void ReturnedBookInfo(int i)
        {
            RSlot returnedSlot = userInventory.RInventory.returnedSlots[i];
            if (returnedSlot.rCount > 0)
            {
                rList[i].bookInfoNameText.text = returnedSlot.rBooks.bookName;
                rList[i].bookInfoCountText.text = returnedSlot.rCount.ToString();
                rList[i].bookInfoAuthorText.text = returnedSlot.rBooks.bookAuthor;
                rList[i].bookInfoPublishetText.text = returnedSlot.rBooks.bookPublisher;
                rList[i].bookInfoImage.sprite = returnedSlot.rBooks.bookIcon;
                rList[i].ISBNInfoText.text = returnedSlot.rBooks.bookIsbn.ToString();
            }
        }
        public void SearchBookInfo(int i)
        {
            SearchSlot searchSlot = userInventory.SInventory.searchSlots[i];
            if (searchSlot.sbookCount > 0)
            {
                sList[i].bookInfoNameText.text = searchSlot.sbooks.bookName;
                sList[i].bookInfoCountText.text = searchSlot.sbookCount.ToString();
                sList[i].bookInfoAuthorText.text = searchSlot.sbooks.bookAuthor;
                sList[i].bookInfoPublishetText.text = searchSlot.sbooks.bookPublisher;
                sList[i].bookInfoImage.sprite = searchSlot.sbooks.bookIcon;
                sList[i].ISBNInfoText.text = searchSlot.sbooks.bookIsbn.ToString();
            }
        }
       
       
        //Her açýdan yanlýþ
        //public void SaveButton(int i)
        //{
        //    JsonSave jsonSave = GetComponent<JsonSave>();
        //    BCSlot bCSlot = new BCSlot();
        //    bCSlot.bookCount = userInventory.BCInventory.bookcaseSlots[i].bookCount;
        //    bCSlot.books = userInventory.BCInventory.bookcaseSlots[i].books;
        //   
        //
        //}
        //public BCSlot bookcaseSlot;
        //public void LoadButton()
        //{
        //    JsonSave jsonSave = GetComponent<JsonSave>();
        //    bookcaseSlot = jsonSave.Json_Oku();
        //}

    }

}








