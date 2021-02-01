using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCameraController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private float scrollScaling;
    [SerializeField]
    private float panScaling;
    [SerializeField]
    private float minScrollScaling;
    [SerializeField]
    private int maxPanDistance;

    private float maxCameraSize;
    private float minCameraSize;

    private float currentScaling;

    private Vector2 baseCameraPos;

    private void Awake()
    {
        maxCameraSize = camera.orthographicSize;
        minCameraSize = camera.orthographicSize * minScrollScaling;
        baseCameraPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (GameManager.instance.uiManager.OverGameplayArea)
        {
            camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollScaling;
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minCameraSize, maxCameraSize);
            currentScaling = camera.orthographicSize / maxCameraSize;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            camera.transform.position += Vector3.up * panScaling;

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.position += Vector3.left * panScaling;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            camera.transform.position += Vector3.down * panScaling;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.position += Vector3.right * panScaling;
        }

        var currentMaxPanDistance = maxPanDistance * (1 - currentScaling);
        camera.transform.position = new Vector3
        (
            Mathf.Clamp(camera.transform.position.x, -currentMaxPanDistance, currentMaxPanDistance),
            Mathf.Clamp(camera.transform.position.y, -currentMaxPanDistance, currentMaxPanDistance),
            camera.transform.position.z
        );
    }
}
