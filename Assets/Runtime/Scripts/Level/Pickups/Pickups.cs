using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Pickups : MonoBehaviour, ICollide
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject PickupRender;
    private AudioSource audioSource;

    private bool wasPickedUp = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Collide(Collider collider, GameMode gameMode)
    {
        if (audioClip != null) AudioUtility.PlayAudioCue(audioSource, audioClip);

        if(!wasPickedUp)
        {
            OnPickedUp();
            wasPickedUp = true;
        }

        PickupRender.SetActive(false);

        Destroy(gameObject, audioClip.length);
    }

    protected abstract void OnPickedUp();
}