using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NilveraProject.Application.Abstractions;
using NilveraProject.Domain.Entities;
using NilveraProject.Infrastructure.Data;

namespace NilveraProject.Infrastructure.Repositories
{
    public class CustomerRepository(NilveraContext ctx):ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using var conn = ctx.CreateConnection();
            var values = await conn.QueryAsync<Customer>("sp_Customers_GetAll",commandType: System.Data.CommandType.StoredProcedure);
            return values;
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            using var conn = ctx.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Customer>("sp_Customers_GetById",new { Id = id },commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> InsertAsync(Customer c)
        {
            using var conn = ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@Name", c.Name);
            p.Add("@Surname", c.Surname);
            p.Add("@Email", c.Email);
            p.Add("@Phone", c.Phone);
            p.Add("@Address", c.Address);
            p.Add("@JsonData", c.JsonData);
            p.Add("@NewId", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            await conn.ExecuteAsync("sp_Customers_Insert", p, commandType: System.Data.CommandType.StoredProcedure);
            return p.Get<int>("@NewId");
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            using var conn = ctx.CreateConnection();
            var values = await conn.ExecuteAsync("sp_Customers_Update",new
                {
                    customer.Id,
                    customer.Name,
                    customer.Surname,
                    customer.Email,
                    customer.Phone,
                    customer.Address,
                    customer.JsonData
                },
                commandType: System.Data.CommandType.StoredProcedure);
            return values > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = ctx.CreateConnection();
            var values = await conn.ExecuteAsync("sp_Customers_Delete",new { Id = id },commandType: System.Data.CommandType.StoredProcedure);
            return values > 0;
        }
    }
}
