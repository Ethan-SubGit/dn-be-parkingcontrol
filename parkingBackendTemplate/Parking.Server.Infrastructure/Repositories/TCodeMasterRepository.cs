using Microsoft.EntityFrameworkCore;
using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    public class TCodeMasterRepository : ITCodeMasterRepository
    //public class TCodeMasterRepository : IDataRepository<TCodeMaster>
    {
        private readonly ParkingIntegratedControlCenterContext _context;
        //public IUnitOfWork UnitOfWork => _context;

        public TCodeMasterRepository(ParkingIntegratedControlCenterContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<IEnumerable<TCodeMaster>> GetAll()
        {
            //var orer = _context.TCodeMasters.FromSqlRaw("Select * from t_Codemaster where cm_cd = {0}", "discountType").FirstOrDefaultAsync().ConfigureAwait(false);

            var row = await _context.Set<TCodeMaster>().AsNoTracking().ToListAsync().ConfigureAwait(false);

            return row;
            //var e2 = _context.TCodeMasters.Include(c => c.CmCd).AsNoTracking().to
            //var row = _context.TCodeMasters.w
            //return _context.TCodeMaster
            //return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tCodeMaster"></param>
        /// <returns></returns>
        public async Task<TCodeMaster> Create(TCodeMaster tCodeMaster)
        {
            if (tCodeMaster == null)
            {
                throw new ArgumentException(nameof(tCodeMaster));
            }
            var row = _context.TCodeMasters.Add(tCodeMaster).Entity;
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return row; 
            //return _context.TCodeMasters.Add(tCodeMaster).Entity;
        }

        /// <summary>
        /// modify
        /// </summary>
        /// <param name="tparkingLotBasicInfo"></param>
        /// <returns></returns>
        public async Task<TCodeMaster> Update(TCodeMaster tCodeMaster)
        {
            var CM_CD = tCodeMaster.CmCd;
            var row = _context.TCodeMasters.AsNoTracking().IgnoreQueryFilters().SingleOrDefaultAsync(p => p.CmCd == CM_CD).ConfigureAwait(false);
            
            var entity_ = _context.TCodeMasters.Update(tCodeMaster).Entity;
            //var entity = _context.TCodeMasters.FirstOrDefaultAsync(p => p.CmCd == CM_CD).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity_;
        }

        public async Task<List<TCodeMaster>> Retrieves()
        {
            var parkingLotList = await _context.TCodeMasters.ToListAsync().ConfigureAwait(false);

            return parkingLotList;
        }

        public async Task<TCodeMaster> Retrieve(string code)
        {
            var codeMasterList = await _context.TCodeMasters
                                .FirstAsync(p => p.CmCd == code).ConfigureAwait(false);

            return codeMasterList;
        }

        public async void Delete(TCodeMaster tCodeMaster)
        {
            //var delEntity = _context.TCodeMasters.Remove(tCodeMaster);
            _context.Remove(tCodeMaster);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            
            //return delEntity;
        }

        TCodeMaster ITCodeMasterRepository.Create(TCodeMaster tCodeMaster)
        {
            throw new NotImplementedException();
        }

        TCodeMaster ITCodeMasterRepository.Delete(TCodeMaster tCodeMaster)
        {
            throw new NotImplementedException();
        }

        //TCodeMaster ITCodeMasterRepository.Update(TCodeMaster tCodeMaster)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
