using UnityEngine;
public interface IAddBook
{
    Sprite BookIcon { get; }
    GameObject BookPrefab { get; }
    public string BookName { get;  }
    public string BookAuthor { get;  }
    public string BookPublisher { get; }
    public bool CanStackable { get;  }
    public string BookIsbn { get; }

  

}

