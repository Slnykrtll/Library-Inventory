using UnityEngine;

public class SOBook : ScriptableObject
{
    //SO için en temel class
    public Sprite bookIcon;
    public GameObject bookPrefab; //2Dyaptýðýmýz için gerekli olmayabilir.
    public string bookName;
    public string bookAuthor;
    public string bookPublisher;
    public bool canStackable; //gerekirse ýsbn içi kullanýlabilir.
    public string bookIsbn; //kalýtým alan classta kullanýlabilir.

}


