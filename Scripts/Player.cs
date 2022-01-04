using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum Room {
      Office,
      Hall,
      Lobby,
      Elevator,
      Vault
    }

    public enum Drug {
      LiberalSugar,
      ConservativeSugar,
      TripTheFuckOut
    }

    public int money;
    public float playerSpeed;
    public double propMultiplier;
    public Room CurrentRoom;
    public Drug CurrentDrug;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update() {

    }

    void LiberalSugar() {
        
    }

    void ConservativeSugar() {

    }

    void TripTheFuckOut() {

    }

    public void defCurrentDrug(Drug cd) { 
      CurrentDrug = cd;
    }

    public void defCurrentRoom(Room cr) { 
      CurrentRoom = cr;
    }

    public Room getCurrentRoom() { 
      return CurrentRoom;
    }

    public Drug getCurrentDrug() { 
      return CurrentDrug;
    }

    public int getMoney() {
      return money;
    }

    public float getSpeed() { 
      return playerSpeed;
    }

    
}
