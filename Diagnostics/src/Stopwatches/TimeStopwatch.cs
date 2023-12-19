using UnityEngine;
using Senkel.Model.Measuring;
using System.Diagnostics.CodeAnalysis;

namespace Senkel.Unity.Diagnostics;

/// <summary>
/// Represents a stopwatch that is based on a constantly elapsing time span.
/// </summary>
public abstract class TimeStopwatch : IStopwatch
{
    private IReadOnlyStopwatch _innerStopwatch;

    /// <summary>
    /// The time that the stopwatch is based on which is constantly elapsing.
    /// </summary>
    protected abstract TimeSpan Time { get; }

    public TimeSpan Elapsed => _innerStopwatch.Elapsed;
    public bool Running => _innerStopwatch.Running;

    /// <summary>
    /// Creates a new instance of the <see cref="TimeStopwatch"/> with an initial <see cref="Elapsed"/> value of <see cref="TimeSpan.Zero"/>.
    /// </summary>
    public TimeStopwatch() => Reset();

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
        private readonly TimeStopwatch _stopwatch;
        private readonly TimeSpan _initialTime;

        public TimeSpan Elapsed => GetDuration(_initialTime);
        public bool Running => false;

        public RunStopwatch(TimeStopwatch stopwatch, TimeSpan offsetTime)
        {
            _stopwatch = stopwatch;
            _initialTime = GetDuration(offsetTime);
        }

        private TimeSpan GetDuration(TimeSpan time)
        {
            return Time - time;
        }

        private TimeSpan Time => _stopwatch.Time;
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
