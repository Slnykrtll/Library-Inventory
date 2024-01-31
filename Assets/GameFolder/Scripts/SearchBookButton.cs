using LibraryInvantory.ScriptableUi;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchBookButton : MonoBehaviour
{
    public TMP_InputField searchInput;
    public Button searchButton;
    public TMP_Text searchResultText;
    public Inventory inventory;
    public SOSearch SInventory;

    InventoryUIController inventoryUICont;
    
    private void Start()
    {
        inventoryUICont = GetComponent<InventoryUIController>();
    }

    public void SearchButtonClicked()
    {
        string searchText = searchInput.text.ToLower();

        if (searchText != null && searchText != "")
        {
            inventory.SearchBooks(searchText); 
            inventoryUICont.SearchUpdateUI();           
        } 
    }
    
}

