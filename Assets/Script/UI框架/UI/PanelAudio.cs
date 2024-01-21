using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAudio : BasePanel
{
    private static string name = "AudioControl";
    private static string path = "Panel/AudioControl";
    public static readonly UIType newUIType = new UIType(name, path);

    public PanelAudio() : base(newUIType)
    {

    }
}
