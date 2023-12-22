using UnityEngine; 
using System.Diagnostics.CodeAnalysis;
using System;  

namespace Senkel.Unity.Diagnostics;

/// <summary>
/// Represents a stopwatch that is relative to a constantly elapsing time span.
/// </summary>
public abstract class RelativeStopwatch : IStopwatch
{
    private IReadOnlyStopwatch _innerStopwatch;

    /// <summary>
    /// The time that the stopwatch is relative to which is constantly elapsing.
    /// </summary>
    protected abstract TimeSpan AbsoluteTime { get; }

    public TimeSpan Elapsed => _innerStopwatch.Elapsed;
    public bool Running => _innerStopwatch.Running;

    /// <summary>
    /// Creates a new instance of the <see cref="RelativeStopwatch"/> with an initial <see cref="Elapsed"/> value of <see cref="TimeSpan.Zero"/>.
    /// </summary>
    
    public RelativeStopwatch() => Reset();

    private RunStopwatch CreateRunStopwatch(TimeSpan offsetTime)
    {
        return new RunStopwatch(this, offsetTime);
    }

    [MemberNotNull(nameof(_innerStopwatch))]
    public void Reset()
    {
        _innerStopwatch = new PauseStopwatch(TimeSpan.Zero);
    }

    public void Restart()
    {
        _innerStopwatch = CreateRunStopwatch(TimeSpan.Zero);
    }

    public void Start()
    {
        if (!Running)
            _innerStopwatch = CreateRunStopwatch(Elapsed);
    }
    public void Stop()
    {
        if (Running)
            _innerStopwatch = new PauseStopwatch(Elapsed);
    }

    private class RunStopwatch : IReadOnlyStopwatch
    {
        private readonly RelativeStopwatch _stopwatch;
        private readonly TimeSpan _initialTime;

        public TimeSpan Elapsed => GetDuration(_initialTime);
        public bool Running => false;

        public RunStopwatch(RelativeStopwatch stopwatch, TimeSpan offsetTime)
        {
            _stopwatch = stopwatch;
            _initialTime = GetDuration(offsetTime);
        }

        private TimeSpan GetDuration(TimeSpan time)
        {
            return Time - time;
        }

        private TimeSpan Time => _stopwatch.AbsoluteTime;
    }
    private class PauseStopwatch : IReadOnlyStopwatch
    {
        public PauseStopwatch(TimeSpan elapsed)
        {
            Elapsed = elapsed;
        }

        public TimeSpan Elapsed { get; init; }

        public bool Running => false;
    }
}
