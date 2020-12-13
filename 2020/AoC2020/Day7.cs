using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2020
{
    public class Day7
    {
        private readonly IList<Bag> _bags;

        public Day7(string bagRules)
        {
            _bags = Parse(bagRules);
        }

        private IList<Bag> Parse(string bagRulesData)
        {
            var bagRules = bagRulesData.SplitByNewLine();

            var bags = bagRules
                .Select(b => new Bag(b))
                .ToList();

            foreach (var bag in bags)
            {
                foreach (var contained in bag.ContainedBags)
                {
                    var containedObj = bags.Where(b => b.Color == contained.Key);
                    foreach (var containedBag in containedObj)
                    {
                        containedBag.Parents.Add(bag);
                        bag.Children.Add(containedBag, contained.Value);
                    }
                }
            }

            return bags;
        }

        public int FindCountOfParentsContainingGoldBag()
        {
            return _bags
                .Single(b => b.Color == "shiny gold")
                .GetParentsUpToRoot()
                .Distinct()
                .Count();
        }

        public int FindCountOfContainedBagsInGoldBag()
        {
            return _bags
                .Single(b => b.Color == "shiny gold")
                .GetSumOfAllChildrenDownToLeafs();
        }

        record Bag : IEqualityComparer<Bag>
        {
            private static Regex ParentBagRegex = new Regex(@"^(?<bag_color>.+) bags contain (?<contains>(\d+ .+)|(no other bags)).$", RegexOptions.Compiled);
            private static Regex ContentRegex = new Regex(@"^(?<count>\d+) (?<color>\w+ \w+) \bbags?\b", RegexOptions.Compiled);

            public string Color { get; }
            public Dictionary<string, int> ContainedBags { get; set; } = new Dictionary<string, int>();
            public IList<Bag> Parents { get; set; } = new List<Bag>();
            public Dictionary<Bag, int> Children { get; set; } = new Dictionary<Bag, int>();

            public Bag(string bagData)
            {
                var parentBagMatch = ParentBagRegex.Match(bagData);

                Color = parentBagMatch.Groups["bag_color"].ToString();

                var contains = parentBagMatch.Groups["contains"].ToString();
                
                if (contains == "no other bags")
                {
                    return;
                }
                else
                {
                    var containedBags = contains.SplitByCustom(",");

                    foreach (var containedBag in containedBags)
                    {
                        var containedBagMatch = ContentRegex.Match(containedBag);

                        var color = containedBagMatch.Groups["color"].ToString();
                        var count = int.Parse(containedBagMatch.Groups["count"].ToString());

                        ContainedBags.Add(color, count);
                    }
                }
            }

            internal IList<Bag> GetParentsUpToRoot()
            {
                var bagsUpToRoot = Parents.SelectMany(p => p.GetParentsUpToRoot()).ToList();
                return new List<Bag>(Parents.Concat(bagsUpToRoot));
            }

            internal int GetSumOfAllChildrenDownToLeafs()
            {
                return Children.Select(c => c.Value + c.Value * c.Key.GetSumOfAllChildrenDownToLeafs()).Sum();
            }

            public bool Equals(Bag x, Bag y)
            {
                return x?.Color == y?.Color;
            }

            public int GetHashCode([DisallowNull] Bag obj)
            {
                return obj.Color.GetHashCode();
            }
        }
    }
}
