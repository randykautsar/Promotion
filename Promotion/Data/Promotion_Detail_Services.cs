using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.Data
{
    public class Promotion_Detail_Services
    {
      
        #region Property
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public Promotion_Detail_Services(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Promotions
        public async Task<List<Promotion_Detail>> GetAllPromotionsAsync()
        {
            return await _appDBContext.Promotion_Detail.ToListAsync();
        }
        #endregion

        #region Insert Promotion
        public async Task<bool> InsertPromotionAsync(Promotion_Detail Promotion)
        {
            await _appDBContext.Promotion_Detail.AddAsync(Promotion);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Promotion by Id
        public async Task<Promotion_Detail> GetPromotionAsync(int Id)
        {
        Promotion_Detail Promotion = await _appDBContext.Promotion_Detail.FirstOrDefaultAsync(c => c.PromoID.Equals(Id));
            return Promotion;
        }
        #endregion

        public async Task<string> GetPromotionID()
        {
            string val;
            Promotion_Detail Promotion = await _appDBContext.Promotion_Detail.FirstOrDefaultAsync();
            if (Promotion == null)
            {
                return val = "P" + DateTime.Now.ToString("yyyyMMdd") + "00001";
            }
            else
            {
                int Seq = Convert.ToInt32(Promotion.PromoID.Substring(9, 5) ) + 1;
                return val = "P" + DateTime.Now.ToString("yyyyMMdd") + Seq.ToString("D5");
            }
        }

        #region Update Promotion
        public async Task<bool> UpdatePromotionAsync(Promotion_Detail Promotion)
            {
                _appDBContext.Promotion_Detail.Update(Promotion);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            #endregion

            #region DeletePromotion
            public async Task<bool> DeletePromotionAsync(Promotion_Detail Promotion)
            {
                _appDBContext.Remove(Promotion);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            #endregion
        }
    }
