using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControls : MonoBehaviour
{
    UIMaster ui;

    public enum MouseMode { Normal, Build, Menu }
    public MouseMode mode = MouseMode.Normal;
    ProceduralGrid floorGrid;

    Vector3 hitpos = new Vector3(0, 0, 0);
    Vector3 lastMousePos;
    string lastHitTag = "";
    Transform lastHit;
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("_UI").GetComponent<UIMaster>();
        floorGrid = GameObject.Find("_FloorGrid").GetComponent<ProceduralGrid>();
        lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == MouseMode.Normal)
        {    
            lastMousePos = Input.mousePosition;

            Ray ray;
            RaycastHit rayHit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(ray, out rayHit) && rayHit.collider.transform.tag.Contains("Interactable"))
                {
                    if (lastHit != null)
                    {
                        lastHit.GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                    lastHitTag = rayHit.collider.transform.tag;
                    lastHit = rayHit.transform;
                    Material lastHitMat = lastHit.GetComponent<MeshRenderer>().material;
                    lastHitMat.color = Color.white;
                    //Set Inspect UI
                    ui.SetInspect(lastHit.name);
                    if (lastHitTag.Contains("Floor"))
                    {
                        floorGrid.HighlightUV((int)(hitpos.x + 0.5f), (int)(hitpos.z + 0.5f), Color.white);
                        hitpos = rayHit.point;
                        floorGrid.HighlightUV((int)(hitpos.x + 0.5f), (int)(hitpos.z + 0.5f), Color.cyan);
                    }
                    else //if it wasnt a floorboard
                    {
                        lastHitMat.color = Color.cyan;
                        floorGrid.HighlightUV((int)(hitpos.x + 0.5f), (int)(hitpos.z + 0.5f), Color.white);
                    }
                }else if (lastHit != null)
                {
                    ui.HideSubMenus();
                    if (lastHitTag.Contains("Floor"))
                    {
                        floorGrid.HighlightUV((int)(hitpos.x + 0.5f), (int)(hitpos.z + 0.5f), Color.white);
                    }
                    else  //if it wasnt a floorboard
                    {
                        Material lastHitMat = lastHit.GetComponent<MeshRenderer>().material;
                        lastHitMat.color = Color.white;
                        floorGrid.HighlightUV((int)(hitpos.x + 0.5f), (int)(hitpos.z + 0.5f), Color.white);
                    }
                }
            }
        }
        else if(mode == MouseMode.Build)
        {
            //Do build stuff
        }
    }
}
