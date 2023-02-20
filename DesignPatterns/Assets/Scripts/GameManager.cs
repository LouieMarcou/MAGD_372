using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TMP_Text vehicleText;

    public Vehicle currentVehicle;
    private List<Vehicle> vehicles = new List<Vehicle>();

    private void Awake()
    {
        if(Instance != null && Instance == this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetVehicle(Vehicle vehicle)
    {
        currentVehicle = vehicle;
        vehicleText.text = vehicle.Name;
        vehicles.Add(currentVehicle);
        ShowDetails();
        //DisplayVehicles();

    }

    private void ShowDetails()
    {
        vehicleText.text = currentVehicle.Name + " : \n " + currentVehicle.Person;
    }

    private void DisplayVehicles()
    {
        vehicleText.text = "";
        foreach(Vehicle vec in vehicles)
        {
            vehicleText.text += vec.Name + " , " ;
        }
    }

    public void RemoveVehicle()
    {

    }
}
