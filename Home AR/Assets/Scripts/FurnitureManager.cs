using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class FurnitureManager : MonoBehaviour
{
    [SerializeField] private List<FurnitureData> _furnitureDataList = new List<FurnitureData>();
    [SerializeField] private GameObject _furnitureUIPrefab;
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private ARPlacementInteractable _placementInteractable;
    [SerializeField] private Color _highlightColor;
    [SerializeField] private Color _unhighlightColor;

    private FurnitureMenuOption _currentMenuOption;

    private void Start()
    {
        foreach (var furnitureData in _furnitureDataList)
        {
            var uiPrefab = Instantiate(_furnitureUIPrefab, _contentTransform);
            var menuOption = uiPrefab.GetComponent<FurnitureMenuOption>();

            menuOption.nameText.text = furnitureData.furnitureName;
            menuOption.iconImage.texture = furnitureData.furnitureIcon;
            menuOption.button.onClick.AddListener(() => SelectFurniture(furnitureData, menuOption));
        }
    }

    private void SelectFurniture(FurnitureData furnitureData, FurnitureMenuOption newMenuOption)
    {
        if (_currentMenuOption != null)
        {
            _currentMenuOption.backgroundImage.color = _unhighlightColor;
        }

        _currentMenuOption = newMenuOption;
        _placementInteractable.placementPrefab = furnitureData.furniturePrefab;
        newMenuOption.backgroundImage.color = _highlightColor;
    }
}
