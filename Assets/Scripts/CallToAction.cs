using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class CallToAction : MonoBehaviour
{
    [SerializeField] KeyCode LeftFootKey;
    [SerializeField] KeyCode RightFootKey;
    [SerializeField] VideoPlayer VideoPlayer;
    [SerializeField] GameObject VideoHolder;
    void Start()
    {
        VideoPlayer.url = Application.streamingAssetsPath + "/CallToAction.mp4";
        VideoPlayer.Prepare();
        StartCoroutine( PrepareVideo() );
    }
    
    IEnumerator PrepareVideo()
    {
        while ( !VideoPlayer.isPrepared )
        {
            yield return null;
        }
        
        VideoPlayer.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(LeftFootKey) || Input.GetKeyDown(RightFootKey)) 
        {
            Debug.LogError( $"KeyPressed" );
            InitiateGame();
        }
        
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            GameSettings.LevelDifficulty = 1;
        }
        
        if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
        {
            GameSettings.LevelDifficulty = 2;
        }
        
        if ( Input.GetKeyDown( KeyCode.Alpha3 ) )
        {
            GameSettings.LevelDifficulty = 3;
        }
        
        if ( Input.GetKeyDown( KeyCode.Alpha4) )
        {
            GameSettings.LevelDifficulty = 4;
        }
        
        if ( Input.GetKeyDown( KeyCode.Alpha5 ) )
        {
            GameSettings.LevelDifficulty = 5;
        }
    }

    void InitiateGame()
    { 
        VideoPlayer.Pause();
        VideoHolder.SetActive( false );
        GameController.Instance.ToggleState( State.CallToAction, false );
        GameController.Instance.ToggleState( State.Intro, true );

    }
    
    // void SetGameSettings(string language)
    // {
    //     LanguageSelected = language;
    //     GamSettings.GetGameTexts( LanguageSelected, LevelDifficulty );
    //     GamSettings.GetGameDifficulty( LevelDifficulty );
    //     FeedBackText.text = GamSettings.FeedbackText;
    //     fillIncrement = GamSettings.FillValue;
    //     originalAnchorMaxY = RectTransform.anchorMax.y;
    // }
}
