using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _gemCount;
    [SerializeField] private Image _selectionImage;
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UImnanager instance null");
            }
            return _instance;
        }
    }

    public void OpenShop(int gemCount)
    {
        _gemCount.text = gemCount + "G";
    }

    private void Awake()
    {
        _instance = this;
    }

    public void TurnOffSelection()
    {
        _selectionImage.gameObject.SetActive(false);
    }

    public void UpdateShopSelection(float yPos)
    {
        _selectionImage.gameObject.SetActive(true);
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

}
