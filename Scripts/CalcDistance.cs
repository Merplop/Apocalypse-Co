using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalcDistance : MonoBehaviour
{
    public float distance;
    public Transform obj1;
    public Transform obj2;
    public GameObject activateObj;

    void Start() {
      activateObj.SetActive(false);
    }

    void Update()
    {
      distance = Vector3.Distance(obj1.position, obj2.position);

      if (distance <= 2) {
        activateObj.SetActive(true);

        if (Input.GetButtonDown("Fire3")) {
          if (distance <= 2) {
            Debug.Log(activateObj.name + " activated");
          }
        }
      }
      if (distance > 2) {
        activateObj.SetActive(false);
      }
    }
}
