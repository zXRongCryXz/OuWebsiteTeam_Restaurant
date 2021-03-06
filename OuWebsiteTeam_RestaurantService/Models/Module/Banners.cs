﻿using System;
using System.Collections.Generic;
using OuWebsiteTeam_RestaurantService.DBContext;
using OuWebsiteTeam_RestaurantService.InterfaceEx.Module;
using System.Linq;

namespace OuWebsiteTeam_RestaurantService.Models.Module
{
    public class Banners : IBanners
    {
        private readonly RestaurantDBContext _context;

        public Banners(RestaurantDBContext context)
        {
            this._context = context;
        }

        public bool Create(PdbBanner ban)
        {
            _context.PdbBanners.Add(ban);
            _context.Entry(ban).State = System.Data.Entity.EntityState.Added;
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Guid id)
        {
            PdbBanner itemc = _context.PdbBanners.SingleOrDefault(item => item.ID == id);
            _context.PdbBanners.DefaultIfEmpty(itemc);
            _context.Entry(itemc).State = System.Data.Entity.EntityState.Deleted;
            return _context.SaveChanges() == 1;
        }

        public bool Edit(PdbBanner met)
        {
            _context.PdbBanners.Attach(met);
            _context.Entry(met).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges() == 1; ;
        }

        public IEnumerable<PdbBanner> GetAll()
        {
            return this._context.PdbBanners;
        }

        public PdbBanner GetOne(Guid id)
        {
            return _context.PdbBanners.SingleOrDefault(item => item.ID == id);
        }
    }
}
