using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;
    public GameObject arModel; // Reference to your "AR_Model" GameObject

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            UpdateARModel(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateARModel(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            arModel.SetActive(false);
        }
    }

    void UpdateARModel(ARTrackedImage trackedImage)
    {
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            arModel.SetActive(true);
            arModel.transform.position = trackedImage.transform.position;
            arModel.transform.rotation = trackedImage.transform.rotation;
        }
        else
        {
            arModel.SetActive(false);
        }
    }
}