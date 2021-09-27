using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : Singleton<Upgrades>
{
    [SerializeField] private Button DamageButton;
    [SerializeField] private int DamageButtonInitialCost;
    [SerializeField] private int DamageButtonIncrement;
    [SerializeField] private int DamageMaxLevel;
    [SerializeField] private int DamageUpIncrement;
    private int currDamageCost;
    [SerializeField] private Button WidthButton;
    [SerializeField] private int WidthButtonInitialCost;
    [SerializeField] private int WidthButtonIncrement;
    [SerializeField] private int WidthMaxLevel;
    [SerializeField] private float WidthUpIncrement;
    private int currWidthCost;
    [SerializeField] private Button AttackSpeedButton;
    [SerializeField] private int AttackSpeedInitialCost;
    [SerializeField] private int AttackSpeedButtonIncrement;
    [SerializeField] private int AttackSpeedMaxLevel;
    [SerializeField] private float AttackSpeedUpIncrement;
    private int currAttackSpeedCost;
    [SerializeField] private Button SpeedButton;
    [SerializeField] private int SpeedInitialCost;
    [SerializeField] private int SpeedButtonIncrement;
    [SerializeField] private int SpeedMaxLevel;
    [SerializeField] private int SpeedUpIncrement;
    private int currSpeedCost;
    [SerializeField] private Button RodsButton;
    [SerializeField] private int RodsInitialCost;
    [SerializeField] private int RodsButtonIncrement;
    [SerializeField] private int RodsMaxLevel;
    [SerializeField] private int RodsUpIncrement;
    private int currRodsCost;
    [SerializeField] private Button HealthButton;
    [SerializeField] private int HealthInitialCost;
    [SerializeField] private int HealthButtonIncrement;
    [SerializeField] private int HealthMaxLevel;
    [SerializeField] private int HealthUpIncrement;
    private int currHealthCost;
    [SerializeField] private Text EXPCounter;
    private List<Button> upgradeButtons;
    private List<int> initialCosts;
    void Start()
    {
        currDamageCost = DamageButtonInitialCost;
        currWidthCost = WidthButtonInitialCost;
        currAttackSpeedCost = AttackSpeedInitialCost;
        currSpeedCost = SpeedInitialCost;
        currRodsCost = RodsInitialCost;
        currHealthCost = HealthInitialCost;
        
        initialCosts = new List<int>();
        initialCosts.Add(DamageButtonInitialCost);
        initialCosts.Add(WidthButtonInitialCost);
        initialCosts.Add(AttackSpeedInitialCost);
        initialCosts.Add(SpeedInitialCost);
        initialCosts.Add(RodsInitialCost);
        initialCosts.Add(HealthInitialCost);

        upgradeButtons = new List<Button>();
        upgradeButtons.Add(DamageButton);
        upgradeButtons.Add(WidthButton);
        upgradeButtons.Add(AttackSpeedButton);
        upgradeButtons.Add(SpeedButton);
        upgradeButtons.Add(RodsButton);
        upgradeButtons.Add(HealthButton);
        Debug.Log("player exp in upgrade screen" + PlayerStats.Current.Exp);
    }
    public void UpgradeDamage()
    {
        if(PlayerStats.Current.Exp >= currDamageCost && PlayerStats.Current.DamageLevel < DamageMaxLevel)
        {
            UpdateExpCounter(currDamageCost);
            PlayerStats.Current.Exp -= currDamageCost;
            currDamageCost += DamageButtonIncrement;
            UpdateUpgradeGraphic(DamageButton, DamageButtonIncrement);
            PlayerStats.Current.DamageUp(DamageUpIncrement);
        } 
        else
        {
            AudioManager.Current.PlayUIUnavailableSFX();
        }
    }
    public void UpgradeWidth()
    {
        if(PlayerStats.Current.Exp >= currWidthCost && PlayerStats.Current.WidthLevel < WidthMaxLevel)
        {
            UpdateExpCounter(currWidthCost);
            PlayerStats.Current.Exp -= currWidthCost;
            currWidthCost += WidthButtonIncrement;
            UpdateUpgradeGraphic(WidthButton, WidthButtonIncrement);
            PlayerStats.Current.WidthUp(WidthUpIncrement);
        }
        else
        {
            AudioManager.Current.PlayUIUnavailableSFX();
        }
    }
    public void UpgradeAttackSpeed()
    {
        if(PlayerStats.Current.Exp >= currAttackSpeedCost && PlayerStats.Current.AttackSpeedLevel < AttackSpeedMaxLevel)
        {
            UpdateExpCounter(currAttackSpeedCost);
            PlayerStats.Current.Exp -= currAttackSpeedCost;
            currAttackSpeedCost += AttackSpeedButtonIncrement;
            UpdateUpgradeGraphic(AttackSpeedButton, AttackSpeedButtonIncrement);
            PlayerStats.Current.AttackSpeedUp(AttackSpeedUpIncrement);
        }
        else
        {
            AudioManager.Current.PlayUIUnavailableSFX();
        }
    }
    public void UpgradeSpeed()
    {
        if(PlayerStats.Current.Exp >= currSpeedCost && PlayerStats.Current.SpeedLevel < SpeedMaxLevel)
        {
            UpdateExpCounter(currSpeedCost);
            PlayerStats.Current.Exp -= currSpeedCost;
            currSpeedCost += SpeedButtonIncrement;
            UpdateUpgradeGraphic(SpeedButton, SpeedButtonIncrement);
            PlayerStats.Current.SpeedUp(SpeedUpIncrement);
        }
        else
        {
            AudioManager.Current.PlayUIUnavailableSFX();
        }
    }
    public void UpgradeRods()
    {
        if(PlayerStats.Current.Exp >= currRodsCost && PlayerStats.Current.RodsLevel < RodsMaxLevel)
        {
            UpdateExpCounter(currRodsCost);
            PlayerStats.Current.Exp -= currRodsCost;
            currRodsCost += RodsButtonIncrement;
            UpdateUpgradeGraphic(RodsButton, RodsButtonIncrement);
            PlayerStats.Current.RodsUp(RodsUpIncrement);
        }
        else
        {
            AudioManager.Current.PlayUIUnavailableSFX();
        }
    }
    public void UpgradeHealth()
    {
        if(PlayerStats.Current.Exp >= currHealthCost && PlayerStats.Current.HealthLevel < HealthMaxLevel)
        {
            UpdateExpCounter(currHealthCost);
            PlayerStats.Current.Exp -= currHealthCost;
            currHealthCost += HealthButtonIncrement;
            UpdateUpgradeGraphic(HealthButton, HealthButtonIncrement);
            PlayerStats.Current.HealthUp(HealthUpIncrement);
        }
        else
        {
            AudioManager.Current.PlayUIUnavailableSFX();
        }
    }
    private void UpdateUpgradeGraphic(Button button, int increment)
    {
        Text[] texts = button.GetComponentsInChildren<Text>();
        Text skillLevelText = texts[1];
        Text buttonPriceText = texts[0];
        skillLevelText.text = (int.Parse(skillLevelText.text) + 1).ToString();
        buttonPriceText.text = (int.Parse(buttonPriceText.text) + increment).ToString();
    }
    private void UpdateExpCounter(int cost)
    {
        EXPCounter.text  = (int.Parse(EXPCounter.text) - cost).ToString();
    }

    public void ResetUpgradeGraphics()
    {
        for(int i = 0; i < upgradeButtons.Count; i++)
        {
            Text[] texts = upgradeButtons[i].GetComponentsInChildren<Text>();
            Text skillLevelText = texts[1];
            Text buttonPriceText = texts[0];
            skillLevelText.text = "1";
            buttonPriceText.text = initialCosts[i].ToString();
        }
        EXPCounter.text  = PlayerStats.Current.Exp.ToString();
    }
    public void InitializeUpgradeGraphics()
    {
        Debug.Log("PlayerStats.Current.DamageLevel: " + PlayerStats.Current.DamageLevel);
        Debug.Log("PlayerStats.Current.WidthLevel: " + PlayerStats.Current.WidthLevel);
        Debug.Log("PlayerStats.Current.AttackSpeedLevel: " + PlayerStats.Current.AttackSpeedLevel);
        Debug.Log("PlayerStats.Current.SpeedLevel: " + PlayerStats.Current.SpeedLevel);
        Debug.Log("PlayerStats.Current.RodsLevel: " + PlayerStats.Current.RodsLevel);
        Debug.Log("PlayerStats.Current.HealthLevel: " + PlayerStats.Current.HealthLevel);
        for(int i = 0; i < upgradeButtons.Count; i++)
        {
            Text[] texts = upgradeButtons[i].GetComponentsInChildren<Text>();
            Text skillLevelText = texts[1];
            Text buttonPriceText = texts[0];
            switch(i)
            {
                case 0:
                    skillLevelText.text = PlayerStats.Current.DamageLevel.ToString();
                    buttonPriceText.text = (DamageButtonInitialCost + (DamageButtonIncrement * PlayerStats.Current.DamageLevel - 1)).ToString();
                    break;
                case 1:
                    skillLevelText.text = PlayerStats.Current.WidthLevel.ToString();
                    buttonPriceText.text = (WidthButtonInitialCost + (WidthButtonIncrement * PlayerStats.Current.WidthLevel - 1)).ToString();
                    break;
                case 2:
                    skillLevelText.text = PlayerStats.Current.AttackSpeedLevel.ToString();
                    buttonPriceText.text = (AttackSpeedInitialCost + (AttackSpeedButtonIncrement * PlayerStats.Current.AttackSpeedLevel - 1)).ToString();
                    break;
                case 3:
                    skillLevelText.text = PlayerStats.Current.SpeedLevel.ToString();
                    buttonPriceText.text = (SpeedInitialCost + (SpeedButtonIncrement * PlayerStats.Current.SpeedLevel - 1)).ToString();
                    break;
                case 4:
                    skillLevelText.text = PlayerStats.Current.RodsLevel.ToString();
                    buttonPriceText.text = (RodsInitialCost + (RodsButtonIncrement * PlayerStats.Current.RodsLevel - 1)).ToString();
                    break;
                case 5:
                    skillLevelText.text = PlayerStats.Current.HealthLevel.ToString();
                    buttonPriceText.text = (HealthInitialCost + (HealthButtonIncrement * PlayerStats.Current.HealthLevel - 1)).ToString();
                    break;
                default:
                    break;
            }
            
        }
        EXPCounter.text  = PlayerStats.Current.Exp.ToString();
    }
}
