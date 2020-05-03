using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private string letter = "A";

    public static Action<String> OnCollected;

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
            return;

        Debug.Log("a letter collected: " + letter);

        OnCollected?.Invoke(letter);
        gameObject.SetActive(false);
    }
}
