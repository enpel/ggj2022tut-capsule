using Sound;

namespace Core.Sound
{
    public static class GlobalSoundPlayer
    {
        static private ISoundPlayer _soundPlayer;
        public static void SetSoundPlayer(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        public static void PlayBGM(BgmType type)
        {
            _soundPlayer?.PlayBGM(type);
        }

        public static void PlaySE(SeType type)
        {
            _soundPlayer?.PlaySE(type);
        }
    }
}