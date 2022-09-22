using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameObjectState : MonoBehaviour
{
    [SerializeField]
    private GameObject changeGameObject;

    [SerializeField]
    private bool active = false;
    [SerializeField]
    private float timeToResolve = 0.5f;

    private void Start()
    {
        if (changeGameObject == null)
            Destroy(this);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ResolveAfterSeconds(timeToResolve));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ResolveAfterSeconds(timeToResolve));
        }
    }

    IEnumerator ResolveAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);

        changeGameObject.SetActive(active);

    }


}
