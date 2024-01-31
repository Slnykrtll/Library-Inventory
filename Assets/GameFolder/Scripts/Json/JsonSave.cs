using LibraryInvantory.ScriptableUi;
using UnityEngine;


public class JsonSave : MonoBehaviour
{
    InventoryUIController inventoryUi;
    //public void Json_Kaydet(BCSlot bCSlot)
    //{
    //    string dataJsonFormatlý = UnityEngine.JsonUtility.ToJson(bCSlot);
    //    System.IO.File.WriteAllText(Application.persistentDataPath + "/SlotData.json", dataJsonFormatlý);

    //}
    //public BCSlot Json_Oku()
    //{
    //    string jsonData = System.IO.File.ReadAllText(Application.persistentDataPath + "/SlotData.json");
    //    BCSlot bookcase = UnityEngine.JsonUtility.FromJson<BCSlot>(jsonData);
    //    return bookcase;
    //}
    public void Update()
    {
        //inventoryUi.BookcaseUpdateUI();
    }
    public void Save(SOBookcase data, string BookcaseInventory)
    {
        string dataJsonFormatli = UnityEngine.JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/BookcaseSlot.json", dataJsonFormatli);
        Debug.Log("kaydedildi");
    }

    //public SOBookcase Load (string BookcaseInventory) 
    //{
    //    string jsonData = System.IO.File.ReadAllText(Application.persistentDataPath + "/BookcaseSlot.json");
    //    SOBookcase data = UnityEngine.JsonUtility.FromJson<SOBookcase>(jsonData);
    //    return data;
    //}
    public SOBookcase LoadBookcaseData(string BookcaseInventory)
    {
        string jsonData = System.IO.File.ReadAllText(Application.persistentDataPath + "/BookcaseSlot.json");
        //SOBookcase data = UnityEngine.JsonUtility.FromJson<SOBookcase>(jsonData);
        SOBookcase data = ScriptableObject.CreateInstance<SOBookcase>();
        UnityEngine.JsonUtility.FromJsonOverwrite(jsonData, data);
        Debug.Log("yüklendi");
        
        return data;

    }
    


}
