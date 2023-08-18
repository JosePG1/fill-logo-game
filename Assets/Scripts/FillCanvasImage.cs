using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

public class FillCanvasYIncremental : MonoBehaviour
{
    [SerializeField] KeyCode LeftFootKey;
    [SerializeField] KeyCode RightFootKey;
    [SerializeField] RectTransform RectTransform;
    [SerializeField] TextMeshProUGUI FeedBackText;
    string languageSelected;
    [SerializeField] int LevelDifficulty;
    [SerializeField] Animator PortugueseLanguage;
    [SerializeField] Animator EnglishLanguage;
    [SerializeField] GameObject StartPanel;

    float fillIncrement;
    float originalAnchorMaxY;
    bool leftFootKeyPressed;
    bool rightFootKeyPressed;
    bool levelDifficultyChosen;
    bool isChoosingLanguage;
    bool alreadyAnimated;
    static readonly int IsChosen = Animator.StringToHash( "isChosen" );


    void Awake()
    {
        isChoosingLanguage = true;
    }

    void Update()
    {
        if ( Input.GetKeyDown( RightFootKey ) )
        {
            if ( isChoosingLanguage )
            {
                if ( !alreadyAnimated )
                {
                    StartCoroutine( RunAnimation( EnglishLanguage, "en") );
                }
                else
                {
                    Debug.LogError( $"" );
                    isChoosingLanguage = false;
                }
            }
            else
            {
                rightFootKeyPressed = true;
            }
        }
        if (Input.GetKeyDown(LeftFootKey) )
        {
            if ( isChoosingLanguage )
            {
                if ( !alreadyAnimated )
                {
                    StartCoroutine( RunAnimation( PortugueseLanguage, "pt") );
                }
                else
                {
                    isChoosingLanguage = false;
                }
            }
            else
            {
                leftFootKeyPressed = true;
            }
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

    void SetGameSettings(string language)
    {
        languageSelected = language;
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
        var newAnchorY = Mathf.Clamp(RectTransform.anchorMax.y + fillIncrement, originalAnchorMaxY, 1.0f);
        RectTransform.anchorMax = new Vector2(RectTransform.anchorMax.x, newAnchorY);
    }

    void ResetGame()
    {
        rightFootKeyPressed = false;
        leftFootKeyPressed = false;
        alreadyAnimated = false;
        StartPanel.SetActive( true );
        FeedBackText.gameObject.SetActive( false );
        isChoosingLanguage = true;
        RectTransform.anchorMax = new Vector2(RectTransform.anchorMax.x, originalAnchorMaxY);
    }

    IEnumerator RunAnimation(Animator animator, string language)
    {
        animator.SetTrigger( IsChosen );
        yield return new WaitForSeconds(3.0f);
        SetGameSettings(language);
        alreadyAnimated = true;
    }
}