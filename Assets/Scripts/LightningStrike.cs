using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    public GameObject lightningStrike;
    private ParticleSystem[] lightningParts;

    public Vector3 start;
    public Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        lightningParts = lightningStrike.GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Strike(start, end);
        }
    }

    void Strike(Vector3 startLoc, Vector3 endLoc)
    {
        var thisBolt = Instantiate(lightningStrike, startLoc, Quaternion.identity);
        thisBolt.transform.Find("Flair").transform.position = startLoc;
        thisBolt.transform.Find("Burst").transform.position = endLoc;
        thisBolt.transform.Find("Struck").transform.position = endLoc;
        thisBolt.transform.Find("Struck").transform.eulerAngles = new Vector3(0, 90, 0);
        thisBolt.transform.Find("Scorching").transform.position = endLoc;
        thisBolt.transform.Find("Scorched").transform.position = endLoc;
        thisBolt.transform.Find("Bolt").transform.position = startLoc;
        Vector3 targetDirection = endLoc - startLoc;
        Vector3 newDirection = Vector3.RotateTowards(startLoc, targetDirection, Time.deltaTime, 0.0f);
        thisBolt.transform.Find("Bolt").transform.rotation = Quaternion.LookRotation(newDirection);
        //thisBolt.transform.Find("Bolt").transform.Rotate(new Vector3(90, 40, 0));
        thisBolt.transform.Find("Bolt").transform.localScale += new Vector3(0, endLoc.y - startLoc.y, 0);

        ParticleSystem[] boltChildren = thisBolt.GetComponentsInChildren<ParticleSystem>();
            
        foreach (ParticleSystem p in boltChildren)
        {
            p.Play();
        }

    }
}
