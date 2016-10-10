namespace ProjectEulerCore
{
  /// <summary>
  /// Simple class to hold info on state of problem solving
  /// </summary>
  public class SolutionOutput
  {
    /// <summary>
    /// If problem has been solved
    /// </summary>
    public bool Completed { get; set; }
    /// <summary>
    /// How long it took to run the solution for problem
    /// </summary>
    public double DurationMilliseconds { get; set; }
    /// <summary>
    /// A string output for display in calling app
    /// </summary>
    public string Output { get; internal set; }
  }
}
