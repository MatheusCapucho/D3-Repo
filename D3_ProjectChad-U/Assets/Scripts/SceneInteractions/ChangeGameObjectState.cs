using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameObjectState : MonoBehaviour
{
    [SerializeField]
    private GameObject changeGameObject;

    [SerializeField]
    private bool active = false;

    private void Start()
    {
        if (changeGameObject == null)
            Destroy(this);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changeGameObject.SetActive(active);
            Destroy(this, 0.1f);
        }
    }
}
