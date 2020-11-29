using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController player;
    public float moveSpeed = 30f;

    private float horizontalMove = 0f;
    private bool jump = false;

    private void Update()
    {
#if UNITY_EDITOR
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
#endif

#if UNITY_IOS || UNITY_ANDROID
        horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
#endif

        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        player.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
