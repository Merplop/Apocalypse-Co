using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivateComputer : MonoBehaviour {

    public float distance;
    public Transform obj1;
    public Transform obj2;
    public GameObject activateObj;
    public GameObject activateObj2;
    public GameObject screen;
    public GameObject player;
    public bool screenOpen;
    public AudioSource computerSound;
    public AudioSource computerExitSound;

    void Start() {
      activateObj.SetActive(false);
      activateObj2.SetActive(false);
      screen.SetActive(false);
    }

    void Update()
    {
      distance = Vector3.Distance(obj1.position, obj2.position);

      if (distance <= 2) {

        if (screen.activeSelf) {
          activateObj.SetActive(false);
          activateObj.SetActive(false);
        } else {
          activateObj.SetActive(true);
          activateObj2.SetActive(true);
        }



        if (Input.GetButtonDown("Fire3")) {
            computerSound.Play();
            screen.SetActive(true);
            player.SetActive(false);
          }

      }
      if (distance > 2) {
        activateObj.SetActive(false);
        activateObj2.SetActive(false);
      }
    }

    public void PlayExitSound() {
      computerExitSound.Play();
    }
}
