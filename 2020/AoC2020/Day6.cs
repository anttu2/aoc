using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day6
    {
        IList<GroupForm> _formsData;

        public Day6(string formsData)
        {
            _formsData = Parse(formsData);
        }

        public int SumAllDistinctAnswers()
        {
            return _formsData.Select(f => f.GetSumOfDistinctAnswers()).Sum();
        }
        public int SumAllGroupDistinctAnswers()
        {
            return _formsData.Select(f => f.GetSumOfGroupDistinctAnswers()).Sum();
        }

        private IList<GroupForm> Parse(string formsDataBlob)
        {
            var formsData = formsDataBlob.SplitByDoubleNewLine();

            return formsData.Select(f => new GroupForm(f)).ToList();
        }

        private class GroupForm
        {
            public IList<string> Answers { get; }

            public GroupForm(string data)
            {
                Answers = data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            }

            public int GetSumOfDistinctAnswers()
            {
                return Answers.SelectMany(a => a.ToArray()).Distinct().Count();
            }

            public int GetSumOfGroupDistinctAnswers()
            {
                return
                    Answers
                    .SelectMany(a => a.ToArray())
                    .GroupBy(a => a)
                    .Where(g => g.Count() == Answers.Count)
                    .Select(_ => 1)
                    .Sum();
            }
        }
    }
}
