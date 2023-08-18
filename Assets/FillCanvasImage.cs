using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

public class FillCanvasYIncremental : MonoBehaviour
{
    [SerializeField] KeyCode LeftFootKey;
    [SerializeField] KeyCode RightFootKey;
    [SerializeField] RectTransform RectTransform;
    [SerializeField] TextMeshProUGUI FeedBackText;
    string languageSelected;
    [SerializeField] int LevelDifficulty;
    [SerializeField] Button PortugueseLanguage;
    [SerializeField] Button EnglishLanguage;
    [SerializeField] GameObject StartPanel;

    float fillIncrement;
    float originalAnchorMaxY;
    bool leftFootKeyPressed;
    bool rightFootKeyPressed;
    bool languageChosen;
    bool levelDifficultyChosen;


    void Start()
    {
        PortugueseLanguage.onClick.AddListener(() =>
        {
            languageSelected = "pt";
            SetGameSettings();
        } );
        EnglishLanguage.onClick.AddListener( () =>
        {
            languageSelected = "en";
            SetGameSettings();
        } );

    }

    void Update()
    {
        if ( Input.GetKeyDown( RightFootKey ) )
        {
            rightFootKeyPressed = true;
        }
        if (Input.GetKeyDown(LeftFootKey) )
        {
            leftFootKeyPressed = true;
        }
        
        if (Input.GetKeyUp(LeftFootKey))
        {
            if (leftFootKeyPressed)
            {
                IncreaseYAnchor();
                leftFootKeyPressed = false;
            }
        }
        
        if (Input.GetKeyUp(RightFootKey))
        {
            if (rightFootKeyPressed)
            {
                IncreaseYAnchor();
                rightFootKeyPressed = false;
            }
        }
    }

    void SetGameSettings()
    {
        languageChosen = true;
        StartPanel.SetActive( false );
        GamSettings.GetGameTexts( languageSelected, LevelDifficulty );
        GamSettings.GetGameDifficulty( LevelDifficulty );
        FeedBackText.text = GamSettings.FeedbackText;
        fillIncrement = GamSettings.FillValue;
        originalAnchorMaxY = RectTransform.anchorMax.y;
    }

    async Task IncreaseYAnchor()
    {
        if ( RectTransform.anchorMax.y >= 0.8f )
        {
            FeedBackText.gameObject.SetActive( true );
            await Task.Delay( TimeSpan.FromSeconds( 5 ) );
            ResetGame();

        }

        if ( languageChosen)
        {
            
            var newAnchorY = Mathf.Clamp(RectTransform.anchorMax.y + fillIncrement, originalAnchorMaxY, 1.0f);
            RectTransform.anchorMax = new Vector2(RectTransform.anchorMax.x, newAnchorY);
        }
        
    }

    void ResetGame()
    {
        StartPanel.SetActive( true );
        languageChosen = false;
        FeedBackText.gameObject.SetActive( false );
        RectTransform.anchorMax = new Vector2(RectTransform.anchorMax.x, originalAnchorMaxY);
    }
}