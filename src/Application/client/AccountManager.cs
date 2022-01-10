using System;
using AutoMapper;
using Data.admin.Helpers;
using Data.client;
using Domain.Entities;
using WebUI.Models;

namespace Application.client
{
    public class AccountManager
    {
        private readonly AccountDal _accountManager;
        private readonly IMapper _mapper;

        public AccountManager(AccountDal accountManager,IMapper mapper)
        {
            _accountManager = accountManager;
            _mapper = mapper;
        }

        public bool Register(RegisterModel model)
        {
            var customer = _mapper.Map<Customer>(model);

            customer.InsertDate = DateTime.Now;
            var date = string.Concat(model.VitiLindjes, "-",model.MuajiLindjes,"/", model.DitaLindjes);
            customer.Birthdate = DateTime.Parse(date);

            customer.PasswordHash = EncodeBase64.Base64Encode(model.Fjalekalimi); 
            
            var result = _accountManager.Register(customer);

            return result;
        }

        public Customer Login(LoginModel model) => _accountManager.Login(model.Email, model.Fjalekalimi);

        public Customer GetCustomerById(int id) => _accountManager.GetCustomer(id);

    }
}