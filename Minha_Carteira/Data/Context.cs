using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Minha_Carteira.Data;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options) : base(options)
	{
		Database.EnsureCreated(); 
	}

	public DbSet<Entry> Entries { get; set; }
}
