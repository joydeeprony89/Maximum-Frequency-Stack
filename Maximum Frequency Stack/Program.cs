using System;
using System.Collections.Generic;

namespace Maximum_Frequency_Stack
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }

  public class FreqStack
  {
    Dictionary<int, int> frequency;
    // for each frequency will have a stack and it will have same frequency elements in it
    // as it is stack so the top always will have the last inserted element
    Dictionary<int, Stack<int>> group;
    int maxFrequent = 0;
    public FreqStack()
    {
      frequency = new Dictionary<int, int>();
      group = new Dictionary<int, Stack<int>>();
    }

    public void Push(int val)
    {
      if (!frequency.ContainsKey(val)) frequency.Add(val, 0);

      int existingCount = frequency[val];
      int newCount = existingCount + 1;
      frequency[val] = newCount;
      maxFrequent = Math.Max(maxFrequent, newCount);
      if (!group.ContainsKey(newCount)) group.Add(maxFrequent, new Stack<int>());
      group[newCount].Push(val);
    }

    public int Pop()
    {
      // we have to pop max frequent no
      var maxFrequentGroup = group[maxFrequent];
      int answer = maxFrequentGroup.Pop();
      frequency[answer]--;
      // when all max frequent elements are popped, update the maxFrequent
      if (maxFrequentGroup.Count == 0) maxFrequent -= 1;

      return answer;
    }
  }

  /**
   * Your FreqStack object will be instantiated and called as such:
   * FreqStack obj = new FreqStack();
   * obj.Push(val);
   * int param_2 = obj.Pop();
   */
}
