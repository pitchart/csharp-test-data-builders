using Application.Tests.Builders;
using Diverse;

namespace Application.Tests
{
    public static class FuzzerExtension
    {
        public static BookBuilder AnEducationBook(this IFuzz fuzz)
        {
            return BookBuilder.AnEducationBook(fuzz);
        }
    }
}