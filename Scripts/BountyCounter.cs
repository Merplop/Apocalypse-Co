using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BountyCounter : MonoBehaviour
{
    public int bounty;
    public TextMeshProUGUI txt;
    public GameObject player;
    public float rand;
    public float min, max;
    public GameObject cop;
    public Transform copTransf;

    void Start() { 
        min = 98;
        max = 100;

        cop.SetActive(false);
    }

    void Update()
    {
        bounty = player.GetComponent<Player>().getBounty();

        txt.text = "Bounty: " + bounty.ToString();
    }

    public void randGen() { 
        float decrimentRand = Random.Range(0.0f, 10.0f);
        if (decrimentRand > 8.0f) { 
            if (bounty > 10) { 
            min -= (float)Random.Range(bounty/2, bounty/2 + 8);
            }
        }

        rand = Random.Range(0, 100);

        if (rand >= min & rand <= max) { 
            copSpawn();
        }
    }

    void copSpawn() { 
        StartCoroutine(fade());
        copTransf.position = new Vector3(6.0f, -2.0f, 10.0f);
    }

    IEnumerator fade() { 
        yield return new WaitForSeconds(5.0f);
        cop.SetActive(true);
        cop.GetComponent<Animation>().Play("FadeInCop");
    }
}
