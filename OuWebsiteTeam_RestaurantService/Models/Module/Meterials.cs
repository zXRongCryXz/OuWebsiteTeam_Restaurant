﻿using System;
using System.Collections.Generic;
using System.Linq;
using OuWebsiteTeam_RestaurantService.InterfaceEx.Module;
using OuWebsiteTeam_RestaurantService.DBContext;

namespace OuWebsiteTeam_RestaurantService.Models.Module
{
    public class Meterials : IMeterials
    {
        private readonly RestaurantDBContext _context;
        public Meterials(RestaurantDBContext context)
        {
            this._context = context;
        }

        public bool Create(PdbMeterial met)
        {
            _context.PdbMeterials.Add(met);
            _context.Entry(met).State = System.Data.Entity.EntityState.Added;
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(PdbMeterial met)
        {
            _context.PdbFoods.Attach(fo);
            _context.Entry(fo).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges() == 1; ;
        }

        public IEnumerable<PdbMeterial> GetAll()
        {
            return this._context.PdbMeterials;
        }

        public PdbMeterial GetOne(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
