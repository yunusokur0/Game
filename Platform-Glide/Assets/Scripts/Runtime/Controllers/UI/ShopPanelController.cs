using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelController : MonoBehaviour
{
    public GameObject ShopMenu;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(ToggleShopMenu);
    }

    public void ToggleShopMenu()
    {
        ShopMenu.SetActive(!ShopMenu.activeSelf);
    }

}