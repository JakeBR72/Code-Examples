using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardShortcuts : MonoBehaviour
{

    UIMaster ui;
    bool buildOpen;
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("_UI").GetComponent<UIMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (buildOpen)
            {
                buildOpen = !buildOpen;
                ui.HideSubMenus();
            }
            else
            {
                buildOpen = !buildOpen;
                ui.SetBuild();
            }
        }
    }
}
