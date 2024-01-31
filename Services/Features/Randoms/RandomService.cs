using System;

namespace ProvaPub.Services
{
    public class RandomService
    {
        private readonly Random random;
        private int seed;

        /// <summary>
        /// Cria uma nova instância do serviço de geração de números aleatórios.
        /// </summary>
        public RandomService()
        {
            random = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Gera um número aleatório inteiro entre 0 e 99.
        /// </summary>
        /// <returns>O número aleatório gerado.</returns>
        public int GetRandom()
        {
            seed = random.Next(100);
            return seed;
        }
    }
}
