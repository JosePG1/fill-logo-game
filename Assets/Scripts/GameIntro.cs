using TMPro;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

#pragma warning disable CS4014

public class GameIntro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CountDownText;
    [SerializeField] GameObject CountDown;
    [SerializeField] Animator IntroAnimation;


    static readonly int StartAnimation = Animator.StringToHash( "startAnimation" );

    void Start()
    {
        IntroAnimation.SetTrigger( StartAnimation );
        Debug.LogError( $"Starting Game Intro" );
        CountDownTimer();
    }

    async Task CountDownTimer()
    {
        Debug.LogError( $"Count Down timer" );
        var elapsedTime = GameSettings.InitialCountdown;

        while ( elapsedTime >= 0f )
        {
            Debug.LogError( $"Starting the Countdown with the value: {elapsedTime}" );
            elapsedTime -= Time.deltaTime;
            if ( elapsedTime < 6f )
            {
                CountDown.SetActive( true );
                Debug.Log( $"Changing the Game Intro Text" );
                CountDownText.text = Mathf.FloorToInt( elapsedTime ).ToString();
            }

            await Task.Yield();
        }

        GameController.Instance.ToggleState( State.Intro, false );
        GameController.Instance.ToggleState( State.Gameplay, true );
    }
}