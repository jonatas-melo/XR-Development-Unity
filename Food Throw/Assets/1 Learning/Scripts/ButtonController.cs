using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private float minPushDistance = -0.06f;
    // [SerializeField] private GameObject ballPrefab;

    [Space]
    
    [SerializeField] private UnityEvent onButtonPressed;

    private bool wasPushed;

    private void Update()
    {
        Vector3 buttonLocalPosition = transform.localPosition;
        buttonLocalPosition.x = 0;
        buttonLocalPosition.z = 0;
        buttonLocalPosition.y = Mathf.Clamp(buttonLocalPosition.y, minPushDistance, 0);

        transform.localPosition = buttonLocalPosition;

        if (!wasPushed && buttonLocalPosition.y < minPushDistance * 0.8) // pushed down 80%
        {
            // Instantiate(ballPrefab, Vector3.zero, Random.rotation);
            onButtonPressed.Invoke();
            wasPushed = true;
        }
        else if (buttonLocalPosition.y > minPushDistance * 0.5)
        {
            wasPushed = false;
        }
    }
}