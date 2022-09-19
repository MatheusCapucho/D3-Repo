using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;


    private void Start()
    {
        if (sprite == null)
            Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.enabled = !sprite.enabled;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.enabled = !sprite.enabled;
        }
    }

}
