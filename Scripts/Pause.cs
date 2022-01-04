using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    [SerializeField] private GameObject player;

    [SerializeField] private bool isPaused;

    void Update()
    {
        if(Input.GetButtonDown("Cancel")) {
          isPaused = !isPaused;
        }

        if(isPaused) {
          ActivateMenu();
        } else {
          DeactivateMenu();
        }
    }

    void ActivateMenu() {
      pauseUI.SetActive(true);
      Time.timeScale = 0;
      player.GetComponent<PlayerMovement>().enabled = false;
    }

    void DeactivateMenu() {
      pauseUI.SetActive(false);
      Time.timeScale = 1;
      player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void pauseBool() { 
      isPaused = !isPaused;
    }
}
