using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class ScoreService : IScoreService
    {
        private IScoreRepository scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            this.scoreRepository = scoreRepository;
        }

        public CustomerDto SaveCustomer(CustomerDto customerDto)
        {
            //retrieve a customer
            CustomerDto retrievedDto = RetrieveCustomerByName(customerDto.Name);

            //if a customer doesn't exist, add it
            if (retrievedDto == null)
            {
                AddCustomer(customerDto);

                return customerDto;
            }

            //if a customer exists, update it - give it a new score
            else
            {
                int score = retrievedDto.Score;

                score += new Random().Next(0, 10);

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
                //Name = customerDto.Name,
                Score = customerDto.Score
            };

            customer.Name = EncodeName(customerDto.Name);

            scoreRepository.Add(customer);
        }

        private int GetScore(string name)
        {
            Random rng = new Random();
            int num = rng.Next(0, 999);
            return num;
        }

        private static string EncodeName(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
