using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{ 
    JsonSave jsonSave;
    public SOBookcase bookcaseData;
    void Start()
    {
        jsonSave = GetComponent<JsonSave>();
    }
    public void SaveBookcaseData()
    { 
        jsonSave.Save(bookcaseData, "BookcaseData");
    }
    public void LoadBookcaseData()
    {
        bookcaseData = jsonSave.LoadBookcaseData("BookcaseData");
    }
}
