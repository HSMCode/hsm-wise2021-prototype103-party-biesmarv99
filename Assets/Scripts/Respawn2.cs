using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn2 : MonoBehaviour
{

    [SerializeField] private Transform player;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);
    }
}

