using BookShop.Areas.Admin.ViewModels;
using BookShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Areas.Admin.Dao
{
    public class DeliveryDAO
    {
        private ApplicationDbContext _context;

        public DeliveryDAO()
        {
            _context = new ApplicationDbContext();
        }
        public int CountTH(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var order = customer.Orders.Where(c => c.IdState == 3).Count();
            return order;
        }

        public Book GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            return book;
        }

        public int? tongTien(int idOrder)
        {
            return _context.DetailOrders.Where(c => c.IdOrder == idOrder).Sum(c => c.Price);
        }

        public List<DetailOrder> GetDetailOrders(int idOrder)
        {
            return _context.DetailOrders.Where(c => c.IdOrder == idOrder).ToList();
        }

        public IEnumerable<TopList> getTopList()
        {
            string q = "select idbook as Id, Book.Name as Name, sum(DetailOrder.Amount) as Tong" +
                        "from DetailOrder, Orders, Book" +
                        "WHERE IdOrder = orders.Id AND ORDERS.IdState != 3 and IdBook = Book.Id" +
                        "group by IdBook, Book.Name" +
                        "order by TONG DESC";
            IEnumerable<TopList> lst = _context.Database.SqlQuery<TopList>(q);
            return lst;
        }
    }
}