using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // player to follow
    //[HideInInspector] public GameObject area;     // the current area/sprite we are in

    Camera camera;
    GameObject cameraGO;
    Bounds cameraBounds;
    Bounds spriteBounds;    // bounds of the sprite of target area

    // Start is called before the first frame update
    void Start()
    {
        cameraGO = this.gameObject;
        camera = gameObject.GetComponent<Camera>();
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        cameraBounds = new Bounds(camera.transform.position,
                            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Debug.Log("camera extent: " + cameraBounds.extents.x +
                  "\n sprite extent: " + spriteBounds.extents.x +
                  "\n camera center x: " + cameraBounds.center.x);

        // if cameraview is smaller than the sprite of the current area, handles camera movement in x-axis
        if (cameraBounds.extents.x < spriteBounds.extents.x)
        {
            // move the camera
            cameraGO.transform.position = new Vector3(target.position.x, cameraGO.transform.position.y, cameraGO.transform.position.z);

            // if camera has moved outside the sprite on the right side
            if(cameraGO.transform.position.x + cameraBounds.extents.x > spriteBounds.center.x + spriteBounds.extents.x)
            {
                // move camera so that the camera and sprite borders are at same point
                cameraGO.transform.position = new Vector3(spriteBounds.center.x + spriteBounds.extents.x - cameraBounds.extents.x, cameraGO.transform.position.y, cameraGO.transform.position.z);
            }
            // if camera has moved outside the sprite on the left side
            else if (cameraGO.transform.position.x - cameraBounds.extents.x < spriteBounds.center.x - spriteBounds.extents.x)
            {
                // move camera so that the camera and sprite borders are at same point
                cameraGO.transform.position = new Vector3(spriteBounds.center.x - spriteBounds.extents.x + cameraBounds.extents.x, cameraGO.transform.position.y, cameraGO.transform.position.z);
            }
        }

        // if cameraview is smaller than the sprite of the current area, handles camera movement in y-axis
        if (cameraBounds.extents.y < spriteBounds.extents.y)
        {
            // move the camera
            cameraGO.transform.position = new Vector3(cameraGO.transform.position.x, target.position.y, cameraGO.transform.position.z);

            // if camera has moved outside the sprite on the top side
            if (cameraGO.transform.position.y + cameraBounds.extents.y > spriteBounds.center.y + spriteBounds.extents.y)
            {
                // move camera so that the camera and sprite borders are at same point
                cameraGO.transform.position = new Vector3(cameraGO.transform.position.x, spriteBounds.center.y + spriteBounds.extents.y - cameraBounds.extents.y, cameraGO.transform.position.z);
            }
            // if camera has moved outside the sprite on the left side
            else if (cameraGO.transform.position.y - cameraBounds.extents.y < spriteBounds.center.y - spriteBounds.extents.y)
            {
                // move camera so that the camera and sprite borders are at same point
                cameraGO.transform.position =new Vector3(cameraGO.transform.position.x, spriteBounds.center.y - spriteBounds.extents.y + cameraBounds.extents.y, cameraGO.transform.position.z);
            }
        }
    }

    public void UpdateSpriteRenderer(SpriteRenderer renderer)
    {
        spriteBounds = renderer.bounds;
    }
}
