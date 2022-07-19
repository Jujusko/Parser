using BLL.Models;
using DAL.DataTransferObjects;
using DAL.Repositories;
using System.Linq;

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
                buyerDB = userRepository.GetUserByName("Физическое лицо");
            else
                buyerDB = userRepository.GetUserByINN(tranz.BuyerINN);

            UserDTO sellerDB = userRepository.GetUserByINN(tranz.SellerINN);


            if (buyerDB is null || buyerDB.INN != tranz.BuyerINN)
            {
                UserDTO newBuyer = new UserDTO();
                newBuyer.INN = tranz.BuyerINN;
                newBuyer.Name = tranz.BuyerName;
                newBuyer.SellerOrBuyer = false;
                newTranzIntoDB.BuyerId = userRepository.AddNewUser(newBuyer);
            }
            else
                newTranzIntoDB.BuyerId = buyerDB.Id;

            if (sellerDB is null || sellerDB.INN != tranz.SellerINN)
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
        private string CutRSymb(string str)
        {
            return str.Replace('\r', '\0');
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
                    newTranz.Declaration = CutRSymb(pageData[i]);
                }

                if (rowsInLine == 1)
                    newTranz.SellerName = CutRSymb(pageData[i]);

                if (rowsInLine == 2)
                    newTranz.SellerINN = CutRSymb(pageData[i]);

                if (rowsInLine == 3)
                    newTranz.BuyerName = CutRSymb(pageData[i]);

                if (rowsInLine == 4)
                {
                    if (newTranz.BuyerName.Contains("Физическое лицо"))
                        rowsInLine++;
                    else
                        newTranz.BuyerINN = CutRSymb(pageData[i]);
                }

                if (rowsInLine == 5)
                    newTranz.Date = CutRSymb(pageData[i]);

                if (rowsInLine == 6)
                    newTranz.Value = CutRSymb(pageData[i]);

                rowsInLine++;
            }
        }

    }
}
