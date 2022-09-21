using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    void LateUpdate()
    {
        transform.localRotation = transform.localRotation * Quaternion.Inverse(transform.rotation);
    }
}
