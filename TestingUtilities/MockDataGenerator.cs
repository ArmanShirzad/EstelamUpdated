using Bogus;
using EstelamIsargari.Pages;
namespace EstelamIsargari.TestingUtilities
{
    public class MockDataGenerator
    {
        public ResponseModel GenerateMockResponse()
        {
            var faker = new Faker<ResponseModel>()
                 .RuleFor(r => r.ApplicantId, f => f.Random.Long(1000000000, 9999999999))
           .RuleFor(r => r.IsAsr, f => f.Random.Bool(0.8f))  // 80% chance of true
        .RuleFor(r => r.IsAzd, f => f.Random.Bool(0.7f))  // 70% chance of true
        .RuleFor(r => r.IsJbz, f => f.Random.Bool(0.9f))  // 90% chance of true
        .RuleFor(r => r.IsMfq, f => f.Random.Bool(0.6f))  // 60% chance of true
        .RuleFor(r => r.IsShd, f => f.Random.Bool(0.85f));

            return faker.Generate();
        }

        // Add more methods for generating other types of mock data as needed.
    }
}
