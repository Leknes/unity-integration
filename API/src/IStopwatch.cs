namespace Senkel.Unity.API;

/// <summary>
/// Represents a stopwatch that can be started, stopped and reset.
/// </summary>
public interface IStopwatch
{
    /// <summary>
    /// The total time measured by this stopwatch.
    /// </summary>
    public double Elapsed { get; }

    /// <summary>
    /// Starts or resumes the measurement of the stopwatch.
    /// </summary>
    public void Start();

    /// <summary>
    /// Stops the measurement of the stopwatch, but should not reset the <see cref="Elapsed"/> value.
    /// </summary>
    public void Stop();

    /// <summary>
    /// Stops the measurement of the stopwatch and resets the <see cref="Elapsed"/> value.
    /// </summary>
    public void Reset();

    /// <summary>
    /// Resets the <see cref="Elapsed"/> value and restarts the stopwatch.
    /// </summary>
    public void Restart();
}