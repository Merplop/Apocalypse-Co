using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame() {
      SceneManager.LoadScene(0);
    }

    public void ContinueGame() { 
      player.GetComponent<Pause>().pauseBool();  
    }
}
