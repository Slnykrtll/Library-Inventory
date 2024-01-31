using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BookFactory : Factory
{
    public override IAddBook CreateBook(Sprite BookIcon,GameObject BookPrefabs,string BookName, string BookAuthor, string BookPublisher,
        bool Canstakable, string Isbn)
    {
        SOBooks newBook = ScriptableObject.CreateInstance<SOBooks>();
        newBook.bookIcon = BookIcon;
        newBook.bookName = BookName;
        newBook.bookPrefab = BookPrefabs;
        newBook.bookAuthor = BookAuthor;
        newBook.bookPublisher = BookPublisher;
        newBook.canStackable = Canstakable;
        newBook.bookIsbn = Isbn;
        return newBook;
    }
}
