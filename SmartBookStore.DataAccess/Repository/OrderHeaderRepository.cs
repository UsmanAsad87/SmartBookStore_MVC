using SmartBookStore.DataAccess.Data;
using SmartBookStore.DataAccess.Repository.IRepository;
using SmartBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.TableSplittingTestBase;

namespace SmartBookStore.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;   
        }

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj); 
        }
   

        void IOrderHeaderRepository.UpdateStatus(int id, string orderStatus, string? paymentStatus)
        {
            var orderfromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderfromDb != null)
            {
                orderfromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderfromDb.PaymentStatus = paymentStatus;
                }
            }
        }


        void IOrderHeaderRepository.updateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderfromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderfromDb != null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    orderfromDb.SessionId = sessionId;
                }
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderfromDb.PaymentIntendId = paymentIntentId;
                    orderfromDb.PaymentDate = DateTime.Now;
                }
            }
        }
    }
}
