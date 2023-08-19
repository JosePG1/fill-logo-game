using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    [SerializeField] KeyCode LeftFootKey;
    [SerializeField] KeyCode RightFootKey;
    [SerializeField] Image BackgroundImage;

    readonly float fillIncrement = 0.1f;
    bool leftFootKeyPressed;
    bool rightFootKeyPressed;

    void Start()
    {
        GameSettings.GetGameDifficulty();
    }

    void Update()
    {
        if ( Input.GetKeyDown( RightFootKey ) )
        {
            rightFootKeyPressed = true;
        }

        if ( Input.GetKeyDown( LeftFootKey ) )
        {
            leftFootKeyPressed = true;
        }

        if ( Input.GetKeyUp( LeftFootKey ) )
        {
            if ( leftFootKeyPressed )
            {
                FillImageBackground();
                leftFootKeyPressed = false;
            }
        }

        if ( Input.GetKeyUp( RightFootKey ) )
        {
            if ( rightFootKeyPressed )
            {
                FillImageBackground();
                rightFootKeyPressed = false;
            }
        }
    }


    void FillImageBackground()
    {
        BackgroundImage.fillAmount += fillIncrement;
    }
}