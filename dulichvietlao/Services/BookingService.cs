using System;
using System.Linq;
using Dulichvietlao.Models.Commands;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;
using System.Net.Mail;

namespace Dulichvietlao.Services
{
    public class BookingService
    {
        private readonly DulichvietlaoContext _db;
        private readonly TourService _tourService;
        public BookingService(DulichvietlaoContext db, TourService tourService)
        {
            this._db = db;
            this._tourService = tourService;
        }
        public void BookingTour(BookingTourCommand command)
        {
            var newCustomer = new Customer(command);
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
            //Insert Contract
            ContractViewModel contract = new ContractViewModel();
            {
                contract.CustomerId = newCustomer.Id;
                contract.TourId = command.TourId;
                contract.BeginDate = command.BeginDate;
                contract.Paid = false;
                contract.Content = command.Content;
            }
            var newContract = new Contract(contract);
            _db.Contracts.Add(newContract);
            _db.SaveChanges();
            var tour = _db.Tours.FirstOrDefault(n => n.Id == command.TourId);
            {
                tour.Quantity = tour.Quantity - Convert.ToInt32(command.PeopleGo);
            }
            _db.SaveChanges();
            //Insert ContractDetail
            ContractDetailViewModel contractDetail = new ContractDetailViewModel();
            {
                contractDetail.TourId = tour.Id;
                contractDetail.NameTour = tour.NameTour;
                contractDetail.Cost = tour.Cost;
                contractDetail.PeopleGo = Convert.ToInt32(command.PeopleGo);
                contractDetail.ContractId = newContract.Id;
            }
            var newContractDetail = new ContractDetail();
            {
                newContractDetail.TourId = contractDetail.TourId;
                newContractDetail.NameTour = contractDetail.NameTour;
                newContractDetail.Cost = contractDetail.Cost;
                newContractDetail.PeopleGo = contractDetail.PeopleGo;
                newContractDetail.ContractId = contractDetail.ContractId;
            }
            _db.ContractDetails.Add(newContractDetail);
            _db.SaveChanges();
        }
   
    }
}
