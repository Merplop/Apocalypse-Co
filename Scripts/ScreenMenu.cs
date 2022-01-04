using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMenu : MonoBehaviour
{

    public GameObject player;
    public GameObject screen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Exit() {
      player.SetActive(true);
      screen.SetActive(false);
    }
}
