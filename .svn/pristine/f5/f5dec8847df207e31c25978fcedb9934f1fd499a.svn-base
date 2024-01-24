namespace Com.Suncor.Olt.Common.Extension
{
    public static class CharacterExtensions
    {
        public static char ConvertCharacterToUpperCase(this char c)
        {
            return c.IsLowerCaseCharacter() ? c.ToString().ToUpper()[0] : c;
        }

        public static bool IsLowerCaseCharacter(this char c)
        {
            return (c >= 'a' && c <= 'z');
        }

        public static bool isUpperCaseCharacter(this char c)
        {
            return (c >= 'A' && c <= 'Z');
        }

        public static bool IsAlphabeticalCharacter(this char c)
        {
            return (c.IsLowerCaseCharacter() || c.isUpperCaseCharacter());
        }
    }
}