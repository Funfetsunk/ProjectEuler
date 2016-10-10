using System.Diagnostics;

namespace ProjectEulerCore
{
  /// <summary>
  /// Abstract Class for all problems
  /// Wraps up the solve to add timer.
  /// Inheriting Classes then implement solution in InnerSolve
  /// </summary>
  internal abstract class BaseProblem
  {
    /// <summary>
    /// Problem number being solved
    /// </summary>
    internal int ProblemNumber { get; set; }
    /// <summary>
    /// Executes the solution for the problem
    /// </summary>
    /// <returns>SolutionOutput object, giving info on result of running the problem</returns>
    internal SolutionOutput Solve()
    {
      Stopwatch timer = new Stopwatch();
      timer.Start();
      SolutionOutput solutionOutput = InnerSolve();
      timer.Stop();
      solutionOutput.DurationMilliseconds = timer.Elapsed.TotalMilliseconds;
      return solutionOutput;  
    }
    /// <summary>
    /// Inheriting classes implement to actually solve the problem
    /// </summary>
    /// <returns>SolutionOutput object, giving info on result of running the problem</returns>
    internal abstract SolutionOutput InnerSolve();
  }
}
