namespace ProjectEulerCore
{
  internal class Problem1 : BaseProblem
  {
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    /// <returns>SolutionOutput object, giving info on result of running the problem</returns>
    internal override SolutionOutput InnerSolve()
    {
      SolutionOutput solutionOutput = new SolutionOutput();
      solutionOutput.Completed = false;
      solutionOutput.Output = "Not yet started";
      return solutionOutput;
    }
  }
}
