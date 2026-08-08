using ProductsHub.API.Infrastructure;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid clientId)
        {
            var dbContext = new ProductsHubDbContext();

            var client = dbContext.Clients.FirstOrDefault(c => c.Id == clientId) ?? throw new NotFoundException("Client not found.");

            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();
        }


        public int[] TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            var buckets = new List<int>[nums.Length + 1];

            foreach (var pair in dict)
            {
                var frequency = pair.Value;

                buckets[frequency] ??= new List<int>();
                buckets[frequency].Add(pair.Key);
            }

            var result = new List<int>();

            for (int i = buckets.Length - 1; i >= 0; i--)
            {
                if (buckets[i] == null)
                    continue;

                foreach (var num in buckets[i])
                {
                    result.Add(num);

                    if (result.Count == k)
                        return result.ToArray();
                }
            }

            return result.ToArray();
        }
    }
}
