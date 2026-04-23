using UnityEngine;
using TMPro;

public class DeckManager : MonoBehaviour
{
    public float energyconsumption = 1;

    public float battery1_power;
    public TextMeshProUGUI bat1;

    public float battery2_power;
    public TextMeshProUGUI bat2;


    public bool battery1Installed;
    public bool battery2Installed;

    public bool battery1InSunButtery;
    public bool battery2InSunButtery;

    public bool StationPower;

    public Transform batteryOut;
    public Transform batteryIn;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip clip_On;
    public AudioClip clip_Off;

    public bool played = false;


    public float endpower = 200;


    void Start()
    {
        bat1.text = ((int)battery1_power).ToString();
        bat2.text = ((int)battery2_power).ToString();
    }

    void Update()
    {
        if (battery1InSunButtery)
        {
            SunButtery(ref battery1_power);
            bat1.text = ((int)battery1_power).ToString();

            if (!played)
            {
                audioSource2.PlayOneShot(clip_On);
                played = true;
            }
        }
        

        if (battery2InSunButtery)
        {
            SunButtery(ref battery2_power);
            bat2.text = ((int)battery2_power).ToString();
            if(!played)
            {
                audioSource2.PlayOneShot(clip_On);
                played = true;
            }
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
                bat1.text = ((int)battery1_power).ToString();
                if (!played)
                {
                    audioSource1.PlayOneShot(clip_On);
                    played = true;
                }

            }
            else if (battery2Installed)
            {
                battery2_power -= energyconsumption * Time.deltaTime;
                bat2.text = ((int)battery2_power).ToString();
                if (!played)
                {
                    audioSource1.PlayOneShot(clip_On);
                    played = true;
                }
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
