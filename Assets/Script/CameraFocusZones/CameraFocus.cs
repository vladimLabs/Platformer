using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] private float targetFov;
    [SerializeField] private CinemachinePositionComposer virtualCamera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            while (virtualCamera.CameraDistance != targetFov)
            {
                virtualCamera.CameraDistance += 0.05f;
            }
        }
    }
}
