using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepo
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
       
        public OrderRepository(E_Context context) : base(context)
        {
           
        }

    }
}
