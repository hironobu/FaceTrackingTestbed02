using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FaceTracking : MonoBehaviour
{
    [SerializeField] private ARFaceManager faceManager;

    private void OnEnable()
    {
        faceManager.facesChanged += OnFaceChanged;
    }

    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceChanged;
    }

    private void OnFaceChanged(ARFacesChangedEventArgs eventArgs)
    {
        if (eventArgs.updated.Count != 0)
        {
            var arFace = eventArgs.updated[0];
            if (arFace.trackingState == TrackingState.Tracking && (ARSession.state > ARSessionState.Ready))
            {
                Debug.Log(arFace.transform.position);
            }
        }
    }
}
