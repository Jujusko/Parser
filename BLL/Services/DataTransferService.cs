using BLL.Models;
using DAL.DataTransferObjects;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DataTransferService
    {

        public TranzactionDTO BuildDTOTranz(TranzactionModel tranz)
        {
            UserRepository userRepository = new UserRepository();
            TranzactionDTO newTranzIntoDB = CustomMapper.GetInstance().Map<TranzactionDTO>(tranz);

            UserDTO buyerDB;
            if (tranz.BuyerName.Contains("Физическое лицо"))
                buyerDB = userRepository.GetUserByName("Физическое лицо\r");
            else
                buyerDB = userRepository.GetUserByINN(tranz.BuyerINN);

            UserDTO sellerDB = userRepository.GetUserByINN(tranz.SellerINN);


            if (buyerDB is null)
            {
                UserDTO newBuyer = new UserDTO();
                newBuyer.INN = tranz.BuyerINN;
                newBuyer.Name = tranz.BuyerName;
                newBuyer.SellerOrBuyer = false;
                newTranzIntoDB.BuyerId = userRepository.AddNewUser(newBuyer);
            }
            else
                newTranzIntoDB.BuyerId = buyerDB.Id;

            if (sellerDB is null)
            {
                UserDTO newSeller = new UserDTO();
                newSeller.INN = tranz.SellerINN;
                newSeller.Name = tranz.SellerName;
                newSeller.SellerOrBuyer = true;
                newTranzIntoDB.SellerId = userRepository.AddNewUser(newSeller);
            }
            else
                newTranzIntoDB.SellerId = sellerDB.Id;

            return newTranzIntoDB;
        }
        public void SortData(string[] pageData)
        {
            int rowsInLine = 0;
            TranzactionRepository tranzactionRepository = new TranzactionRepository();
            TranzactionModel newTranz = new TranzactionModel();

            // последние 2 не считаем, т.к. там идет сводная информация по всей странице со сделками
            for (int i = 0; i < pageData.Count() - 2; i++)
            {
                if (rowsInLine == 7)
                {
                    if(tranzactionRepository.GetTranzactionByDeclaration(newTranz.Declaration) is null)
                        tranzactionRepository.AddNewTranzaction(BuildDTOTranz(newTranz));
                    rowsInLine = 0;
                }
                if (rowsInLine == 0)
                {
                    newTranz = new TranzactionModel();
                    newTranz.Declaration = pageData[i];
                }

                if (rowsInLine == 1)
                    newTranz.SellerName = pageData[i];

                if (rowsInLine == 2)
                    newTranz.SellerINN = pageData[i];

                if (rowsInLine == 3)
                    newTranz.BuyerName = pageData[i];

                if (rowsInLine == 4)
                {
                    if (newTranz.BuyerName.Contains("Физическое лицо"))
                        rowsInLine++;
                    else
                        newTranz.BuyerINN = pageData[i];
                }

                if (rowsInLine == 5)
                    newTranz.Date = pageData[i];

                if (rowsInLine == 6)
                    newTranz.Value = pageData[i];

                rowsInLine++;
            }
        }

    }
}
