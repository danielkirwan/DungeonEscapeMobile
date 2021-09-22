using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShop : MonoBehaviour
{
    [SerializeField] GameObject _shopPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if(player != null)
            {
                UIManager.Instance.OpenShop(player._diamonds);
            }
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _shopPanel.SetActive(false);
            UIManager.Instance.TurnOffSelection();
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0: UIManager.Instance.UpdateShopSelection(72);
                break;
            case 1: UIManager.Instance.UpdateShopSelection(-40);
                break;
            case 2: UIManager.Instance.UpdateShopSelection(-141);
                break;
        }
    }



}
