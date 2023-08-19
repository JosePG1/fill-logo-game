public abstract class GameSettings 
{
    public static string FeedbackText;
    public static string StartGameText;
    public static float FillValue;
    public static int LevelDifficulty;
    public static float GameDuration = 60;
    public static readonly float InitialCountdown = 12;

    public static void GetGameDifficulty( )
    {
        FillValue = LevelDifficulty switch
        {
            1 => 0.01f,
            2 => 0.008f,
            3 => 0.006f,
            4 => 0.004f,
            5 => 0.001f,
            _ => 0.09f
        };
    }
    public static void GetGameTexts( string language, int gameDifficulty )
    {
        if ( language == "pt" )
        {
            StartGameText = "Bem-Vindo, par ainiciar jogo carrega em 1 dos botões que tens no chão";
            FeedbackText = gameDifficulty switch
            {
                1 => "Demasiado fácil para ti!",
                2 => "Qualquer um faz isto XD",
                3 => "Agora sim, a coisa comeca a ficar engracada",
                4 => "Digno de um festivaleiro",
                5 => "Mereces uma subida ao palco, Parabéns!",
                _ => "Boa!"
            };
        }
        
        if ( language == "en" )
        {
            StartGameText = "Welcome, to start please press any button on the floor";
            FeedbackText = gameDifficulty switch
            {
                1 => "Too easy for you!",
                2 => "Anyone can do this XD",
                3 => "Now, things start to get funny",
                4 => "Worthy of a festival goer",
                5 => "You deserve a stage, congratulations!",
                _ => "Nice!"
            };
        }
    }
}