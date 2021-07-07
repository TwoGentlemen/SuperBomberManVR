using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Controll_VR : MonoBehaviour
{
    [SerializeField] private Transform offsetUI;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject panelGameOwer;

    bool isGame = true;
    public void SetPanelGameOver()
    {
        panelGameOwer.SetActive(true);
        isGame = false;
    }

    private void Update()
    {
        if (!isGame)
        {
            mainCanvas.transform.position = new Vector3(offsetUI.position.x, mainCanvas.transform.position.y,offsetUI.position.z);
            Quaternion rot = new Quaternion(mainCanvas.transform.rotation.x,offsetUI.rotation.y,mainCanvas.transform.rotation.z, offsetUI.rotation.w);
            mainCanvas.transform.rotation = rot;
        }
    }
}
