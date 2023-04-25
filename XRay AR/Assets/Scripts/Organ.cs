using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Organ : MonoBehaviour
{
    [SerializeField] private Image organImage;

    public void FoundImage()
    {
        organImage.color = Color.white;
    }
}