using System;
using System.Threading.Tasks;
using Stripe;
using WebUI.Models;

namespace WebUI.Services
{
    public class ProcessPayment
    {
        public static async Task<dynamic> PayAsync(CheckoutModel payModel)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51JsEIUIlJsyPbmS73aPzZyjvvbFoCAqtqqZhOVSX2sdj7UCJwlS9Lj1z1arO8klNCTL4HEhZfYQZtklCHS4pLKXz00ZiquLr2m";

                var options = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = payModel.CardNumber,
                        ExpMonth = payModel.Month,
                        ExpYear = payModel.Year,
                        Cvc = payModel.CVC,
                        Name = payModel.Order.Customer.Name + " " + payModel.Order.Customer.Surname,
                    }
                };

                var serviceToken = new TokenService();
                var stripeToken = await serviceToken.CreateAsync(options);

                var customers = new CustomerService();
                var customer = await customers.CreateAsync(new CustomerCreateOptions()
                {
                    Email = payModel.Order.Customer.Email,
                    Source = stripeToken.Id,
                    Name = payModel.Order.Customer.Name + " " + payModel.Order.Customer.Surname,
                    Address = new AddressOptions
                    {
                        City = payModel.Order.Customer.City,
                        Country = payModel.Order.Customer.Country,
                        Line1 = payModel.Order.Customer.Address,
                        PostalCode = payModel.Order.Customer.PostalCode
                    }
                });

                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = (int)payModel.Amount * 100,
                    Currency = "eur",
                    Description = "Shop payment",
                    Customer = customer.Id
                };

                var chargeService = new ChargeService();
                var charge = await chargeService.CreateAsync(chargeOptions);

                if(charge.Paid)
                {
                    return "Success";
                }
                return "Failed";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}