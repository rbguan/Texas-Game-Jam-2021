using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerLightning : MonoBehaviour
{
    [SerializeField] private GameObject lightningRodPrefab;
    [SerializeField] private GameObject lightningAttackPrefab;
    [SerializeField] private LightningStrike lightningSfx;
    [SerializeField] private Camera myCamera;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private float lightningLifeTime = 1f;
    private List<GameObject> lightningRodsSummoned;
    private List<GameObject> lightningSummoned;
    private bool canPlaceRod = true;
    private float lightningCooldownLeft;
    private bool canAttack = true;
    [SerializeField] private LayerMask rodPlacementLayermask = 45;
    private Coroutine rodResetCoroutine = null;

    [Header("Rod Placement Variables")]
    [SerializeField] private GameObject RodPlaceParticlePrefab;
    [SerializeField] private float rodSpawnHeight = 20f;
    [SerializeField] private float rodSpawnTime = .1f;
    [SerializeField] private float rodShakeDuration = .5f;
    [SerializeField] private float rodShakeStrength = .5f;
    [SerializeField] private int rodShakeVibrato = 3;
    [SerializeField] private float rodShakeRandomness = 45;

    [Header("Attack Shake Variables")]
    [SerializeField] private float attackShakeDuration = .75f;
    [SerializeField] private float attackShakeStrength = 1f;
    [SerializeField] private int attackShakeVibrato = 5;
    [SerializeField] private float attackShakeRandomness = 45;
    public Camera MyCamera
    {
        get
        {
            if (!myCamera)
                myCamera = FindObjectOfType<Camera>();
            return myCamera;
        }
    }

    void Start()
    {
        lightningRodsSummoned = new List<GameObject>();
        lightningSummoned = new List<GameObject>();
        // if (!myCamera)
        //         myCamera = FindObjectOfType<Camera>();
        // mySFXCamera = myCamera.GetComponentsInChildren<Camera>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canPlaceRod)
            {
                PlaceRod();
            } 
            else
            {
                //ERROR NOISE
                AudioManager.Current.PlayUIUnavailableSFX();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetRods();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            LightningAttack();
        }
    }

    private void PlaceRod()
    {
        if(lightningRodsSummoned.Count == PlayerStats.Current.MaxRods - 1)
        {
            canPlaceRod = false;
        }
        Ray ray = MyCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 rodSpawnPosition;
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject.layer == 8)
            {
                MyCamera.DOShakePosition(rodShakeDuration, rodShakeStrength, rodShakeVibrato, rodShakeRandomness);
                rodSpawnPosition = hit.point;
                rodSpawnPosition.y += rodSpawnHeight;
                GameObject newRod = GameObject.Instantiate(lightningRodPrefab, rodSpawnPosition, Quaternion.identity);
                newRod.transform.DOMove(hit.point, rodSpawnTime);
                lightningRodsSummoned.Add(newRod);
                GameObject rodParticles = GameObject.Instantiate(RodPlaceParticlePrefab, hit.point, Quaternion.identity);
                AudioManager.Current.PlayRodPlaceSFX();
                StartCoroutine(DeleteAfterWait(rodParticles, 2f));
            }
        }
    }

    private void ResetRods()
    {
        if(lightningRodsSummoned.Count > 0 && rodResetCoroutine == null)
        {
            AudioManager.Current.PlayRodRecallSFX();
            rodResetCoroutine = StartCoroutine(ShootRodsUp());
        }
    }

    public void ResetRodsForNextRound()
    {
        if (lightningRodsSummoned == null)
            return;
        if(lightningRodsSummoned.Count > 0)
        {
            foreach(GameObject rod in lightningRodsSummoned)
            {
                Destroy(rod);
            }
            lightningRodsSummoned.Clear();
            canPlaceRod = true;
        }
    }
    
    private IEnumerator ShootRodsUp()
    {
        foreach(GameObject rod in lightningRodsSummoned)
        {
            Vector3 endPos = rod.transform.position;
            endPos.y += 20f;
            rod.transform.DOMove(endPos, .1f);
        }
        yield return new WaitForSeconds(.1f);
        foreach(GameObject rod in lightningRodsSummoned)
        {
            Destroy(rod);
        }
        lightningRodsSummoned.Clear();
        canPlaceRod = true;
        rodResetCoroutine = null;
    }
    private void LightningAttack()
    {
        if(!canAttack || lightningRodsSummoned.Count < 1)
        {
            //ERROR SOUND
            AudioManager.Current.PlayUIUnavailableSFX();
            return;
        }
        AudioManager.Current.PlayLightningSFX();
        MyCamera.DOShakePosition(attackShakeDuration, attackShakeStrength, attackShakeVibrato, attackShakeRandomness);
        // mySFXCamera.DOShakePosition(attackShakeDuration, attackShakeStrength, attackShakeVibrato, attackShakeRandomness);
        myAnimator.SetTrigger("goAttack");
        // Debug.Log("lightning animation");
        canAttack = false;
        StartCoroutine(AttackCooldown());
        for(int rodNum = 0; rodNum < lightningRodsSummoned.Count; rodNum++)
        {
            if(rodNum == 0)
            {
                SpawnLightning(transform.position, lightningRodsSummoned[rodNum].transform.position);
            }
            else
            {
                SpawnLightning(lightningRodsSummoned[rodNum - 1].transform.position, lightningRodsSummoned[rodNum].transform.position);
            }
            if((rodNum != 0 && rodNum == lightningRodsSummoned.Count - 1))
            {
                SpawnLightning(lightningRodsSummoned[rodNum].transform.position, transform.position);
            }
        }
        StartCoroutine(ResetLightning());
    }

    private void SpawnLightning(Vector3 rod1, Vector3 rod2)
    {
        Vector3 spawnPos = (rod1 + rod2)/2;
        spawnPos.y = 1;
        GameObject newLightning = Instantiate(lightningAttackPrefab, spawnPos, Quaternion.identity);
        float z = Vector3.Distance(rod1, rod2);
        Transform sfxModel = newLightning.GetComponentsInChildren<Transform>()[1];
        rod2.y += 1;
        newLightning.transform.LookAt(rod2);
        sfxModel.transform.localScale = new Vector3(1 * PlayerStats.Current.Width, z * .5f, 1);
        sfxModel.transform.Rotate(Vector3.right, 90);
        lightningSummoned.Add(newLightning);
        
        lightningSfx.Strike(rod1, rod2);
    }

    private IEnumerator ResetLightning()
    {
        yield return new WaitForSeconds(lightningLifeTime);
        foreach(GameObject lightning in lightningSummoned)
        {
            Destroy(lightning);
        }
        lightningSummoned.Clear();
    }

    private IEnumerator AttackCooldown()
    {
        lightningCooldownLeft = PlayerStats.Current.AttackCooldown;
        while(lightningCooldownLeft >= 0f)
        {
            lightningCooldownLeft -= Time.deltaTime;
            yield return null;
        }
        canAttack = true;
    }

    private IEnumerator DeleteAfterWait(GameObject target, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(target);
    }

    public void ResetPlayerFlags()
    {
        canAttack = true;
        canPlaceRod = true;
        if (lightningRodsSummoned == null)
            return;
        if(lightningRodsSummoned.Count > 0)
        {
            foreach(GameObject obj in lightningRodsSummoned)
            {
                Destroy(obj);
            }
        }
        if(lightningSummoned.Count > 0)
        {
            foreach(GameObject obj in lightningSummoned)
            {
                Destroy(obj);
            }
        }
    }
}
