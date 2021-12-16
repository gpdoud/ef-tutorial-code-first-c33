using Microsoft.EntityFrameworkCore;

using SalesDbLib.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDbLib.Controllers
{
	public class CustomersController
	{
		private readonly AppDbContext _context;

		public CustomersController()
		{
			_context = new AppDbContext();
		}

		public async Task<List<Customer>> GetAll()
		{
			return await _context.Customers
									.OrderBy(x => x.Name)
									.ToListAsync();
		}
		public async Task<bool> Change(int Id, Customer customer)
		{
			_context.Entry(customer).State
				= EntityState.Modified;
			return await _context.SaveChangesAsync() == 1;
		}
	}
}
