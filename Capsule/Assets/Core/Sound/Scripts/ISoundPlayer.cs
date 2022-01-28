using Sound;

namespace Core.Sound
{
    public interface ISoundPlayer
    {
        public void PlayBGM(BgmType type);
        public void StopBGMAll();
        public void PlaySE(SeType type);
    }
}