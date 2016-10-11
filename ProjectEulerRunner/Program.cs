using System;
using System.Diagnostics;
using ProjectEulerCore;

namespace ProjectEulerRunner
{
  /// <summary>
  ///  A program to run the solutions to the Project Euler problems
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// The Project Runner takes in a Problem number  
    /// It then executes the code to solve the problem. 
    /// </summary>
    /// <param name="args">Problem number as int</param>
    /// <returns>ExitCode as int</returns>
    internal static int Main(string[] args)
    {
      try
      {
        return DoStuff(args);
      }
      catch (Exception ex)
      {
        Console.Error.WriteLine("Error: {0}", ex);
        return ExitCode.Exception;
      }
    }

    /// <summary>
    /// The main body of the program. 
    /// </summary>
    /// <param name="args">Problem number as int</param>
    /// <returns>ExitCode as int</returns>
    private static int DoStuff(string[] args)
    {
      Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

      // If we have no program arguments fail
      if (args.Length < 1)
      {
        Trace.WriteLine("Please enter a Problem Id that corresponds to one on https://projecteuler.net/");
        return ExitCode.ParameterMissing;
      }

      int problemId;
      // Check if Problem Id is an int
      if (!int.TryParse(args[0], out problemId))
      {
        Trace.WriteLine("Please enter Problem Id as an int. Value given: " + problemId);
        return ExitCode.ProblemIdArgNotAnInt;
      }

      SolutionOutput soultionOutput = SolutionRunner.RunSolution(problemId);
      Trace.WriteLine("Running Problem No. " + problemId);
      Trace.WriteLine("Solution Output: " + soultionOutput.Output);
      Trace.WriteLine("DurationMilliseconds: " + soultionOutput.DurationMilliseconds);
      bool didProblemPass = soultionOutput.ValidationResult;
      if (didProblemPass)
        return ExitCode.Ok;

      return ExitCode.ProblemFailed;
    }
  }
}

/// <summary>
/// A list of the exit codes and their meanings
/// </summary>
internal static class ExitCode
{
  public static int Ok { get { return 0; } }
  public static int Exception { get { return 1; } }
  public static int ParameterMissing { get { return 2; } }
  public static int ProblemIdArgNotAnInt { get { return 3; } }
  public static int ProblemFailed { get { return 4; } }
  public static int UnknownProblemId { get { return 5; } }
}