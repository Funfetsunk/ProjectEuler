using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerCore
{
  internal class Problem1 : BaseProblem
  {
    /// <summary>
    /// Where to put the answer from example of problem. 
    /// To check we are getting the right simple answer.
    /// </summary>
    const int cValidationTheAnswer = 23;
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    /// <returns>SolutionOutput object, giving info on result of running the problem</returns>
    internal override SolutionOutput InnerSolve()
    {
      SolutionOutput solutionOutput = new SolutionOutput();
      int answer = MultiplesOf3And5(1000);
      solutionOutput.Output = "The calculated answer is:" + answer;
      return solutionOutput;
    }

    /// <summary>
    /// Checks the solution against example below 10
    /// </summary>
    /// <returns>true if the solution give answer to example as expected</returns>
    internal override bool ValidationSolve()
    {
      int answer = MultiplesOf3And5(10);
      return answer == cValidationTheAnswer; 
    }

    /// <summary>
    /// Gets sum of the distinct list of all the natural numbers below 'numbersBelow' that are multiples of 3 & 5
    /// </summary>
    /// <param name="numbersBelow">that max number of which to be below</param>
    /// <returns>sum of the distinct list of all the natural numbers below 'numbersBelow' that are multiples of 3 & 5</returns>
    private int MultiplesOf3And5(int numbersBelow)
    {
      List<int> numbers = GetListForMulitples(3, numbersBelow);
      numbers.AddRange(GetListForMulitples(5, numbersBelow));
      return numbers.Sum();
    }

    /// <summary>
    /// Gets list of all the natural numbers below 'numbersBelow' that are multiples of passed in 'multiple'
    /// </summary>
    /// <param name="multiple"></param>
    /// <param name="numbersBelow"></param>
    /// <returns></returns>
    private List<int> GetListForMulitples(int multiple, int numbersBelow)
    {
      int i = 0;
      List<int> numbers = new List<int>();
      do
      {
        i = i + multiple;
        numbers.Add(i);
      } while (i < numbersBelow - multiple);

      return numbers;
    }
  }
}