using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspectStar
{
    static public class PlaySound
    {
        static public SoundEffect thud;
        static SoundEffectInstance thud_inst;

        static public SoundEffect pew;
        static SoundEffectInstance pew_inst;

        static public SoundEffect aspect;

        static public SoundEffect boom;
        static SoundEffectInstance boom_inst;

        static public SoundEffect die;

        static public SoundEffect win;

        static public void Initialize()
        {
            thud_inst = thud.CreateInstance();
            pew_inst = pew.CreateInstance();
            boom_inst = boom.CreateInstance();
        }

        static public void Thud()
        {
            if (thud_inst.State != SoundState.Playing)
                thud_inst.Play();
        }

        static public void Pew()
        {
            if (pew_inst.State != SoundState.Playing)
                pew_inst.Play();
        }

        static public void Aspect()
        {
            aspect.Play();
        }
        
        static public void Boom()
        {
            if (boom_inst.State != SoundState.Playing)
                boom_inst.Play();
        }

        static public void Die()
        {
            die.Play();
        }

        static public void Win()
        {
            if (pew_inst.State == SoundState.Playing)
                pew_inst.Stop();
            win.Play();
        }
    }
}
