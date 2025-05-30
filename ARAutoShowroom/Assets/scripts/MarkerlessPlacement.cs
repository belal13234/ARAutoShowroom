using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerlessPlacement : MonoBehaviour
{
    public GameObject vehiclePrefab;
    private ARRaycastManager arRaycastManager;
    private GameObject spawnedVehicle;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                if (spawnedVehicle == null)
                {
                    spawnedVehicle = Instantiate(vehiclePrefab, hitPose.position, hitPose.rotation);
                    ShowUI();
                }
            }
        }
    }

    void ShowUI()
    {
        // UI logic to be added in Step 6
    }
}