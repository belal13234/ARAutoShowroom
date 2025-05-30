using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerBasedPlacement : MonoBehaviour
{
    public GameObject vehiclePrefab;
    private ARTrackedImageManager trackedImageManager;
    private GameObject spawnedVehicle;

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            if (spawnedVehicle == null)
            {
                spawnedVehicle = Instantiate(vehiclePrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                ShowUI();
            }
        }
    }

    void ShowUI()
    {
        // UI logic to be added in Step 6
    }

    void OnDestroy()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
}
