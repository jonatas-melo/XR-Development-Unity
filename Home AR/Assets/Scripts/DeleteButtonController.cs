using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteButtonController : MonoBehaviour
{
    [SerializeField] private Button deleteButton;

    private GameObject _currentSelectedObject;

    private void Start()
    {
        deleteButton.onClick.AddListener(ButtonClicked);
    }

    public void SelectEnter(SelectEnterEventArgs args)
    {
        _currentSelectedObject = args.interactableObject.transform.gameObject;
        deleteButton.gameObject.SetActive(true);
    }

    public void SelectExit(SelectExitEventArgs args)
    {
        deleteButton.gameObject.SetActive(false);
    }

    private void ButtonClicked()
    {
        Destroy(_currentSelectedObject);
    }
}