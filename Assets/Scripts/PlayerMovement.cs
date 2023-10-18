using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Audios")]
    public AudioSource footstepSounds;
    public AudioSource runningSound;
    public AudioSource shootingSounds;
    public AudioClip[] shootingClips;
  
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepSounds.enabled = false;
                runningSound.enabled = true;
            }
            else
            {
                footstepSounds.enabled = true;
                runningSound.enabled = false;
            }
           
        }
        else
        {
            footstepSounds.enabled = false;
            runningSound.enabled = false;
        }
    }

    public void PlayerShooting(int _clip)
    {
        shootingSounds.clip = shootingClips[_clip];
        shootingSounds.Play();
    }
}
