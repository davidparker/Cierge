namespace NetSo.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NetSo.Data;
    using NetSo.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class SiteService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public SiteService(ApplicationDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Site> CreateSite(string name, string url){
            var model = new Site
            {
                Name = name,
                Url = url,
                Clients = new List<Client>()
            };
            await _dbContext.Sites.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<Site>> GetSites(string sortOrder, int take = 10, int page = 1)
        {
            var skip = 0;

            if(page > 1){
                skip = take * page;
            }

            List<Site> Sites = await _dbContext.Sites.
            Include(i => i.Clients).Skip(skip).Take(take).AsNoTracking().ToListAsync();

            if (!string.IsNullOrEmpty(sortOrder) && sortOrder == "url")
            {
                Sites.OrderBy(o => o.Url);
            } else {
                Sites.OrderBy(o => o.Name);
            }

            return Sites;
        }

        public async Task<Site> GetSite(string id){
            return await _dbContext.Sites
                        .Include(s => s.Clients)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Site> UpdateSite(Site site){
             _dbContext.Sites.Update(site);
            await _dbContext.SaveChangesAsync();
            return site;
        }


    }
}