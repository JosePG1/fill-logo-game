using System;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    CallToAction,
    Intro,
    Gameplay,
    Success,
    Failure
}

[Serializable]
public class GameController : MonoBehaviour
{
    public static GameController Instance;

    Dictionary<State, List<GameObject>> GameObjectsForState
    {
        get
        {
            var dict = new Dictionary<State, List<GameObject>>
            {
                { State.CallToAction, CallToActionObjects },
                { State.Intro, IntroObjects },
                { State.Gameplay, GameplayObjects },
                { State.Success, SuccessObjects },
                { State.Failure, FailureObjects }
            };
            return dict;
        }
    }

    [SerializeField] List<GameObject> CallToActionObjects;
    [SerializeField] List<GameObject> IntroObjects;
    [SerializeField] List<GameObject> GameplayObjects;
    [SerializeField] List<GameObject> SuccessObjects;
    [SerializeField] List<GameObject> FailureObjects;

  

    void Awake()
    {
        ToggleState( State.Gameplay, true );
        Instance = this;
    }

    public void ToggleState( State state, bool shouldActivate )
    {
        foreach ( var go in GameObjectsForState[state] )
        {
            go.SetActive( shouldActivate );
        }
    }
}