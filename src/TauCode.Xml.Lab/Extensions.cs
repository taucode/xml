namespace TauCode.Xml.Lab
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
