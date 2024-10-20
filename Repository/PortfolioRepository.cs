﻿using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _dbContext;
         public PortfolioRepository(ApplicationDBContext context)
        {
            _dbContext = context; 

        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _dbContext.Portfolios.AddAsync(portfolio);
            await _dbContext.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeletePorfolio(AppUser appUser, string symbol)
        {
            var portfolioModel = await _dbContext.Portfolios.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolioModel == null) {
                return null;
            }

            _dbContext.Portfolios.Remove(portfolioModel);
            await _dbContext.SaveChangesAsync();
            return portfolioModel;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _dbContext.Portfolios.Where(u => u.AppUserId == user.Id)
                 .Select(stock => new Stock
                 {
                     Id = stock.StockId,
                     Symbol = stock.Stock.Symbol,
                     CompanyName = stock.Stock.CompanyName,
                     Purchase = stock.Stock.Purchase,
                     LastDiv = stock.Stock.LastDiv,
                     Industry = stock.Stock.Industry,
                     MarketCap = stock.Stock.MarketCap,
                 }).ToListAsync();
        }
    }
}
