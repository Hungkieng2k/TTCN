using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Dulichvietlao.Models.Commands;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;

namespace Dulichvietlao.Services
{
    public class TravelService
    {
        private readonly DulichvietlaoContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        public TravelService(DulichvietlaoContext db,IHostingEnvironment hostingEnvironment)
        {
            this._db = db;
            this._hostingEnvironment = hostingEnvironment;
        }
        public List<ContractDetailViewModel> ListTravel()
        {
            var listTravelDb = from c in _db.ContractDetails
                               join t in _db.Tours on c.TourId equals t.Id
                               join ct in _db.Contracts on c.ContractId equals ct.Id
                               join cs in _db.Customers on ct.CustomerId equals cs.Id
                               where ct.Paid == false
                               select new { t.Code, c.NameTour, cs.Name, ct.BeginDate, ct.Paid,t.Cost,c.Id };
            var listTravel = new List<ContractDetailViewModel>();
            foreach (var item in listTravelDb)
            {
                ContractDetailViewModel viewModel = new ContractDetailViewModel();
                viewModel.Id = item.Id;
                viewModel.Code = item.Code;
                viewModel.NameTour = item.NameTour;
                viewModel.NameCustomer = item.Name;
                viewModel.BeginDate = item.BeginDate;
                viewModel.Paid = item.Paid;
                viewModel.Cost = item.Cost;
                listTravel.Add(viewModel);
            }
            return listTravel;
        }
        public IQueryable<TourViewModel> ShowAllTour()
        {
            var tours = from t in _db.Tours
                        select new { t.Code, t.Cost, t.Day, t.Night, t.Picture, t.Quantity,t.NameTour,t.Id };

            var tourView = new List<TourViewModel>();
            foreach (var item in tours)
            {
                TourViewModel tourViewModel = new TourViewModel();
                tourViewModel.Id = item.Id;
                tourViewModel.Code = item.Code;
                tourViewModel.Cost = item.Cost;
                tourViewModel.NameTour = item.NameTour;
                tourViewModel.Picture = item.Picture;
                tourViewModel.Quantity = item.Quantity;
                tourViewModel.Day = item.Day;
                tourViewModel.Night = item.Night;
                tourView.Add(tourViewModel);
            }
            return tourView.AsQueryable(); 
        }
        public TourViewModel SeeTour(int id)
        {
            TourViewModel viewModel = new TourViewModel();
            var listTour = _db.Tours.FirstOrDefault(n=>n.Id==id);
            {
                viewModel.Id = listTour.Id;
                viewModel.NameTour = listTour.NameTour;
            }
            return viewModel;
        }
        public void EditTour(InsertTourCommand command)
        {
            var checkTour = _db.Tours.FirstOrDefault(n=>n.Id==command.Id);
            {
                checkTour.Code = command.Code;
                checkTour.Cost = command.Cost;
                checkTour.Day = command.Day;
                checkTour.Night = command.Night;
                checkTour.Quantity = command.Quantity;
                checkTour.Description = command.Description;
                checkTour.Discount = command.Discount;
            }
            _db.SaveChanges();
        }
        public void DeleteTour(InsertTourCommand command)
        {
            var checkTour = _db.Tours.FirstOrDefault(n => n.Id == command.Id);
            _db.Remove(checkTour);
            _db.SaveChanges();
        }
        public ContractDetailViewModel SeeContractDeTail(int? id)
        {
            var listTravelDb = from c in _db.ContractDetails
                               join t in _db.Tours on c.TourId equals t.Id
                               join ct in _db.Contracts on c.ContractId equals ct.Id
                               join cs in _db.Customers on ct.CustomerId equals cs.Id
                               where c.Id==id
                               select new { t.Code, c.NameTour, cs.Name, ct.BeginDate, ct.Paid, t.Cost,t.Picture,c.PeopleGo,cs.Email };
            var detailBookTour = new ContractDetailViewModel();
            foreach (var item in listTravelDb)
            {
                detailBookTour.Code = item.Code;
                detailBookTour.NameTour = item.NameTour;
                detailBookTour.NameCustomer = item.Name;
                detailBookTour.BeginDate = item.BeginDate;
                detailBookTour.Paid = item.Paid;
                detailBookTour.Cost = item.Cost;
                detailBookTour.Picture = item.Picture;
                detailBookTour.PeopleGo = item.PeopleGo;
                detailBookTour.Email = item.Email;
            }
            return detailBookTour;
        }
        public void DeleteContractDetail(int? id)
        {
            var deleteContractDetail = _db.ContractDetails.FirstOrDefault(n=>n.Id==id);
            _db.ContractDetails.Remove(deleteContractDetail);
            _db.SaveChanges();
        }
        public ContractDetailViewModel EditContractDetail(int? id)
        {
            var listTravelDb = from c in _db.ContractDetails
                               join t in _db.Tours on c.TourId equals t.Id
                               join ct in _db.Contracts on c.ContractId equals ct.Id
                               join cs in _db.Customers on ct.CustomerId equals cs.Id
                               where c.Id == id
                               select new { t.Code, c.NameTour, cs.Name, ct.BeginDate, ct.Paid, t.Cost, t.Picture, c.PeopleGo, cs.Email,c.Id };
            var detailBookTour = new ContractDetailViewModel();
            foreach (var item in listTravelDb)
            {
                detailBookTour.Id = item.Id;
                detailBookTour.Code = item.Code;
                detailBookTour.NameTour = item.NameTour;
                detailBookTour.NameCustomer = item.Name;
                detailBookTour.BeginDate = item.BeginDate;
                detailBookTour.Paid = item.Paid;
                detailBookTour.Cost = item.Cost;
                detailBookTour.Picture = item.Picture;
                detailBookTour.PeopleGo = item.PeopleGo;
                detailBookTour.Email = item.Email;
            }
            return detailBookTour;
        }
        public void EditContractDetail(ContractDetailViewModel viewModel)
        {
            var data = _db.ContractDetails.FirstOrDefault(n=>n.Id==viewModel.Id);
            if(viewModel.Paid==true)
            {
                var model = _db.Contracts.FirstOrDefault(n=>n.Id==data.ContractId);
                model.Paid = true;
                _db.SaveChanges();
            }
        }
        public List<ContractDetailViewModel> Paid()
        {
            var listTravelDb = from c in _db.ContractDetails
                               join t in _db.Tours on c.TourId equals t.Id
                               join ct in _db.Contracts on c.ContractId equals ct.Id
                               join cs in _db.Customers on ct.CustomerId equals cs.Id
                               where ct.Paid == true
                               select new { t.Code, c.NameTour, cs.Name, ct.BeginDate, ct.Paid, t.Cost, c.Id };
            var listTravel = new List<ContractDetailViewModel>();
            foreach (var item in listTravelDb)
            {
                ContractDetailViewModel viewModel = new ContractDetailViewModel();
                viewModel.Id = item.Id;
                viewModel.Code = item.Code;
                viewModel.NameTour = item.NameTour;
                viewModel.NameCustomer = item.Name;
                viewModel.BeginDate = item.BeginDate;
                viewModel.Paid = item.Paid;
                viewModel.Cost = item.Cost;
                listTravel.Add(viewModel);
            }
            return listTravel;
        }

    }
}
