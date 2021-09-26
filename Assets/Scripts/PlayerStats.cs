using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] private int maxRods = 2;
    public int MaxRods 
    {
        get {return maxRods;} 
        set {maxRods = value;}
    }
    [SerializeField] private float attackCooldown = 2f;
    public float AttackCooldown 
    {
        get {return attackCooldown;} 
        set {attackCooldown = value;}
    }
    [SerializeField] private int lightningDamage = 1;
    public int LightningDamage 
    {
        get {return lightningDamage;} 
        set {lightningDamage = value;}
    }
    [SerializeField] private int exp = 0;
    public int Exp 
    {
        get {return exp;} 
        set {exp = value;}
    }
    [SerializeField] private float width = 1f;
    public float Width 
    {
        get {return width;} 
        set {width = value;}
    }
    public float AttackSpeed
    {
        get {return 1f/attackCooldown;} 
    }
    [SerializeField] private int speed = 15;
    public int Speed
    {
        get {return speed;} 
        set {speed = value;}
    }
    private int currentHealth;
    public int CurrentHealth
    {
        get{return currentHealth;}
        set
        {
            currentHealth = value;
            if (currentHealth <= 0)
                Die();
        }
    }
    public int fullHealth;
    [SerializeField] private int startRods;
    [SerializeField] private float startAttackCooldown;
    [SerializeField] private int startLightningDamage;
    [SerializeField] private float startWidth;
    [SerializeField] private int startHealth;
    [SerializeField] private int startSpeed;
    private void Update()
    {
        //TODO: Remove this
        if (Input.GetKeyDown(KeyCode.LeftControl))
            CurrentHealth = 0;
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            for (int i = Entity.entities.Count - 1; i >= 0; i--)
            {
                Entity entity = Entity.entities[i];
                entity.Destroy();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        AudioManager.Current.PlayPlayerHitSFX();
    }

    public void DamageUp(int increment)
    {
        lightningDamage += increment;
    }
    public void WidthUp(float increment)
    {
        width += increment;
    }
    public void AttackSpeedUp(float increment)
    {
        attackCooldown -= increment;
    }
    public void SpeedUp(int increment)
    {
        speed += increment;
    }
    public void RodsUp(int increment)
    {
        maxRods += increment;
    }
    public void HealthUp(int increment)
    {
        fullHealth += increment;
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        ResetStats();
    }

    private int damageLevel;
    public int DamageLevel
    {
        get {return damageLevel;} 
        set {damageLevel = value;}
    }
    private int widthLevel;
    public int WidthLevel
    {
        get {return widthLevel;} 
        set {widthLevel = value;}
    }
    private int attackSpeedLevel;
    public int AttackSpeedLevel
    {
        get {return attackSpeedLevel;} 
        set {attackSpeedLevel = value;}
    }
    private int speedLevel;
    public int SpeedLevel
    {
        get {return speedLevel;} 
        set {speedLevel = value;}
    }
    private int rodsLevel;
    public int RodsLevel
    {
        get {return rodsLevel;} 
        set {rodsLevel = value;}
    }
    private int healthLevel;
    public int HealthLevel
    {
        get {return healthLevel;} 
        set {healthLevel = value;}
    }

    public void ResetStats()
    {
        maxRods = startRods;
        attackCooldown = startAttackCooldown;
        width = startWidth;
        speed = startSpeed;
        lightningDamage = startLightningDamage;
        fullHealth = startHealth;
        currentHealth = fullHealth;
        exp = 0;
        damageLevel = 1;
        widthLevel = 1;
        attackSpeedLevel = 1;
        speedLevel = 1;
        rodsLevel = 1;
        healthLevel = 1;
    }

    private void Die()
    {
        AudioManager.Current.PlayPlayerDeathSFX();
        LevelLoadTransitions levelLoadTransition = FindObjectOfType<LevelLoadTransitions>();
        levelLoadTransition.Lose();
        //gameObject.SetActive(false);
    }

}
