using System;
using System.Threading.Tasks;
using Stripe;
using WebUI.Models;

namespace WebUI.Services
{
    public class ProcessPayment
    {
        public static async Task<dynamic> PayAsync(CheckoutModel model)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51JsEIUIlJsyPbmS73aPzZyjvvbFoCAqtqqZhOVSX2sdj7UCJwlS9Lj1z1arO8klNCTL4HEhZfYQZtklCHS4pLKXz00ZiquLr2m";

                var options = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = model.PaymentModel.CardNumber,
                        ExpMonth = Convert.ToInt32(model.PaymentModel.Expiration[..2]),
                        ExpYear = Convert.ToInt32(model.PaymentModel.Expiration.Split("/")[1]),
                        Cvc = model.PaymentModel.CVV,
                        Name = model.Order.Customer.Name + " " + model.Order.Customer.Surname,
                    }
                };

                var serviceToken = new TokenService();
                var stripeToken = await serviceToken.CreateAsync(options);

                var customers = new CustomerService();
                var customer = await customers.CreateAsync(new CustomerCreateOptions
                {
                    Email = model.Order.Customer.Email,
                    Source = stripeToken.Id,
                    Name = model.Order.Customer.Name + " " + model.Order.Customer.Surname,
                    Address = new AddressOptions
                    {
                        City = model.Order.ShipCity,
                        Country = model.Order.ShipCountry,
                        Line1 = model.Order.ShipAddress,
                        PostalCode = model.Order.ShipPostalCode
                    }
                });

                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = (int) model.Amount * 100,
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