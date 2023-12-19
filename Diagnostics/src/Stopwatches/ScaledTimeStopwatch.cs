using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Senkel.Unity.Diagnostics;

/// <summary>
/// Represents a stopwatch that is based on the <see cref="Time.timeAsDouble"/> property.
/// </summary>
public class ScaledTimeStopwatch : TimeStopwatch
{
    /// <summary>
    /// Represents the <see cref="UnityTime.Time"/> property that is based on the <see cref="Time.timeAsDouble"/> value.
    /// </summary>
    protected override TimeSpan Time => UnityTime.Time;
}

