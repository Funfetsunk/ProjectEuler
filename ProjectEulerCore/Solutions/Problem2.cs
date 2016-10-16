﻿using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCore
{
  internal class Problem2 : BaseProblem
  {
    /// <summary>
    /// Each new term in the Fibonacci sequence is generated by adding the previous two terms.By starting with 1 and 2, the first 10 terms will be:
    /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    /// </summary>
    /// <returns>SolutionOutput object, giving info on result of running the problem</returns>
    internal override SolutionOutput InnerSolve()
    {
      SolutionOutput solutionOutput = new SolutionOutput();
      int a, b, c;
      a = 1;
      b = 2;
      List<int> theEvens = new List<int>();
      theEvens.Add(b);
      do
      {
        c = a + b;
        a = b;
        b = c;
        if (c % 2 == 0)
          theEvens.Add(c);
      } while (c < 4000000);
      
      solutionOutput.Output = "The calculated answer is:" + theEvens.Sum();
      return solutionOutput;
    }

    /// <summary>
    /// There is no example given to check solution 
    /// </summary>
    /// <returns>true if the solution give answer to example as expected</returns>
    internal override bool ValidationSolve()
    {
      return true; 
    }
       
  }
}