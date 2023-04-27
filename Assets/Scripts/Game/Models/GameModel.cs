namespace Game.Models
{
    public class GameModel
    {
        public SoundSettings SoundSettings { get; set; }
        public TutorialData TutorialData { get; set; }
        public CurrenciesData CurrenciesData { get; set; }
    }

    public class CurrenciesData
    {
        public int SoftCurrencyCount { get; set; }
    }

    public class TutorialData
    {
    }

    public class SoundSettings
    {
        public bool MusicOn { get; set; }
        public bool SoundOn { get; set; }
    }
}
