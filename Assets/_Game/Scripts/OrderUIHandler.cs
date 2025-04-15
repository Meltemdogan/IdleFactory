using UnityEngine;

public class OrderUIHandler : MonoBehaviour
{
    public GameObject orderUI;
    public GameObject orderButton;
    public GameObject orderPanel;

    private void Start()
    {
        orderButton.SetActive(true);
        orderPanel.SetActive(false);
    }

    public void ToggleOrderUI()
    {
        orderUI.SetActive(!orderUI.activeSelf);
        orderButton.SetActive(!orderButton.activeSelf);
        orderPanel.SetActive(!orderPanel.activeSelf);
    }
}
