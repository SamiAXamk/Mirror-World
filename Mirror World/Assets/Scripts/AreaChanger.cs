using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChanger : MonoBehaviour
{
    public Animator animator;
    public Camera camera;
    public CameraFollow cameraFollow;
    public GameObject startingArea;

    private Transform target;
    private GameObject playerRef;

    private void Start()
    {
        SpriteRenderer spriteRenderer = startingArea.gameObject.GetComponent<SpriteRenderer>();
        cameraFollow.UpdateSpriteRenderer(spriteRenderer);
    }

    public void FadeToArea(Transform _target, GameObject player)
    {
        playerRef = player;
        target = _target;
        animator.SetTrigger("Fade_Out");
    }

    public void MovePlayerDuringFade()
    {
        playerRef.transform.position = target.position;
        camera.transform.position = new Vector3(target.transform.parent.position.x,
                                                        target.transform.parent.position.y,
                                                        camera.transform.position.z);
        //cameraFollow.area = target.transform.parent.gameObject;
        SpriteRenderer spriteRenderer = target.parent.gameObject.GetComponent<SpriteRenderer>();
        cameraFollow.UpdateSpriteRenderer(spriteRenderer);
    }
}
