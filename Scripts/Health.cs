using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{

    public int money;
    public TextMeshProUGUI txt;
    public GameObject player;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      money = player.GetComponent<Player>().getMoney();

      txt.text = "Money: $" + money.ToString();

      if (money <= 0) {
        player.SetActive(false);
        gameOver.SetActive(true);
      }
    }
}
