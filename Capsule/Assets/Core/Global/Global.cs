using Core.Effect.Scripts;
using Core.Sound;
using Core.UserData;
using ScriptableObject;

namespace Core.Global
{
    public static class Global
    {
        private static IEffectPlayer _effectPlayer;

        public static void SetEffectPlayer(IEffectPlayer effectPlayer)
        {
            _effectPlayer = effectPlayer;
        }

        public static IEffectPlayer EffectPlayer => _effectPlayer;
        
        private static ISoundPlayer _soundPlayer;
        public static void SetSoundPlayer(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }
        
        public static ISoundPlayer SoundPlayer => _soundPlayer;
        public static StageData PreStageData { get; private set; }
        public static StageData CurrentStageData { get; private set; }

        public static void SetCurrentStageData(StageData data)
        {
            PreStageData = CurrentStageData;
            CurrentStageData = data;
        }
        
        public static SaveDataSystem SaveDataSystem { get; set; }

    }
}
