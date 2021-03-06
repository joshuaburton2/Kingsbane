﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CategoryEnums;
using System;

namespace CategoryEnums
{
    //Note this name must be the same as the name of the scene
    public enum SceneList
    {
        MainMenuScene,
        GameplayScene,
    }
}

public class GameSceneManager : MonoBehaviour
{
    private bool SceneLoaded { get; set; }

    public SceneList ActiveScene
    {
        get
        {
            try
            {
                Enum.TryParse(SceneManager.GetActiveScene().name, out SceneList result);
                return result;
            }
            catch
            {
                throw new Exception("Scene Name does not exist in Scene List");
            }
        }
    }

    /// <summary>
    /// 
    /// Load a scene of a given type
    /// 
    /// </summary>
    public void LoadNewScene(SceneList scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
    }

    /// <summary>
    /// 
    /// Used to detect when a new scene is loaded into, since Game Scene Manager is enabled when this happens
    /// See 
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneUnloaded.html
    /// for more information
    /// 
    /// </summary>
    private void OnEnable()
    {
        SceneLoaded = false;
        SceneManager.sceneUnloaded += OldSceneUnloaded;
        SceneManager.sceneLoaded += NewSceneLoaded;
    }

    /// <summary>
    /// 
    /// Used to detect when a scene is loaded out of, since Game Scene Manager is disabled when this happens
    /// See 
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneUnloaded.html
    /// for more information
    /// 
    /// </summary>
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= NewSceneLoaded;
        SceneManager.sceneUnloaded -= OldSceneUnloaded;
    }

    /// <summary>
    /// 
    /// Used for detecting when a new scene is loaded into. Customised to detect for the different scenes in the game
    /// See
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    /// for more information
    /// 
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void NewSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!SceneLoaded)
        {
            if (scene.name == SceneList.MainMenuScene.ToString())
            {
                GameManager.instance.uiManager.SyncMenuPages();
                GameManager.instance.InitialiseMenuScene();
            }
            else if (scene.name == SceneList.GameplayScene.ToString())
            {
                GameManager.instance.CheckGameLoad();
                GameManager.instance.InitialiseGameplayScene();

                GameManager.instance.StartGame();
                GameManager.instance.uiManager.SyncGameplayPages();
            }

            SceneLoaded = true;
        }
    }

    /// <summary>
    /// 
    /// Used for detecting when a scene is unloaded. Customised to detect for the different scenes in the game.
    /// See
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneUnloaded.html
    /// for more information
    /// 
    /// </summary>
    /// <param name="scene"></param>
    private void OldSceneUnloaded(Scene scene)
    {
        if (scene.name == SceneList.MainMenuScene.ToString())
        {

        }
        else if (scene.name == SceneList.GameplayScene.ToString())
        {
            if (GameManager.instance.CurrentGamePhase != GameManager.GamePhases.End)
            {
                if (GameManager.instance.ActivePlayerId.HasValue)
                    GameManager.instance.TriggerVictory(GameManager.instance.ActivePlayerId.Value, true);
                else
                    GameManager.instance.TriggerVictory(0, true);
            }

            GameManager.instance.deckManager.LoadNPCDecks();
            GameManager.instance.deckManager.SaveDecks();
            GameManager.instance.ResetGameState();
        }
    }
}
