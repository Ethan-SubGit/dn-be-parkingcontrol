using Microsoft.EntityFrameworkCore;
using Parking.Server.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Server.Infrastructure.Repositories
{
    public class TCodeRepository
    {
        private readonly ParkingIntegratedControlCenterContext _context;
        public TCodeRepository(ParkingIntegratedControlCenterContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TCode"></param>
        /// <returns></returns>
        public TCode Create(TCode TCode)
        {
            if (TCode == null)
            {
                throw new ArgumentException(nameof(TCode));
            }

            return _context.TCodes.Add(TCode).Entity;
        }

        /// <summary>
        /// modify
        /// </summary>
        /// <param name="tparkingLotBasicInfo"></param>
        /// <returns></returns>
        public TCode Update(TCode TCode)
        {
            return _context.TCodes.Update(TCode).Entity;
        }

        public async Task<List<TCode>> Retrieves()
        {
            var parkingLotList = await _context.TCodes.ToListAsync().ConfigureAwait(false);

            return parkingLotList;
        }

        public async Task<TCode> Retrieve(string code)
        {
            var codeMasterList = await _context.TCodes
                                .FirstAsync(p => p.CmCd == code).ConfigureAwait(false);

            return codeMasterList;
        }

        public TCode Delete(TCode TCode)
        {
            var delEntity = _context.TCodes.Remove(TCode).Entity;

            return delEntity;
        }
    }
}
