using System;
using System.Linq;
using System.Reflection;

namespace ProjectEulerCore
{
  /// <summary>
  /// The wrapping class that provide access to run the solutions
  /// </summary>
  public class SolutionRunner
  {
    /// <summary>
    /// The Class name that when combined with problem number (int) is run 
    /// </summary>
    private const string cClassNameStart = "Problem";

    /// <summary>
    /// Method to execute the solutions to the Project Euler problems
    /// </summary>
    /// <param name="problemNumber">The problem number to execute</param>
    /// <returns>SolutionOutput object, giving info on result of running the problem</returns>
    public static SolutionOutput RunSolution(int problemNumber)
    {
      SolutionOutput solutionOutput;
      try
      {
        BaseProblem problem = GetProblemInstance(problemNumber);
        solutionOutput = problem.Solve();
      }
      catch (Exception exception)
      {
        solutionOutput = new SolutionOutput();
        solutionOutput.ValidationResult = false;
        solutionOutput.Output = exception.Message;
      }
      return solutionOutput;
    }

    /// <summary>
    /// Finds the Class for the problem based on string + passed in problem number
    /// Saves having a large switch statement
    /// </summary>
    /// <param name="problemNumber">The problem number to use to find class</param>
    /// <returns>BaseProblem object for the problem</returns>
    private static BaseProblem GetProblemInstance(int problemNumber)
    {
      string className = string.Format("{0}{1}",cClassNameStart, problemNumber);
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      if (null == executingAssembly)
        throw new Exception("Could not get executing assembly");

      Type problemClass = executingAssembly.GetTypes().FirstOrDefault(type => string.Compare(type.Name, className,StringComparison.CurrentCultureIgnoreCase) == 0);
      if (null == problemClass)
        throw new ArgumentException("Could not find class for problem in assembly");

      BaseProblem problemInstance = (BaseProblem)Activator.CreateInstance(problemClass);
      problemInstance.ProblemNumber = problemNumber;
      return problemInstance;
    }
  }
}
