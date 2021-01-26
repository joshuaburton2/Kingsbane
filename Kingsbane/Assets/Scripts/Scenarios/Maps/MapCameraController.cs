using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCameraController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject gameplayHitArea;
    [SerializeField]
    private float scrollScaling;
    [SerializeField]
    private float panScaling;
    [SerializeField]
    private float minScrollScaling;
    [SerializeField]
    private int maxPanDistance;

    public bool isOverGameplayArea;

    private float maxCameraSize;
    private float minCameraSize;

    private float currentScaling;

    private Vector2 baseCameraPos;

    private void Awake()
    {
        isOverGameplayArea = false;

        maxCameraSize = camera.orthographicSize;
        minCameraSize = camera.orthographicSize * minScrollScaling;
        baseCameraPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (isOverGameplayArea)
        {
            camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollScaling;
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minCameraSize, maxCameraSize);
            currentScaling = camera.orthographicSize / maxCameraSize;
        }

        if (Input.GetKey(KeyCode.W))
        {
            camera.transform.position += Vector3.up * panScaling;

        }
        if (Input.GetKey(KeyCode.A))
        {
            camera.transform.position += Vector3.left * panScaling;
        }
        if (Input.GetKey(KeyCode.S))
        {
            camera.transform.position += Vector3.down * panScaling;
        }
        if (Input.GetKey(KeyCode.D))
        {
            camera.transform.position += Vector3.right * panScaling;
        }

        Debug.Log(currentScaling);
        var currentMaxPanDistance = maxPanDistance * (1 - currentScaling);
        camera.transform.position = new Vector3
        (
            Mathf.Clamp(camera.transform.position.x, -currentMaxPanDistance, currentMaxPanDistance),
            Mathf.Clamp(camera.transform.position.y, -currentMaxPanDistance, currentMaxPanDistance),
            camera.transform.position.z
        );
    }
}
