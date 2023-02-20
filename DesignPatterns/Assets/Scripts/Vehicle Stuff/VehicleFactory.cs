using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFactory : MonoBehaviour
{
    public Vehicle GetVehicleType(string vehicleType)
    {
        switch(vehicleType)
        {
            case "air":
                return new Airplane();
            case "land":
                return new Car();
            case "water":
                return new Ship();

            default:
                return null;
        }

    }
    
    public void PrintNewVehicle(string type)
    {
        Vehicle obj = GetVehicleType(type);
        GameManager.Instance.SetVehicle(obj);
        
    }

}
