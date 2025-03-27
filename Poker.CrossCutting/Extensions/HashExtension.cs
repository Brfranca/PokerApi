namespace Poker.CrossCutting.Extensions
{
    public static class HashExtension
    {
        public static string Hash(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        public static bool Verify(this string value, string hash)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrEmpty(hash))
                throw new ArgumentNullException(nameof(hash));

            return BCrypt.Net.BCrypt.Verify(value, hash);
        }
    }
}
