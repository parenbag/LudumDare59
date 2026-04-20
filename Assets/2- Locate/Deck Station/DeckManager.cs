using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public float energyconsumption = 1;

    public float battery1_power;
    public float battery2_power;

    public bool battery1Installed;
    public bool battery2Installed;

    public bool battery1InSunButtery;
    public bool battery2InSunButtery;

    public bool StationPower;

    public Transform batteryOut;
    public Transform batteryIn;


    public float endpower = 200;


    void Start()
    {
        
    }

    void Update()
    {
        if (battery1InSunButtery)
        {
            SunButtery(ref battery1_power);
        }
        if (battery2InSunButtery)
        {
            SunButtery(ref battery2_power);
        }
        PowerLogic();

        
    }

    void PowerLogic()
    {
        if (battery1Installed && battery1_power >= 1 || battery2Installed && battery2_power >= 1)
        {
            if (battery1Installed)
            {
                battery1_power -= energyconsumption * Time.deltaTime;
            }
            else if (battery2Installed)
            {
                battery2_power -= energyconsumption * Time.deltaTime;
            }

            StationPower = true;
        }
        else
        {
            StationPower = false;
        }
        return;
    }





    void SunButtery(ref float battery)
    {
        if (battery <= endpower)
        {
            battery += energyconsumption * Time.deltaTime;

        }

    }
}
