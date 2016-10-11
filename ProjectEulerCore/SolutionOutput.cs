namespace ProjectEulerCore
{
  /// <summary>
  /// Simple class to hold info on state of problem solving
  /// </summary>
  public class SolutionOutput
  {
    /// <summary>
    /// To check we are getting the right simple answer.
    /// </summary>
    public bool ValidationResult { get; set; }
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
