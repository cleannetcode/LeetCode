public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        if (n < 0 || n > 8) {
            return Array.Empty<string>();
        }
        
        var set = new HashSet<string>();
        
        void Generate(
            string current, 
            int openPranthesises, 
            int closePranthesises)
        {
            if (current.Length == n*2) {
                set.Add(current);
                return;
            }
            if (openPranthesises < n)
                Generate(current+"(", openPranthesises+1, closePranthesises);
            if (closePranthesises < openPranthesises)           
                Generate(current + ")", openPranthesises, closePranthesises+1);
        }
        
        Generate("", 0, 0);
        return set.ToArray();
    }
}