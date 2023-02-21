using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;

namespace Dulichvietlao.Services
{
    public class TourService
    {
        private readonly DulichvietlaoContext _db;
        public TourService(DulichvietlaoContext db)
        {
            this._db = db;
        }
        public List<TourViewModel> Domestic()
        {
            //var tours = _db.Tours.Where(n=>n.InTour==1).ToList();
            var domestics = new List<TourViewModel>();
            //foreach (var item in tours)
            //{
            //    TourViewModel tourView = new TourViewModel();
            //    tourView.NameTour = item.NameTour;
            //    tourView.Day = item.Day;
            //    tourView.Night = item.Night;
            //    tourView.Cost = item.Cost;
            //    tourView.Code = item.Code;
            //    tourView.Description = item.Description;
            //    showInTour.Add(tourView);
            //}

            // --Use Dapper--
            using (var conn = new SqlConnection(this._db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                domestics = conn.Query<TourViewModel>(@"select * from Tour where Domestic=1").ToList();
                conn.Close();
            }
            return domestics;
        }
        public List<TourViewModel> National()
        {
            var nationals = new List<TourViewModel>();
            using (var connection = new SqlConnection(this._db.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                nationals = connection.Query<TourViewModel>(@"select * from Tour where [National]=1").ToList();
                connection.Close();
            }
            return nationals;
        }
        //public List<TourViewModel> TourDetail(int? id)
        //{
        //    var showInTour = new List<TourViewModel>();
        //    using (var conn = new SqlConnection(this._db.Database.GetDbConnection().ConnectionString))
        //    {
        //        conn.Open();
        //        List<TourViewModel> tourId = conn.Query<TourViewModel>(@"select * from Tour where Id="+id).ToList();
        //        foreach (var item in tourId)
        //        {
        //            showInTour.Add(item);
        //        }   
        //        conn.Close();
        //    }
        //    return showInTour;
        //}
        public TourViewModel TourDetail(int? id)
        {
            var tourId = new List<TourViewModel>();
            using (var conn = new SqlConnection(this._db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                tourId = conn.Query<TourViewModel>("select * from Tour where Id=" + id).ToList();
                conn.Close();
            }
            return tourId.SingleOrDefault(n => n.Id == id);
        }
        public List<TourViewModel> FindTour(string nameTour/*,DateTime beginDate*/)
        {
            var findTour = new List<TourViewModel>();
            using (var connection = new SqlConnection(this._db.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                findTour = connection.Query<TourViewModel>(@"select * from Tour").Where(n=>n.NameTour.Contains(nameTour)).ToList();
                connection.Close();
            }
            return findTour;
        }
    }

}
