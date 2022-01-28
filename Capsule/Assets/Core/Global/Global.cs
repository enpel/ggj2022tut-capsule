using Core.Effect.Scripts;
using Core.Sound;
using UnityEngine;

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
        
        
        static private ISoundPlayer _soundPlayer;
        public static void SetSoundPlayer(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }
        
        public static ISoundPlayer SoundPlayer => _soundPlayer;

    }
}
