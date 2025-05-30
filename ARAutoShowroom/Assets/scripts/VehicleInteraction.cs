using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject vehicle;
    public Material[] bodyMaterials;
    public Material[] wheelMaterials;
    public AudioSource engineAudio;
    public Animator doorAnimator;
    public Toggle turntableToggle;
    private int bodyIndex = 0;
    private int wheelIndex = 0;
    private bool engineRunning = false;
    private float rotationSpeed = 30f;

    void Start()
    {
        engineAudio = vehicle.GetComponent<AudioSource>();
        if (engineAudio == null)
        {
            engineAudio = vehicle.AddComponent<AudioSource>();
            engineAudio.playOnAwake = false;
        }
        SetupButtons();
    }

    void SetupButtons()
    {
        Button colorButton = GameObject.Find("ChangeVehicleColor").GetComponent<Button>();
        colorButton.onClick.AddListener(ChangeBodyColor);

        Button wheelButton = GameObject.Find("ChangeWheelColor").GetComponent<Button>();
        wheelButton.onClick.AddListener(ChangeWheelColor);

        Button engineButton = GameObject.Find("StartStopEngine").GetComponent<Button>();
        engineButton.onClick.AddListener(ToggleEngine);

        turntableToggle.onValueChanged.AddListener(OnTurntableToggle);
    }

    void ChangeBodyColor()
    {
        bodyIndex = (bodyIndex + 1) % bodyMaterials.Length;
        vehicle.transform.GetChild(0).GetComponent<Renderer>().material = bodyMaterials[bodyIndex]; // Adjust child index
    }

    void ChangeWheelColor()
    {
        wheelIndex = (wheelIndex + 1) % wheelMaterials.Length;
        foreach (Renderer renderer in vehicle.GetComponentsInChildren<Renderer>())
        {
            if (renderer.name.Contains("Wheel")) renderer.material = wheelMaterials[wheelIndex];
        }
    }

    void ToggleEngine()
    {
        engineRunning = !engineRunning;
        if (engineRunning) engineAudio.Play();
        else engineAudio.Stop();
    }

    void OnTurntableToggle(bool isOn)
    {
        // Turntable logic to be updated in Update
    }

    void Update()
    {
        if (turntableToggle.isOn)
        {
            vehicle.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}