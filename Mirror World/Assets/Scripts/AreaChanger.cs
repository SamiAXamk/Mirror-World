using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChanger : MonoBehaviour
{
    public Animator animator;

    private Vector3 position;
    private GameObject playerRef;

    public void FadeToArea(Vector3 pos, GameObject player)
    {
        playerRef = player;
        position = pos;
        animator.SetTrigger("Fade_Out");
    }

    public void MovePlayerDuringFade()
    {
        playerRef.transform.position = position;
    }
}
