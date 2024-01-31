using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Book", menuName = "Scriptable/Book")]
public class SOBooks : SOBook, IAddBook
{
    public Sprite BookIcon => BookIcon;
    public GameObject BookPrefab => BookPrefab;

    public string BookName => bookName;

    public string BookAuthor => bookAuthor;

    public string BookPublisher => bookPublisher;

    public bool CanStackable => canStackable;

    public string BookIsbn => bookIsbn;
}
