using LibraryInvantory.ScriptableUi;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public SOBookcase bookcase;
    public InventoryUIController inventoryUi;

    //public  Sprite BookIcon;
    public TMP_InputField InputBookName;
    public TMP_Text InputBookNameText;


    public TMP_InputField InputBookAuthor;
    public TMP_Text InputBookAuthorText;

    public TMP_InputField InputBookPublisher;
    public TMP_Text InputBookPublisherText;

    public Toggle InputBookCanStackable;

    public TMP_InputField InputBookIsbn;
    public TMP_Text InputBookIsbnText;

    [SerializeField] private SOBook AddPrefabs;

    public void AddBooks()
    {
        BookFactory bookFactory = new BookFactory();
        Sprite bookIcon = null; 
        GameObject bookPrefab = AddPrefabs.bookPrefab;
        string bookName = InputBookNameText.text;
        string bookAuthor = InputBookAuthorText.text;
        string bookPublisher = InputBookPublisherText.text;
        bool canStackable = InputBookCanStackable.isOn;
        string isbn = InputBookIsbnText.text;

        SOBook newBookPrefab = Instantiate(AddPrefabs);
        newBookPrefab.bookIcon = bookIcon;
        newBookPrefab.bookPrefab = bookPrefab;
        newBookPrefab.bookName = bookName;
        newBookPrefab.bookAuthor = bookAuthor;
        newBookPrefab.bookPublisher = bookPublisher;
        newBookPrefab.canStackable = canStackable;
        newBookPrefab.bookIsbn = isbn;

        bookcase.BookcaseAddBook(newBookPrefab);
        inventoryUi.BookcaseUpdateUI();

        IAddBook newBook = bookFactory.CreateBook(bookIcon, bookPrefab, bookName, bookAuthor, bookPublisher, canStackable, isbn);

        Debug.Log("BookName" + newBook.BookName + " BookAuthor " + newBook.BookAuthor + " Publisher" + newBook.BookPublisher);
    }

}

