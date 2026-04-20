using UnityEngine;
using System;

public class SpecificMaterialChanger : MonoBehaviour
{
    [Header("Target Material")]
    [SerializeField] private Material targetMaterial;
    [SerializeField] private string sizePropertyName = "_OnOff";

    [Header("Branch Settings")]
    [SerializeField] private float TurnBranch = 0f;

    void Start()
    {
        ApplySize();
    }

    public void ApplySize()
    {
        if (targetMaterial != null && targetMaterial.HasProperty(sizePropertyName))
        {
            targetMaterial.SetFloat(sizePropertyName, TurnBranch);
        }
    }


    public void SetOutLine(bool Branch) //Для других скриптов, true false использовать 
    {
        TurnBranch = Convert.ToSingle(Branch); ;
        ApplySize();
    }
}

