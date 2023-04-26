using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ToggleButtonMenuController : MonoBehaviour
{
    [SerializeField] private RectTransform menuTransform;
    [SerializeField] private float openPosition = 0f;
    [SerializeField] private float closePosition = -200f;
    [SerializeField] private float animationSpeed = 0.5f;

    private bool _isOpen;

    private void Start()
    {
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        _isOpen = !_isOpen;
        var targetPosition = new Vector2(0, _isOpen ? openPosition : closePosition);
        menuTransform.DOAnchorPos(targetPosition, animationSpeed);
    }
}
