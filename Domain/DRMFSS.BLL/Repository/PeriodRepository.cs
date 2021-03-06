using System.Collections.Generic;
using System.Linq;
using DRMFSS.BLL.Interfaces;
using DRMFSS.BLL.MetaModels;
using System.ComponentModel.DataAnnotations;


namespace DRMFSS.BLL.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PeriodRepository :GenericRepository<CTSContext,Period>, IPeriodRepository
    {
        public PeriodRepository(CTSContext _db, IUnitOfWork uow)
        {
            db = _db;
            repository = uow;
        } 
        /// <summary>
        /// Gets the years.
        /// </summary>
        /// <returns></returns>
        public List<int?> GetYears()
        {
            return db.Periods.Where(y => y.Year.HasValue).Select(p => p.Year).Distinct().ToList();
        }

        /// <summary>
        /// Gets the months.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public List<int?> GetMonths(int year)
        {
            return db.Periods.Where(y => y.Year == year && y.Month.HasValue).Select(p => p.Month).Distinct().ToList();
        }


        /// <summary>
        /// Gets the period.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public BLL.Period GetPeriod(int year, int month)
        {
            return db.Periods.Where(p => p.Year == year && p.Month == month).SingleOrDefault();
        }


        public bool DeleteByID(int id)
        {
            var original = FindById(id);
            if (original == null) return false;
            db.Periods.Remove(original);

            return true;
        }

        public bool DeleteByID(System.Guid id)
        {
            return false;
        }

        public Period FindById(int id)
        {
            return db.Periods.FirstOrDefault(t => t.PeriodID == id);
        }

        public Period FindById(System.Guid id)
        {
            return null;
        }
    }
}
