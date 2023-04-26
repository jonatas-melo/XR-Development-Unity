using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class FurniturePlacementInteractable : ARPlacementInteractable
{
    private List<RaycastResult> _raycastResults = new();

    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        // return false if an object is already selected
        if (gestureInteractor.interactablesSelected.Count > 0)
        {
            return false;
        }
        
        // Get EventData of exactly was tapped
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = gesture.startPosition
        };

        // return false if any UI element is hit
        EventSystem.current.RaycastAll(eventData, _raycastResults);
        return _raycastResults.Count <= 0 && base.CanStartManipulationForGesture(gesture);
    }
}
