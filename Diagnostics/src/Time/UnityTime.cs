using UnityEngine;
using System;

namespace Senkel.Unity.Diagnostics;
/// <summary>
/// Contains utilties regarding time measurement that are not featured in the <see cref="UnityEngine.Time"/> class.
/// </summary>
public static class UnityTime
{
    /// <summary>
    /// The time since the start of the game unaffected by time scale.
    /// </summary>
    public static TimeSpan UnscaledTime => TimeSpan.FromSeconds(UnityEngine.Time.unscaledTimeAsDouble);

    /// <summary>
    /// The time since the start of the game affected by time scale.
    /// </summary>
    public static TimeSpan Time => TimeSpan.FromSeconds(UnityEngine.Time.timeAsDouble);
}

