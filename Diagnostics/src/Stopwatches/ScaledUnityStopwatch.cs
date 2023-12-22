using System; 
using UnityEngine;
 
namespace Senkel.Unity.Diagnostics;

/// <summary>
/// Represents a stopwatch that is based on the <see cref="Time.timeAsDouble"/> property.
/// </summary>
public class ScaledUnityStopwatch : RelativeStopwatch
{
    /// <summary>
    /// Represents the <see cref="UnityTime.Time"/> property that is based on the <see cref="Time.timeAsDouble"/> value.
    /// </summary>
    protected override TimeSpan AbsoluteTime => UnityTime.Time;
}

