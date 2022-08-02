using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;

    private void OnTriggerEnter(Collider other)
    {
        ICollide collide = other.GetComponent<ICollide>();
        collide.Collide(other, gameMode);
    }
}
