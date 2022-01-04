using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{
    public GameObject FadeScreen;
    public Rigidbody2D player;
    public Transform Camera;
    public int CurrentTurn;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
      CurrentTurn = 0;
    }

    public void IncrementTurn() {
      CurrentTurn++;
      Debug.Log("Current Turn: " + CurrentTurn);
      sound.Play();
      FadeScreen.GetComponent<Animation>().Play("FadeScreenAnim");
      StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        Camera.position = new Vector3(0.0f, 0.0f, -10.0f);
    }
}
