using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspectStar
{
    static public class PlaySound
    {
        static public bool Enabled = true;

        static public SoundEffect thud;
        static SoundEffectInstance thud_inst;

        static public SoundEffect pew;
        static SoundEffectInstance pew_inst;

        static public SoundEffect aspect;

        static public SoundEffect boom;
        static SoundEffectInstance boom_inst;

        static public SoundEffect die;

        static public SoundEffect win;

        static public SoundEffect pause;

        static public void Initialize()
        {
            thud_inst = thud.CreateInstance();
            pew_inst = pew.CreateInstance();
            boom_inst = boom.CreateInstance();
        }

        static public void Thud()
        {
            if (Enabled && (thud_inst.State != SoundState.Playing))
                thud_inst.Play();
        }

        static public void Pew()
        {
            if (Enabled && (pew_inst.State != SoundState.Playing))
                pew_inst.Play();
        }

        static public void Aspect()
        {
            if (Enabled)
                aspect.Play();
        }
        
        static public void Boom()
        {
            if (Enabled && (boom_inst.State != SoundState.Playing))
                boom_inst.Play();
        }

        static public void Die()
        {
            if (Enabled)
                die.Play();
        }

        static public void Win()
        {
            if (pew_inst.State == SoundState.Playing)
                pew_inst.Stop();
            if (Enabled)
                win.Play();
        }

        static public void Pause()
        {
            if (Enabled)
                pause.Play();
        }
    }
}
