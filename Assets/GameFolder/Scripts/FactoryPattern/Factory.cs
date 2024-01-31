using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory 
{
    public abstract IAddBook CreateBook(Sprite BookIcon, GameObject BookPrefabs,string BookName, string BookAuthor, string BookPublisher, 
        bool Canstakable, string Isbn);
}
