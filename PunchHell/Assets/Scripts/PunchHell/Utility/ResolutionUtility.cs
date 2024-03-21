using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class ResolutionUtility
{
    public static readonly int GameResolutionX = 1280;
    public static readonly int GameResolutionY = 960;
    public static readonly RefreshRate RefreshRate = new RefreshRate() { numerator = 60, denominator = 1 };

    public static void ForceGameResolution()
    {
        Screen.SetResolution(GameResolutionX, GameResolutionY, FullScreenMode.Windowed, RefreshRate);
    }
}

