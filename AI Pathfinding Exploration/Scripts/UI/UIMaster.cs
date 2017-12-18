using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    public enum GameState { MainMenu, Game }
    public enum MenuState { Game, Research }
    public enum MenuSubState { None, Pause, Build, Inspect }

    public GameState gameState = GameState.Game;
    private GameState oldGameState = GameState.MainMenu;
    public MenuState menuState = MenuState.Game;
    private MenuState oldMenuState = MenuState.Research;
    public MenuSubState menuSubState = MenuSubState.None;
    private MenuSubState oldMenuSubState = MenuSubState.Inspect;

    public List<RectTransform> menuPanels = new List<RectTransform>();
    public List<RectTransform> menuSubPanels = new List<RectTransform>();
    

    private float menuMoveSpeed = 2.5f;

    private MouseControls mouse;

    void Start()
    {
        mouse = GameObject.Find("_Cam").GetComponent<MouseControls>();
        for (int i = 0; i < menuPanels.Count; i++)
        {
            menuPanels[i].anchoredPosition = new Vector2(0, -menuPanels[i].rect.height);
        }
        for (int i = 0; i < menuSubPanels.Count; i++)
        {
            menuSubPanels[i].anchoredPosition = new Vector2(0, -menuSubPanels[i].rect.height);
        }
    }

    void Update()
    {
        if (gameState == GameState.MainMenu)
        {
            //do main menu stuff
        }
        else if (gameState == GameState.Game) // do game menu stuff
        {
            if (oldMenuState != menuState) // Menus
            {
                oldMenuState = menuState;
                menuPanels[(int)menuState].anchoredPosition = new Vector2(0, 0);
                for (int i = 0; i < menuPanels.Count; i++)
                {
                    if (i != (int)menuState)
                    {
                        menuPanels[i].anchoredPosition = new Vector2(0, -menuPanels[i].rect.height);
                    }
                }
            }
            if (oldMenuSubState != menuSubState) // SubMenus
            {
                oldMenuSubState = menuSubState;
                menuSubPanels[(int)menuSubState].anchoredPosition = new Vector2(0, 0);
                for (int i = 0; i < menuSubPanels.Count; i++)
                {
                    if (i != (int)menuSubState)
                    {
                        menuSubPanels[i].anchoredPosition = new Vector2(0, -menuSubPanels[i].rect.height);
                    }
                }
            }
        }
    }

    public void SetBuild()
    {
        menuSubState = MenuSubState.Build;
        mouse.mode = MouseControls.MouseMode.Build;
    }
    public void SetInspect(string name)
    {
        menuSubState = MenuSubState.Inspect;
    }
    public void HideSubMenus()
    {
        menuSubState = MenuSubState.None;
        mouse.mode = MouseControls.MouseMode.Normal;
    }
}
