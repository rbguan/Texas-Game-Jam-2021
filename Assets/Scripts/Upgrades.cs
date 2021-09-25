using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private Button DamageButton;
    [SerializeField] private int DamageButtonInitialCost;
    [SerializeField] private int DamageButtonIncrement;
    [SerializeField] private int DamageMaxLevel;
    [SerializeField] private Button WidthButton;
    [SerializeField] private int WidthButtonIncrement;
    [SerializeField] private int WidthMaxLevel;
    [SerializeField] private Button AttackSpeedButton;
    [SerializeField] private int AttackSpeedButtonIncrement;
    [SerializeField] private int AttackSpeedMaxLevel;
    [SerializeField] private Button SpeedButton;
    [SerializeField] private int SpeedButtonIncrement;
    [SerializeField] private int SpeedMaxLevel;
    [SerializeField] private Button RodsButton;
    [SerializeField] private int RodsButtonIncrement;
    [SerializeField] private int RodsMaxLevel;
    [SerializeField] private Button HealthButton;
    [SerializeField] private int HealthButtonIncrement;
    [SerializeField] private int HealthMaxLevel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
