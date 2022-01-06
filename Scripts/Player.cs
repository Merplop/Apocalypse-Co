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

    public enum Modifier {
      Liberal,
      Conservative,
      Random
    }

    public int money;
    public int bounty;
    public float playerSpeed;
    public double propMultiplier;
    public Room CurrentRoom;
    public Modifier CurrentMod;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update() {

    }

    public void defCurrentMod(Modifier cd) { 
      CurrentMod = cd;
    }

    public void defCurrentRoom(Room cr) { 
      CurrentRoom = cr;
    }

    public Room getCurrentRoom() { 
      return CurrentRoom;
    }

    public Modifier getCurrentMod() { 
      return CurrentMod;
    }

    public int getMoney() {
      return money;
    }

    public float getSpeed() { 
      return playerSpeed;
    }

    public int getBounty() { 
      return bounty;
    }

    
}
