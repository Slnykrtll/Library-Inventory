using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject bookcasePanel;
    [SerializeField] GameObject borrowedPanel;
    [SerializeField] GameObject returnedPanel;
    [SerializeField] GameObject searchPanel;
    [SerializeField] GameObject addBookPanel;

    bool isInventoryOpen;

    //private void Update()
    //{
    //    Arama yaparken ya da yeni kitap eklerken çalýþmamalýlar.
    //    InventoryShortcuts(KeyCode.Q, bookcasePanel);
    //    InventoryShortcuts(KeyCode.W, borrowedPanel);
    //    InventoryShortcuts(KeyCode.E, returnedPanel);
    //    InventoryShortcuts(KeyCode.R, searchPanel);
    //    InventoryShortcuts(KeyCode.T, addBookPanel);
    //}
    private void InventoryShortcuts(KeyCode keyCode, GameObject inventoryPanel)
    {
        if (Input.GetKeyDown(keyCode))
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryPanel.SetActive(isInventoryOpen);
        }
    }
    public void BookCaseButton()
    {
        mainMenuPanel.SetActive(false);
        bookcasePanel.SetActive(true);
    }
    public void SearchButton()
    {
        mainMenuPanel.SetActive(false);
        searchPanel.SetActive(true);
    }
    public void AddBookButton()
    {
        mainMenuPanel.SetActive(false);
        addBookPanel.SetActive(true);
    }
    public void ReturnedButton()
    {
        mainMenuPanel.SetActive(false);
        returnedPanel.SetActive(true);
    }
    public void BorrowedButton()
    {
        mainMenuPanel.SetActive(false);
        borrowedPanel.SetActive(true);
    }
    public void BackButton()
    {
        bookcasePanel.SetActive(false);
        borrowedPanel.SetActive(false);
        returnedPanel.SetActive(false);
        searchPanel.SetActive(false);
        addBookPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

    }

}
