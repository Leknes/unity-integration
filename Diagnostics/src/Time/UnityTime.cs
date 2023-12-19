using UnityEngine;

namespace Senkel.Unity.Diagnostics;
/// <summary>
/// Represents utilies regarding time measurement that are not featured in the <see cref="UnityEngine.Time"/> class.
/// </summary>
public static class UnityTime
{
    /// <summary>
    /// The double-precision time in seconds since the start of the game unaffected by time scale.
    /// </summary>
    public static TimeSpan UnscaledTime => TimeSpan.FromSeconds(UnityEngine.Time.unscaledTimeAsDouble);

    /// <summary>
    /// The double-precision time in seconds since the start of the game affected by time scale.
    /// </summary>
    public static TimeSpan Time => TimeSpan.FromSeconds(UnityEngine.Time.timeAsDouble);
}

