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

    [SerializeField] private int exp = 0;
    public int Exp 
    {
        get {return exp;} 
        set {exp = value;}
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
