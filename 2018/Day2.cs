using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace BackmanConsulting.Aoc2018
{
    public class Day2
    {
        private ITestOutputHelper _output;
        public Day2(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Day2a_SampleA1()
        {
            var result = CalculateChecksum(ParseData(sampleA1));
            Assert.Equal(12, result);
        }

        [Fact]
        public void Day2b_SampleB1()
        {
            var result = FindCommonCharsInSingleDiffStrings(ParseData(sampleB1));
            Assert.Equal("fgij", result);
        }

        private IEnumerable<string> ParseData(string data)
        {
            return data.Split("\n").Select(v => v.Trim());
        }

        private int CalculateChecksum(IEnumerable<string> input)
        {
            var twiceMatches = 0;
            var triceMatches = 0;

            foreach (var str in input)
            {
                var charGroups = str.GroupBy(v => v);
                twiceMatches += charGroups.Any(g => g.Count() == 2) ? 1 : 0;
                triceMatches += charGroups.Any(g => g.Count() == 3) ? 1 : 0;
            }

            return twiceMatches * triceMatches;
        }

        private string FindCommonCharsInSingleDiffStrings(IEnumerable<string> input)
        {
            var inputList = input.ToList();

            foreach (var str in inputList)
            {
                foreach (var str2 in inputList.Except(new [] {str}))
                {
                    var exceptString = str.Except(str2);
                    if (exceptString.Count() == 1)
                    {
                        var index = str.IndexOf(exceptString.First());
                        var strEx1 = str.Remove(index, 1);
                        var strEx2 = str2.Remove(index, 1);

                        if (Enumerable.Range(0, str2.Length-1).All(i => strEx1[i] == strEx2[i]))
                        {
                            return strEx1;
                        }
                    }
                }
            }

            throw new KeyNotFoundException("Couldn't find exception char");
        }


        [Fact]
        public void Day2a_Data()
        {
            var result = CalculateChecksum(ParseData(dataString));

            Assert.True(false, $"Result is {result}");
        }

        [Fact]
        public void Day2b_Data()
        {
            var result = FindCommonCharsInSingleDiffStrings(ParseData(dataString));

            Assert.True(false, $"Result is {result}");
        }

const string sampleA1 = @"abcdef
bababc
abbcde
abcccd
aabcdd
abcdee
ababab";

const string sampleB1 = @"abcde
fghij
klmno
pqrst
fguij
axcye
wvxyz";

const string dataString = @"vtnihorkulbfvjcyzmsjgdxplw
vtnihorvujbfejcyzmsqgdlpaw
vtnihoriulbzejcyzmsrgdxpaw
vtsihowkulbfejcyzmszgdxpaw
vtnizorkunbfejcyzmsqgdypaw
vtnihorkdlbfojcyzmsqgdfpaw
vtpioorkulbfejcysmsqgdxpaw
vtnvhorkulbfhjcyzmsqgdipaw
vtrihorkylbaejcyzmsqgdxpaw
vtnigorkulbfejcyzmszgjxpaw
rtnihorkklbfejcyzmslgdxpaw
vtnihorkqlbfejcyzmsqgmppaw
vgnisorkulbfejcyzmsqgdkpaw
atnihorkulbfejcyzmdbgdxpaw
vtnihorkulbfejcezmsqqixpaw
vtnihorkucbfejcxzmsqgdypaw
vtnihorkulxfajcyzmsqgyxpaw
vbnihorkulbfescyzmsqgdxpae
vanshorkulbfejcyzjsqgdxpaw
vtnihoukulbfejcyzmwqgdxpbw
vtndhorkulbfejcyxmgqgdxpaw
ztnihlrkupbfejcyzmsqgdxpaw
vtoihkrkulbfejhyzmsqgdxpaw
vtnihorkalbiejcyzmsqgdxeaw
vtnihorhulcfejcyzqsqgdxpaw
vtnshotkulbfejcyzmsqvdxpaw
vtnihoryulbfejcyzmsqgpspaw
vtnihorkukbfmjcyzmsqgdxpcw
vtnihorkulbfejcybmsqgdupxw
vlnihorkulbfejcyzmsqgdmpac
vtnihorkulbfejcezmfqgdkpaw
vpnihorkulbfejcyzmsqfdxyaw
vtnihorkulbjejcysmcqgdxpaw
vdnihorkulffejcyzisqgdxpaw
vtnihorkulkfsjcyzrsqgdxpaw
vtnihorkulqfegoyzmsqgdxpaw
vtnihorkulbfeyhyzgsqgdxpaw
vnnihorkulbfejcyzmdqgdxpfw
vtnihorkulstejcyzmsqgdxpak
vtnphorkujbfejcczmsqgdxpaw
vtpihorkulbfejcyzmskgdxiaw
vtnihorkulbfejcdzmxqsdxpaw
vtnihorgulbfticyzmsqgdxpaw
veniuorkulbfejcyzmsqgdmpaw
vhnihorkclbfejyyzmsqgdxpaw
vtnihorkulbfejcyzmrqgsrpaw
dtnihorkzlhfejcyzmsqgdxpaw
vtnizorkulbfejcyzhsqgdxdaw
vtnihohkulbfejcybmpqgdxpaw
vtnihbrzulbfejcyzmsqgdppaw
stnihorkulmfejcyzmsqgdxeaw
vtnihorkulbfejmgzwsqgdxpaw
vtnihcrkulbfnjdyzmsqgdxpaw
vxxihorkulbfejcyzmsqddxpaw
vtnhhorkulbfejcyzmsqgdpiaw
vtnihoakulbfvjcyzmmqgdxpaw
vtbbhorkulbfejcyqmsqgdxpaw
vtnihnukulbfejcxzmsqgdxpaw
vteihorgulkfejcyzmsqgdxpaw
vbnihorkulbfejcyzmsqgdxpmt
itnihorkulbuejcyzmsqgdxpxw
vtnfhqrkulbfejcwzmsqgdxpaw
vtnihorkubbfedcyzmsqpdxpaw
rtnihorkulhfejcyzmsqgdxpah
vtnihorzulbfejcyqmsqqdxpaw
vtnihorkulbfeecyzmsqgdcgaw
vtniuorkulbfejpyzmsqxdxpaw
vtnicorkilbfajcyzmsqgdxpaw
vtzihorkulbfejcyzmsqgaxpkw
vtnihomkulbfejcyzmsqgvmpaw
vznihockulbfejcyzmsqgdjpaw
vtqmhorkulhfejcyzmsqgdxpaw
ptnihorkulbfsjcyzbsqgdxpaw
ftnihorkulbfejcepmsqgdxpaw
vtnhhorkulbfejyyzxsqgdxpaw
vtnihorkulbfejcyzmsiwdxpxw
vtnikorkulbfejvyzmnqgdxpaw
vtnihorkulbgejoyzmsqhdxpaw
vtnihorkulbwejqylmsqgdxpaw
vtnihorkdlbfejcyzwsqgdrpaw
vtnihorkulbfojcyzmtugdxpaw
vtnihonkulbtejcyzxsqgdxpaw
vtnihorkulrfevcyzmsqgdxpcw
vtnioorkulbfejcynmsqgdxpad
vtnihorkudffejcyzhsqgdxpaw
vtnihorkelbfejcqzmsqgdxbaw
jtnihokkulbfejcyzmsqgdrpaw
ztnihorrulbfejcyzlsqgdxpaw
vtwiforkulbfejcyzmsqpdxpaw
vtnihopvulbfejcyzmsqgzxpaw
vtnihzrkulafejcyzmsqgdxpaj
vtnixoekulbfejcyzmsqgdxpak
vtnihorkulbfejxyzmsqgdxhlw
vtnihorkulbfwjcyzmmqcdxpaw
vtnihorkulbfejcywmsdgdxzaw
vtnihorkulbfejfyzmsqggxuaw
vtnihnrkurbfejcyzmsqggxpaw
vtuihorkulbkejcyzmsqgdxpww
vtnihoriuljfejcyzssqgdxpaw
vtnihorkulyftjcezmsqgdxpaw
vtnihorkklbfeccyzmsqgdppaw
vtnihorkulbfdpcyzmsqgdxpcw
vtnihqrkulgfejcyzmeqgdxpaw
vtnihorktlbfejdyzmswgdxpaw
vinihzrkulbfeacyzmsqgdxpaw
vtuihorkupbfejcyzmsqgdxplw
vtnihorkulbfcjcyzmlqgdxpsw
vtnihorkllbfejcyzmsqgdxvak
qtnihorkulbfdjcyzusqgdxpaw
vtniherkulbhejcyzmsqgzxpaw
vtnzhorgulbfejcyzmsqgdxpew
vtnihoykulhfjjcyzmsqgdxpaw
vtnihookulyfejcyzmsqgdxqaw
jtnihorkulbfejcyzmssgdxpaq
vtnicorkulwfejcyzmsxgdxpaw
wtnihorkuubfejcyzmsqgdxpam
vtnihorkuggfejcyzmsdgdxpaw
vtnihurkulbfgjcyzmsqrdxpaw
ptnihorkuabfejcyzmsqgqxpaw
vtrihoykulbfejcyzmsqgdxpam
otnihorkulbfejcyzmpqgdxpjw
vtyihorkulbfejdyznsqgdxpaw
vtnihornulbfrjcizmsqgdxpaw
vtnihfrlulbfejcyzmsqgdxpah
atnihorkulbfejcyossqgdxpaw
vtnihorkuljfejcyzysqgdxpow
vtniyorkulbfejcyzmsqgdxbaz
venihorkulbfejctzmqqgdxpaw
vtrihorkulbfejcyjmsqgdxpfw
venitorkulbfexcyzmsqgdxpaw
vtbihorkulbfejcyzmwqgdxpyw
vtnihorkuubfejxyzmsqgdxkaw
vtqihorkulbnejcyzmsqgdxnaw
vteihorkurbfejcyzmsqwdxpaw
vtgjhorkxlbfejcyzmsqgdxpaw
ytniworkulbfejcyzmsqgdxptw
vtnihorkulbfejcyzmsvgixhaw
dtnihorkusbfejcyzmsqidxpaw
vtnihurkulbfejcdzmkqgdxpaw
vtgihorkulbfejcyzhsqgdxpaf
vtniudrkulbfeacyzmsqgdxpaw
vtnihorkulbfejcyemsokdxpaw
vtnihorkulbfejcyjmwqgdxpag
vtnihorpulbfetcpzmsqgdxpaw
ctnzhorkulbfejcyzmfqgdxpaw
vanihorkuhbwejcyzmsqgdxpaw
vtnihonkurbfejcyzvsqgdxpaw
vtnihgrkulbcejcbzmsqgdxpaw
vtnihorkutbfeacyzmsqcdxpaw
vtniaorkuhbfqjcyzmsqgdxpaw
vtnihorkylbfozcyzmsqgdxpaw
vtnihorkulbfejcypmfqgdxpbw
vtrphonkulbfejcyzmsqgdxpaw
vtnihorkulbdejcywmsqydxpaw
vtnikorkulbfejvyzknqgdxpaw
vznihorkulbfejcyzmsqbdxpam
vtmghorkulbfejcyzmsqghxpaw
vtnihorkulbfejcyzmshglxpfw
vtiihorkulbfejcjzmsqgdxoaw
rtnihorkulbfejcuzmsqgdxpow
vtnthoikulbuejcyzmsqgdxpaw
vtniholkulbfcjcyzmsqgdxpvw
vdnihorkulbbejcyzmsqgdxdaw
ntnihorkulbfojcyzmsqgdxzaw
vtniqorkulbfejcyzklqgdxpaw
vtnihorkulhfejcpzmsqgdxprw
vhnihorkulqfejcyzmsqgdapaw
vtnihorkolafejcyzmsqadxpaw
vtnihorkulbpejcyzasqgtxpaw
vtnihgiyulbfejcyzmsqgdxpaw
dtnihorkulbffjcyzmsqgdfpaw
vtnvhorhulbfejcyzmpqgdxpaw
vtniholkulbfebcyzmsqgnxpaw
vunihorkulbbejcyznsqgdxpaw
vtnihorkulbfehcyomsqgaxpaw
vtnihorkllboejcyzmsigdxpaw
vtnihwrkulbfejcywmsqgdxiaw
vtnoherkulbfbjcyzmsqgdxpaw
vtnbhorkulbfejcyzmsqgkxpaa
vtnihorkilbfdjxyzmsqgdxpaw
vtnfhorkuvbfejcyzmsqgixpaw
vtnyhorkulbpejcyzmsqgdxjaw
vtnihomkalbfejcyzmqqgdxpaw
vtnihorkulbfejcybmsqgjxvaw
vtnihorkulbfgjcnzmsqbdxpaw
vtnihorkulbfejcyzmpqgsxpap
lmnihorkulbfejcizmsqgdxpaw
vtmahkrkulbfejcyzmsqgdxpaw
vtnihorkulbfujcyrcsqgdxpaw
vtnzhorkulbfejcyzjvqgdxpaw
vtnicorkulbfejmyzmsqgdxvaw
vtnyhojkulbfejcyzmsngdxpaw
vtnuhorkulbfejcyzlsqgdxpmw
vtnihorkulufejcgzmtqgdxpaw
vtnihfrkulbfejnyzmsigdxpaw
vtnzhorkulbdejnyzmsqgdxpaw
vttihorkulbfejcyzmyqgdxwaw
vknihorkulbfejnylmsqgdxpaw
vtnihorkulbfejcfrmsqgdxpaz
vtnchormulbfejcyzmsqgdopaw
vtnihorkulbfebcyzusqgdxpam
jtnihorwulbfejcyzksqgdxpaw
ctnihodkutbfejcyzmsqgdxpaw
vonihorkultfejcyzmsqgixpaw
vtnihorkulbqejcyzmsqgdypcw
vfnihorkulbfbjcyzmsqcdxpaw
utnihorkulbfejcyqmsqgdxraw
vtnihorkjllfejcyzmskgdxpaw
vtnihorkulbfejcyvisqgdapaw
vtnihorkclzfejcyzmsqvdxpaw
vtnihwrkvlffejcyzmsqgdxpaw
vtnihlrkulbfejcrzmsqydxpaw
vtnihorkulbfbjtysmsqgdxpaw
vtnihorkulbfxjcepmsqgdxpaw
ttnihorkulbfejpyzmsqgdxpaz
vtnwhorkolbfejcdzmsqgdxpaw
vtnihorkulbfejcyzdsqgdxppn
vtnwporkulbfercyzmsqgdxpaw
vtnshorxuvbfejcyzmsqgdxpaw
vtnihxrkulbfejcyomsqfdxpaw
vtnwhorkrljfejcyzmsqgdxpaw
vqnihorkulbfejcyzmtqgdxpuw
vtnnhorkulbfhrcyzmsqgdxpaw
vtuihwrkulbfedcyzmsqgdxpaw
vtgbhorkucbfejcyzmsqgdxpaw
vtnitorkulbfejcozmsqgdkpaw
otnihomkulbfejcyzmsqgdxhaw
vtnihgrkulbfrjcyzmsqxdxpaw
vtnihorkulbfujcyzmsqghxpzw
vsnihopkhlbfejcyzmsqgdxpaw
vtniherkulbfejcyzmpzgdxpaw
vtnxhorkulbfejcszmsqgdxcaw
vtnihorkulbfejctzmsxadxpaw
vtnihorkslbmejcyzmsqgnxpaw
vtnwhorgulbfegcyzmsqgdxpaw
vtnihorkulbfsjcyzmsqgdxiau
vtnihorkulbfejcyzmsqldxpbj
vtnghorkulbfmjcyzmsqgdxpaa
vtnihorkulbfetcyzmpqudxpaw
vtnbhorkulbfejcyzmsqgdupyw
ntnihorhulbfejwyzmsqgdxpaw
vjnihorkulbfejcyqosqgdxpaw
vtiihorbulbfejcbzmsqgdxpaw
vtnihorkulbfejxlzmpqgdxpaw
vtnihorkolbfejcyfmsqgdxraw
vtnihqrrulbfedcyzmsqgdxpaw
ctnihorkulbfejcyzmsqgdxpsy
vtnihorkulbfkjcezmspgdxpaw
ztnihorkulbmcjcyzmsqgdxpaw
vinihorkulbfedcyzmsqgdxpau";
    }
}
