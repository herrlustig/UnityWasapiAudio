﻿using UnityEngine.Experimental.VFX;
using UnityEngine.Experimental.VFX.Utility;

namespace Assets.WasapiAudio.Scripts.Unity
{
    public abstract class VfxAudioVisualizationEffect : VFXBinderBase
    {
        // Inspector Properties
        public WasapiAudioSource WasapiAudioSource;
        public AudioVisualizationProfile Profile;
        public AudioVisualizationStrategy Strategy;

        protected int SpectrumSize { get; private set; }

        public override bool IsValid(VisualEffect component)
        {
            return WasapiAudioSource != null && Profile != null;
        }

        public override void UpdateBinding(VisualEffect component)
        {
            SpectrumSize = WasapiAudioSource.SpectrumSize;
        }

        protected float[] GetSpectrumData()
        {
            return WasapiAudioSource.GetSpectrumData(Strategy, Profile);
        }
    }
}