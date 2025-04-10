namespace PathfinderSample.Utilities
{
    // instance로 만들지 않을 것이기 때문에 class 앞에 static을 붙임
    static class RandomExtensions
    {
        public static void Shuffle(this Random random, Coord[] coords)
        {
            int n = coords.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int j = random.Next(i, n);

                if (j != i)
                {
                    Coord temp = coords[i];
                    coords[i] = coords[j];
                    coords[j] = temp;
                }
            }
        }
    }
}
