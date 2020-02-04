using Models;
using Repositories;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            this.scoreRepository = scoreRepository;
        }

        public CustomerDto SaveCustomer(CustomerDto customerDto, Task<string> weather)
        {
            CustomerDto retrievedDto = RetrieveCustomerByName(customerDto.Name);

            if (retrievedDto == null)
            {
                AddCustomer(customerDto);

                return customerDto;
            }

            else
            {
                EditCustomer(retrievedDto, weather);

                return retrievedDto;
            }
        }

        public CustomerDto RetrieveCustomerByName(string name)
        {
            Customer customer = scoreRepository.RetrieveByName(EncodeName(name));

            if (customer != null)
            {
                CustomerDto customerDto = new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Score = customer.Score
                };

                return customerDto;
            }

            else
            {
                return null;
            }
        }

        public void AddCustomer(CustomerDto customerDto)
        {
            customerDto.Score = GetScore(customerDto.Name);

            Customer customer = new Customer
            {
                Id = customerDto.Id,
                Score = customerDto.Score
            };

            customer.Name = EncodeName(customerDto.Name);

            scoreRepository.Add(customer);
        }

        public void EditCustomer(CustomerDto retrievedDto, Task<string> weather)
        {
            int score = retrievedDto.Score;

            if (weather.Result.Contains("Rain"))
            {
                score -= new Random().Next(1, 10);
            }

            else
            {
                score += new Random().Next(1, 10);
            }

            if (score > 999)
            {
                retrievedDto.Score -= 10;
            }

            else
            {
                retrievedDto.Score = score;
            }

            Customer customer = new Customer
            {
                Id = retrievedDto.Id,
                Name = retrievedDto.Name,
                Score = retrievedDto.Score
            };

            scoreRepository.UpdateCustomer(customer);
        }

        private static string EncodeName(string rawData)
        {  
            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        private int GetScore(string name)
        {         
            Random rng = new Random();

            int num = rng.Next(0, 1000);

            return num;
        }
    }
}
