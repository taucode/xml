namespace TauCode.Xml
{
    public static class Extensions
    {
        public static bool ContainsTextNode(this IElementSchema elementSchema)
        {
            // todo checks

            return elementSchema.ElementType == typeof(TextNodeElement);
        }
    }
}
