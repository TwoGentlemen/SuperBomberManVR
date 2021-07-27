using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NEW;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovePlayerToGrid : MonoBehaviour
{
    private Transform playerCam;
    private Vector2Int currentIndexCell;

    private void Start()
    {
        playerCam = GetComponent<XRRig>().cameraGameObject.transform;
        currentIndexCell = GridManager.instance.GetIndexCell(playerCam.position);
        GridManager.instance.SetObjectInCell(gameObject, currentIndexCell);
    }

    private void FixedUpdate()
    {
        var index = GridManager.instance.GetIndexCell(playerCam.position);

        if (index != currentIndexCell)
        {
            GridManager.instance.SetObjectInCell(gameObject,index);
            GridManager.instance.SetObjectInCell(null, currentIndexCell);
            currentIndexCell = index;
        }

    }

    public Vector2Int GetCurrentIndexCell()
    {
        return currentIndexCell;
    }

    private void OnDestroy()
    {
        if (GridManager.instance == null || transform == null) { return; }
        var index = GridManager.instance.GetIndexCell(playerCam.position);
        GridManager.instance.SetObjectInCell(null, index);
    }
}
