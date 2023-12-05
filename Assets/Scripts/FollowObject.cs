using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowObject : MonoBehaviour
{
    public Transform targetObject;
    public TextMeshProUGUI textMeshPro;

    public Vector3 offset = new Vector3(0f, 0f, 0f); // Offset to control the distance from the object

    void Update()
    {
        if (targetObject != null && textMeshPro != null)
        {
            // Set the position of the TextMeshPro to follow the target object with an offset
            textMeshPro.rectTransform.position = targetObject.position + offset;
        }
    }
}
