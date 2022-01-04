using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivateDoor : MonoBehaviour
{
    public float distance;
    public Rigidbody2D player;
    public Rigidbody2D obj;
    public GameObject activateObj;
    public GameObject activateObj2;
    public float posX;
    public float posY;
    public Transform Camera;
    public AudioSource doorSound;
    public GameObject FadeScreen;

    void Start() {
      activateObj.SetActive(false);
      activateObj2.SetActive(false);
    }

    void Update()
    {
      distance = Vector3.Distance(player.transform.position, obj.transform.position);

      if (distance <= 2) {
        activateObj.SetActive(true);
        activateObj2.SetActive(true);

        if (Input.GetButtonDown("Fire3")) {
          if (distance <= 2) {
            doorSound.Play();
            FadeScreen.GetComponent<Animation>().Play("FadeScreenAnim");
            StartCoroutine(wait());
          }
        }
      }
      if (distance > 2) {
        activateObj.SetActive(false);
        activateObj2.SetActive(false);
      }
    }

    IEnumerator wait() {
      yield return new WaitForSeconds(1.0f);
      player.transform.position = new Vector3(posX, posY, 0.0f);
      Camera.position = new Vector3(posX, posY, -10.0f);
    }

}
