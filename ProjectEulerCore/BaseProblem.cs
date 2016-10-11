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
      SolutionOutput solutionOutput;
      if (!ValidationSolve())
      {
        solutionOutput = new SolutionOutput();
        solutionOutput.ValidationResult = false;
        solutionOutput.Output = "Validation against example failed. Not running full solve";
      }
      else
      {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        solutionOutput = InnerSolve();
        timer.Stop();
        solutionOutput.DurationMilliseconds = timer.Elapsed.TotalMilliseconds;
        solutionOutput.ValidationResult = true;
      }
      return solutionOutput;  
    }
    /// <summary>
    /// Inheriting classes implement to actually solve the problem
    /// </summary>
    /// <returns>SolutionOutput object, giving info on result of running the problem</returns>
    internal abstract SolutionOutput InnerSolve();
    /// <summary>
    /// Inheriting classes implement to validation against example given for problem
    /// </summary>
    /// <returns>true if the solution give answer to example as expected</returns>
    internal abstract bool ValidationSolve();
  }
}
