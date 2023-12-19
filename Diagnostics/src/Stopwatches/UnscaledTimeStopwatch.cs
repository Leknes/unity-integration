using UnityEngine;

namespace Senkel.Unity.Diagnostics
{
    /// <summary>
    /// Represents a stopwatch that is based on the <see cref="Time.unscaledTimeAsDouble"/> property.
    /// </summary>
    public class UnscaledTimeStopwatch : TimeStopwatch
    {
        /// <summary>
        /// Represents the <see cref="UnityTime.UnscaledTime"/> property that is based on the <see cref="Time.unscaledTimeAsDouble"/> value.
        /// </summary>
        protected override TimeSpan Time => UnityTime.UnscaledTime;
    }
}
