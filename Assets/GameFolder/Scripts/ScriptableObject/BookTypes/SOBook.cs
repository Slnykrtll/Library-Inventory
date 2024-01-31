using UnityEngine;

public class SOBook : ScriptableObject
{
    //SO i�in en temel class
    public Sprite bookIcon;
    public GameObject bookPrefab; //2Dyapt���m�z i�in gerekli olmayabilir.
    public string bookName;
    public string bookAuthor;
    public string bookPublisher;
    public bool canStackable; //gerekirse �sbn i�i kullan�labilir.
    public string bookIsbn; //kal�t�m alan classta kullan�labilir.

}


