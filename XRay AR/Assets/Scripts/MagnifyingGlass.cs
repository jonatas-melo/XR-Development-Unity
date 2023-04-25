using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    private void Update()
    {
        Vector3 middleOfScreen = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        Vector3 middleOfLens = transform.position;
        Vector3 directionToGlass = (middleOfLens - middleOfScreen).normalized;
        
        if (Physics.Raycast(transform.position, directionToGlass, out RaycastHit hit))
        {
            Organ organ = hit.collider.gameObject.GetComponent<Organ>();
            if (organ != null)
            {
                organ.FoundImage();
            }
        }
    }
}