using System.Diagnostics.CodeAnalysis;

namespace CollectionsSample
{
    class TreasureChest
    {
        public TreasureChest(DynamicArray<string> rewards)
        {
            rewards.Add("Basic bow");
            rewards.Remove(x => x.Contains("sword"));
            _rewards = new string[rewards.Count];

            for (int i = 0; i < rewards.Count; i++)
            {
                _rewards[i] = rewards[i];
            }
        }

        string[] _rewards;

        public string GetRandomReward()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _rewards.Length);
            return _rewards[randomIndex];
        }
    }
}
