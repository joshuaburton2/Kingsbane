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
    private float minScrollPercentage;

    public bool isOverGameplayArea;

    private void Awake()
    {
        isOverGameplayArea = false;
    }

    private void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == gameplayHitArea.transform.name)
            {
                
            }
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (EventSystem.current.currentSelectedGameObject == gameplayHitArea)
            {
                
            }
        }

        if (isOverGameplayArea)
        {
            camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollScaling;
        }
    }
}
