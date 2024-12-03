namespace CheckAlphabetWebAPI.Services
{
    public class AlphabetCheckerService : IAlphabetCheckerService
    {
        public bool ContainsAllAlphabets(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            // Normalize input to lowercase
            var normalizedInput = input.ToLower();

            // Check if all letters (a-z) are present
            return Enumerable.Range('a', 26).All(c => normalizedInput.Contains((char)c));
        }
    }
}
