using AutoMapper;
using BLL.Models;
using DAL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace BLL
{
    public class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitializeInstance();
            return _instance;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, UserDTO>().ReverseMap();
                cfg.CreateMap<TranzactionDTO, TranzactionModel>().ReverseMap();
            }));
        }
    }
}
